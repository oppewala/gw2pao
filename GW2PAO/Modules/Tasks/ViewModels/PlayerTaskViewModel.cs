﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GW2PAO.API.Services.Interfaces;
using GW2PAO.Modules.Tasks.Interfaces;
using GW2PAO.Modules.Tasks.Models;
using GW2PAO.Modules.Tasks.Views;
using GW2PAO.Utility;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using NLog;

namespace GW2PAO.Modules.Tasks.ViewModels
{
    public class PlayerTaskViewModel : BindableBase
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private PlayerTask task;
        private IZoneService zoneService;
        private IPlayerTasksController controller;
        private CompositionContainer container;
        private string mapName;
        private bool isPlayerOnMap;
        private double distanceFromPlayer;
        private double directionFromPlayer;
        private bool isVisible;

        /// <summary>
        /// The player task's name
        /// </summary>
        public string Name
        {
            get { return this.Task.Name; }
        }

        /// <summary>
        /// The actual player task
        /// </summary>
        public PlayerTask Task
        {
            get { return this.task; }
            private set { SetProperty(ref this.task, value); }
        }

        /// <summary>
        /// True if this task has a location, else false
        /// </summary>
        public bool HasLocation
        {
            get { return this.Task.Location != null; }
        }

        /// <summary>
        /// True if this task has a visible location, else false
        /// </summary>
        public bool DisplayLocation
        {
            get { return this.HasLocation && this.IsPlayerOnMap; }
        }

        /// <summary>
        /// Name of the map that this task is for, if any
        /// </summary>
        public string MapName
        {
            get { return this.mapName;}
            private set { SetProperty(ref this.mapName, value); }
        }

        /// <summary>
        /// True if the player is currently on the same map as this task, else false
        /// </summary>
        public bool IsPlayerOnMap
        {
            get { return this.isPlayerOnMap; }
            set
            {
                if (SetProperty(ref this.isPlayerOnMap, value))
                {
                    this.OnPropertyChanged(() => this.DisplayLocation);
                    this.RefreshVisibility();
                }
            }
        }

        /// <summary>
        /// The distance from the player's position
        /// </summary>
        public double DistanceFromPlayer
        {
            get
            {
                if (this.HasLocation && this.IsPlayerOnMap)
                {
                    return this.distanceFromPlayer;
                }
                else
                {
                    return double.MaxValue;
                }
            }
            set { SetProperty(ref this.distanceFromPlayer, value); }
        }

        /// <summary>
        /// Direction/Angle from the player's position
        /// </summary>
        public double DirectionFromPlayer
        {
            get { return this.directionFromPlayer; }
            set { SetProperty(ref this.directionFromPlayer, value); }
        }

        /// <summary>
        /// Visibility of the task
        /// Visibility is based on multiple properties, including:
        ///     - IsCompleted and whether or not completed tasks are shown
        ///     - IsPlayerOnMap and whether or not tasks are shown based on map
        /// </summary>
        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetProperty(ref this.isVisible, value); }
        }

        /// <summary>
        /// The tasks user data
        /// </summary>
        public TasksUserData UserData
        {
            get { return this.controller.UserData; }
        }

        /// <summary>
        /// Command to edit the task
        /// </summary>
        public ICommand CopyWaypointCommand { get; private set; }

        /// <summary>
        /// Command to edit the task
        /// </summary>
        public ICommand EditCommand { get; private set; }

        /// <summary>
        /// Command to delete the task entirely
        /// </summary>
        public ICommand DeleteCommand { get; private set;}

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="task">The task that this view model wraps</param>
        /// <param name="zoneService">Service that provides zone information, such as map name</param>
        public PlayerTaskViewModel(PlayerTask task, IZoneService zoneService, IPlayerTasksController controller, CompositionContainer container)
        {
            this.Task = task;
            this.zoneService = zoneService;
            this.controller = controller;
            this.container = container;

            this.Task.PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == "MapID")
                        this.RefreshMapName();
                };
            System.Threading.Tasks.Task.Factory.StartNew(this.RefreshMapName);

            this.CopyWaypointCommand = new DelegateCommand(this.CopyWaypoint);
            this.EditCommand = new DelegateCommand(this.Edit);
            this.DeleteCommand = new DelegateCommand(this.Delete);
            this.UserData.PropertyChanged += (o, e) => this.RefreshVisibility();
            this.Task.PropertyChanged += (o, e) => this.RefreshVisibility();
            this.RefreshVisibility();
        }

        /// <summary>
        /// Updates the map name property
        /// </summary>
        private void RefreshMapName()
        {
            var name = this.zoneService.GetZoneName(this.Task.MapID);
            Threading.BeginInvokeOnUI(() =>
                {
                    if (this.Task.MapID != -1)
                        this.MapName = name;
                    else
                        this.MapName = string.Empty;
                });
        }

        /// <summary>
        /// Copies the waypoint for this task
        /// </summary>
        private void CopyWaypoint()
        {
            logger.Debug("Copying waypoint code of \"{0}\" as \"{1}\"", this.task.Name, this.Task.WaypointCode);
            System.Windows.Clipboard.SetDataObject(this.Task.WaypointCode);
        }

        /// <summary>
        /// Edits the task
        /// </summary>
        private void Edit()
        {
            logger.Info("Displaying edit task dialog");
            AddNewTaskDialog dialog = new AddNewTaskDialog();
            this.container.ComposeParts(dialog);
            dialog.TaskData.Task = new PlayerTask(this.Task);
            dialog.TaskData.HasLocation = this.Task.Location != null;
            dialog.Show();
        }

        /// <summary>
        /// Deletes/removes the task entirely
        /// </summary>
        private void Delete()
        {
            this.controller.DeleteTask(this.Task);
        }

        /// <summary>
        /// Refreshes the visibility of the event
        /// </summary>
        private void RefreshVisibility()
        {
            logger.Trace("Refreshing visibility of \"{0}\"", this.Task.Name);
            if (!this.UserData.ShowCompletedTasks && this.Task.IsCompleted)
            {
                this.IsVisible = false;
            }
            else if (!this.UserData.ShowTasksNotOnMap && this.HasLocation && !this.IsPlayerOnMap)
            {
                this.IsVisible = false;
            }
            else
            {
                this.IsVisible = true;
            }
            logger.Trace("IsVisible = {0}", this.IsVisible);
        }
    }
}
