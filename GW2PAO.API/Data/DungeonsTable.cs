﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GW2PAO.API.Constants;
using GW2PAO.API.Data.Entities;

namespace GW2PAO.API.Data
{
    /// <summary>
    /// The Dungeons Table containing all information about the various dungeons
    /// </summary>
    public class DungeonsTable
    {
        /// <summary>
        /// File name for the table
        /// </summary>
        public static readonly string FileName = "Dungeons.xml";

        /// <summary>
        /// List of dungeons and their details
        /// </summary>
        public List<Dungeon> Dungeons { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DungeonsTable()
        {
            this.Dungeons = new List<Dungeon>();
        }

        /// <summary>
        /// Loads the world events time table file
        /// </summary>
        /// <returns>The loaded event time table data</returns>
        public static DungeonsTable LoadTable()
        {
            DungeonsTable loadedData = null;
            XmlSerializer deserializer = new XmlSerializer(typeof(DungeonsTable));
            TextReader reader = new StreamReader(FileName);
            try
            {
                object obj = deserializer.Deserialize(reader);
                loadedData = (DungeonsTable)obj;
            }
            finally
            {
                reader.Close();
            }

            return loadedData;
        }

        /// <summary>
        /// Loads the world events time table file
        /// </summary>
        /// <returns>The loaded event time table data</returns>
        public static void CreateTable()
        {
            DungeonsTable dTable = new DungeonsTable();
            dTable.Dungeons.Add(new Dungeon()
                {
                    Name = "Ascalonian Catacombs",
                    ID = DungeonID.AscalonianCatacombs,
                    WorldMapID = 19,
                    MinimumLevel = 30,
                    WaypointCode = "[&BIYBAAA=]",
                    WikiUrl = "http://wiki.guildwars2.com/wiki/Ascalonian_Catacombs",
                    Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = AscalonianCatacombsPathID.Story,
                                InstanceMapID = 33,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(99.5, -62.5, 43.5),
                                PointDetectionRadius = 40,
                                CompletionPrereqPoints = new List<Point> { new Point(-16.8, -96.9, 51.5), new Point(330.1, 83.8, 31.9), new Point(341.5, -47.5, 19.8) }
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = AscalonianCatacombsPathID.P1,
                                InstanceMapID = 36,
                                PathDisplayText = "P1",
                                GoldReward = 1.55,
                                EndPoint = new Point(-316, 193, 0),
                                IdentifyingPoints = new List<Point> { new Point(99, -222, 15), new Point(-87, 98, 54) },
                                PointDetectionRadius = 50
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = AscalonianCatacombsPathID.P2,
                                InstanceMapID = 36,
                                PathDisplayText = "P2",
                                GoldReward = 1.55,
                                EndPoint = new Point(106, 148, 67),
                                IdentifyingPoints = new List<Point> { new Point(315, -185, 0) },
                                PointDetectionRadius = 50
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = AscalonianCatacombsPathID.P3,
                                InstanceMapID = 36,
                                PathDisplayText = "P3",
                                GoldReward = 1.55,
                                EndPoint = new Point(-317, 193, 0),
                                IdentifyingPoints = new List<Point> { new Point(328, -60, 19.4) },
                                PointDetectionRadius = 50
                            }
                        }
                });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Caudecus's Manor",
                ID = DungeonID.CaudecusManor,
                WorldMapID = 15,
                MinimumLevel = 40,
                WaypointCode = "[&BPoAAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Caudecus%27s_Manor",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = CaudecusManorPathID.Story,
                                InstanceMapID = 75,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(252.10, 163.32, 37.48),
                                CompletionPrereqPoints = new List<Point> { new Point(162.28, 84.15, 30.90), new Point(139.54, 232.16, 30.81), new Point(236.73, 259.42, 40.62) },
                                PointDetectionRadius = 50
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = CaudecusManorPathID.P1,
                                InstanceMapID = 76,
                                PathDisplayText = "P1",
                                GoldReward = 1.05,
                                EndPoint = new Point(-195.62,193.663,2.571),
                                IdentifyingPoints = new List<Point> { new Point(126.991, 9.363, 30.898) },
                                CompletionPrereqPoints = new List<Point> { new Point(70.671, 77.091, 22.536), new Point(-41.897, 119.5, 20.746), new Point(55.904, 188.298, 26.573) },
                                PointDetectionRadius = 30
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = CaudecusManorPathID.P2,
                                InstanceMapID = 76,
                                PathDisplayText = "P2",
                                GoldReward = 1.05,
                                EndPoint = new Point(252.08, 268.50, 41.53),
                                IdentifyingPoints = new List<Point> { new Point(46.79, 58.08, 40.08) },
                                CompletionPrereqPoints = new List<Point> { new Point(46.79, 58.08, 40.08), new Point(261.97, -8.27, 41.18) },
                                PointDetectionRadius = 30
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = CaudecusManorPathID.P3,
                                InstanceMapID = 76,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(-215.50, 233.00, 0.49),
                                IdentifyingPoints = new List<Point> { new Point(17.30, 30.58, 16.18) },
                                CompletionPrereqPoints = new List<Point> { new Point(94.86, 127.90, 22.54), new Point(136.28, 239.42, 30.61) },
                                PointDetectionRadius = 30
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Twilight Arbor",
                ID = DungeonID.TwilightArbor,
                WorldMapID = 34,
                MinimumLevel = 50,
                WaypointCode = "[&BEEFAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Twilight_Arbor",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = TwilightArborPathID.Story,
                                InstanceMapID = 68,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(68.70, -0.59, 45.21),
                                IdentifyingPoints = new List<Point>(),
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 20
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = TwilightArborPathID.P1,
                                InstanceMapID = 67,
                                PathDisplayText = "P1",
                                GoldReward = 1.05,
                                EndPoint = new Point(65.51, 1.04, 45.51),
                                IdentifyingPoints = new List<Point> { new Point(42.90, -176.14, 32.26) },
                                CompletionPrereqPoints = new List<Point> { new Point(274.22, 18.34, 38.24), new Point(320.97, 96.49, 33.44), new Point(156.58, 38.84, 38.13) },
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = TwilightArborPathID.P2,
                                InstanceMapID = 67,
                                PathDisplayText = "P2",
                                GoldReward = 2.05,
                                EndPoint = new Point(-201.52, 249.99, 20.56),
                                IdentifyingPoints = new List<Point> { new Point(-31.42, -262.85, -0.54) },
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 50
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = TwilightArborPathID.P3,
                                InstanceMapID = 67,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(57.02, -0.15, 45.16),
                                IdentifyingPoints = new List<Point> { new Point(-55.25, -137.32, 2.77) },
                                CompletionPrereqPoints = new List<Point> { new Point(-105.83, 36.87, 4.51), new Point(136.93, 224.23, 62.63), new Point(158.22, 46.20, 36.09) },
                                PointDetectionRadius = 35
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Sorrow's Embrace",
                ID = DungeonID.SorrowsEmbrace,
                WorldMapID = 26,
                MinimumLevel = 60,
                WaypointCode = "[&BD8FAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Sorrow%27s_Embrace",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = SorrowsEmbracePathID.Story,
                                InstanceMapID = 63,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(127.33, -278.88, 93.87),
                                IdentifyingPoints = new List<Point>(),
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 50
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = SorrowsEmbracePathID.P1,
                                InstanceMapID = 64,
                                PathDisplayText = "P1",
                                GoldReward = 1.05,
                                EndPoint = new Point(351.03, -105, 143.36),
                                IdentifyingPoints = new List<Point> { new Point(-127.39, -66.08, 162.89) },
                                CompletionPrereqPoints = new List<Point> { new Point(140.32, -93.57, 146.54), new Point(314.68, -66.11, 145.38) },
                                PointDetectionRadius = 40
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = SorrowsEmbracePathID.P2,
                                InstanceMapID = 64,
                                PathDisplayText = "P2",
                                GoldReward = 1.05,
                                EndPoint = new Point(144.48, 41.61, 143.45),
                                IdentifyingPoints = new List<Point> { new Point(-284.01, 127.53, 208.49), new Point(-148.10, 133.50, 215.23), new Point(-98.59, 144.75, 210.99) },
                                CompletionPrereqPoints = new List<Point> { new Point(52.09, 252.63, 158.12), new Point(-93.22, 215.05, 211.13), new Point(126.65, 177.83, 169.37) },
                                PointDetectionRadius = 40
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = SorrowsEmbracePathID.P3,
                                InstanceMapID = 64,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(-273.58, -276.91, 200.99),
                                IdentifyingPoints = new List<Point> { new Point(-212.97, 42.87, 208.36) },
                                CompletionPrereqPoints = new List<Point> { new Point(-255.91, -133.49, 168.24), new Point(-299.31, -199.87, 173.39) },
                                PointDetectionRadius = 50
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Citadel of Flame",
                ID = DungeonID.CitadelOfFlame,
                WorldMapID = 22,
                MinimumLevel = 70,
                WaypointCode = "[&BEAFAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Citadel_of_Flame",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = CitadelOfFlamePathID.Story,
                                InstanceMapID = 66,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(76.62, 69.63, 146.58),
                                IdentifyingPoints = new List<Point>(),
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 25
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = CitadelOfFlamePathID.P1,
                                InstanceMapID = 69,
                                PathDisplayText = "P1",
                                GoldReward = 1.05,
                                EndPoint = new Point(42.12, 302.69, 121.63),
                                IdentifyingPoints = new List<Point> { new Point(-185.25, 37.26, 75.86) },
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = CitadelOfFlamePathID.P2,
                                InstanceMapID = 69,
                                PathDisplayText = "P2",
                                GoldReward = 1.05,
                                EndPoint = new Point(328.02, -17.45, 101.33),
                                IdentifyingPoints = new List<Point> { new Point(-9.03, -147.03, 73.00) },
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = CitadelOfFlamePathID.P3,
                                InstanceMapID = 69,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(255.89, 278.00, 128.17),
                                IdentifyingPoints = new List<Point> { new Point(-25.65, -79.68, 8.89) },
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 35
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Honor of the Waves",
                ID = DungeonID.HonorOfTheWaves,
                WorldMapID = 30,
                MinimumLevel = 76,
                WaypointCode = "[&BEMFAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Honor_of_the_Waves",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = HonorOfTheWavesPathID.Story,
                                InstanceMapID = 70,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(106.65, 25.35, 5.11),
                                IdentifyingPoints = new List<Point>(),
                                CompletionPrereqPoints = new List<Point> { new Point(-158.16, 7.04, 54.48), new Point(-56.92, 77.66, 55.01), new Point(-166.32, 235.24, 40.23) },
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = HonorOfTheWavesPathID.P1,
                                InstanceMapID = 71,
                                PathDisplayText = "P1",
                                GoldReward = 1.05,
                                EndPoint = new Point(-67.77, -68.20, 18.95),
                                IdentifyingPoints = new List<Point> { new Point(-119.83, 159.85, 38.57) },
                                CompletionPrereqPoints = new List<Point> { new Point(-119.83, 159.85, 38.57), new Point(-15.81, 174.86, 35.39) },
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = HonorOfTheWavesPathID.P2,
                                InstanceMapID = 71,
                                PathDisplayText = "P2",
                                GoldReward = 1.05,
                                EndPoint = new Point(-158.60, 141.23, -36.51),
                                IdentifyingPoints = new List<Point> { new Point(-10.70, 4.73, 55.70) },
                                CompletionPrereqPoints = new List<Point> { new Point(10.92, -32.10, 59.07), new Point(131.86, 99.55, 42.87), new Point(20.38, 17.66, 7.87) },
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = HonorOfTheWavesPathID.P3,
                                InstanceMapID = 71,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(-100.96, 11.86, -18.29),
                                IdentifyingPoints = new List<Point> { new Point(-199.69, 197.26, 43.96) },
                                CompletionPrereqPoints = new List<Point> { new Point(-199.69, 197.26, 43.96), new Point(-168.98, 232.75, 40.52) },
                                PointDetectionRadius = 35
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Crucible of Eternity",
                ID = DungeonID.CrucibleOfEternity,
                WorldMapID = 39,
                MinimumLevel = 78,
                WaypointCode = "[&BEIFAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Crucible_of_Eternity",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = CrucibleOfEternityPathID.Story,
                                InstanceMapID = 81,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(34.60, 37.36, 115.80),
                                IdentifyingPoints = new List<Point>(),
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = CrucibleOfEternityPathID.P1,
                                InstanceMapID = 82,
                                PathDisplayText = "P1",
                                GoldReward = 1.05,
                                EndPoint = new Point(131.17, 126.65, 188.48),
                                IdentifyingPoints = new List<Point> { new Point(170.98, -94.73, 176.74) },
                                CompletionPrereqPoints = new List<Point> { new Point(170.98, -94.73, 176.74), new Point(238.30, 181.81, 191.84) },
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = CrucibleOfEternityPathID.P2,
                                InstanceMapID = 82,
                                PathDisplayText = "P2",
                                GoldReward = 1.05,
                                EndPoint = new Point(-74.92, 357.91, 224.40),
                                IdentifyingPoints = new List<Point> { new Point(37.20, 355.87, 226.81) },
                                CompletionPrereqPoints = new List<Point> { new Point(37.20, 355.87, 226.81), new Point(-70.33, 341.65, 226.94) },
                                PointDetectionRadius = 35
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = CrucibleOfEternityPathID.P3,
                                InstanceMapID = 82,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(96.01, -17.57, 237.59),
                                IdentifyingPoints = new List<Point> { new Point(11.66, 295.33, 222.84) },
                                CompletionPrereqPoints = new List<Point> { new Point(-139.68, 230.29, 228.39), new Point(-138.14, 149.17, 212.75) },
                                PointDetectionRadius = 35
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Ruined City of Arah",
                ID = DungeonID.RuinedCityOfArah,
                WorldMapID = 62,
                MinimumLevel = 80,
                WaypointCode = "[&BCADAAA=]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/The_Ruined_City_of_Arah",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = RuinedCityOfArahPathID.Story,
                                InstanceMapID = 111,
                                PathDisplayText = "S",
                                GoldReward = 0.5,
                                EndPoint = new Point(232.46, 380.78, 267.93),
                                IdentifyingPoints = new List<Point>(),
                                CompletionPrereqPoints = new List<Point>(),
                                PointDetectionRadius = 50
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = RuinedCityOfArahPathID.P1,
                                InstanceMapID = 112,
                                PathDisplayText = "P1",
                                GoldReward = 3.05,
                                EndPoint = new Point(-326.06, -433.39, 77.44),
                                IdentifyingPoints = new List<Point> { new Point(-403.28, 125.72, 3.90) },
                                CompletionPrereqPoints = new List<Point> { new Point(-458.61, 498.61, 4.52), new Point(-217.27, 206.56, 16.10), new Point(21.30, 25.55, 0.46) },
                                PointDetectionRadius = 40
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = RuinedCityOfArahPathID.P2,
                                InstanceMapID = 112,
                                PathDisplayText = "P2",
                                GoldReward = 3.05,
                                EndPoint = new Point(-22.21, 384.75, 16.64),
                                IdentifyingPoints = new List<Point> { new Point(-245.42, 86.82, -0.18) },
                                CompletionPrereqPoints = new List<Point> { new Point(-161.97, 568.74, 3.23), new Point(-0.02, 30.27, 0.49), new Point(406.77, 463.74, 1.15) },
                                PointDetectionRadius = 40
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = RuinedCityOfArahPathID.P3,
                                InstanceMapID = 112,
                                PathDisplayText = "P3",
                                GoldReward = 1.05,
                                EndPoint = new Point(-292.70, 347.14, 33.38),
                                IdentifyingPoints = new List<Point> { new Point(-400.14, -37.66, -0.18) },
                                CompletionPrereqPoints = new List<Point> { new Point(-529.60, -107.58, 4.31), new Point(-388.37, -146.76, 4.29), new Point(3.30, 31.31, 0.49) },
                                PointDetectionRadius = 40
                            },
                            new DungeonPath()
                            {
                                PathNumber = 4,
                                ID = RuinedCityOfArahPathID.P4,
                                InstanceMapID = 112,
                                PathDisplayText = "P4",
                                GoldReward = 3.05,
                                EndPoint = new Point(34.37, -536.42, 1.25),
                                IdentifyingPoints = new List<Point> { new Point(-266.70, 27.39, 1.62) },
                                CompletionPrereqPoints = new List<Point> { new Point(-168.28, -158.47, -0.12), new Point(-313.91, -119.35, 6.16), new Point(434.52, -122.77, 18.49) },
                                PointDetectionRadius = 40
                            }
                        }
            });
            dTable.Dungeons.Add(new Dungeon()
            {
                Name = "Fractals of the Mists",
                ID = DungeonID.FractalsOfTheMists,
                WorldMapID = 50,
                MinimumLevel = 1,
                WaypointCode = "[TBD]",
                WikiUrl = "http://wiki.guildwars2.com/wiki/Fractals_of_the_Mists",
                Paths = new List<DungeonPath>() 
                        { 
                            new DungeonPath()
                            {
                                PathNumber = 0,
                                ID = FractalsOfTheMistsPathID.Tier0,
                                PathDisplayText = "10",
                                GoldReward = 0
                            },
                            new DungeonPath()
                            {
                                PathNumber = 1,
                                ID = FractalsOfTheMistsPathID.Tier1,
                                PathDisplayText = "20",
                                GoldReward = 0
                            },
                            new DungeonPath()
                            {
                                PathNumber = 2,
                                ID = FractalsOfTheMistsPathID.Tier2,
                                PathDisplayText = "30",
                                GoldReward = 0
                            },
                            new DungeonPath()
                            {
                                PathNumber = 3,
                                ID = FractalsOfTheMistsPathID.Tier3,
                                PathDisplayText = "40",
                                GoldReward = 0
                            },
                            new DungeonPath()
                            {
                                PathNumber = 4,
                                ID = FractalsOfTheMistsPathID.Tier4,
                                PathDisplayText = "50",
                                GoldReward = 0
                            },
                        }
            });

            XmlSerializer serializer = new XmlSerializer(typeof(DungeonsTable));
            TextWriter textWriter = new StreamWriter(FileName);
            try
            {
                serializer.Serialize(textWriter, dTable);
            }
            finally
            {
                textWriter.Close();
            }
        }
    }
}