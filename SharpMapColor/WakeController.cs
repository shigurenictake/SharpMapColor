using GeoAPI.Geometries;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WakeMap;

namespace SharpMap_Test
{
    internal class WakeController
    {
        //Form1参照用(初期化は参照側で行う)
        public Form1 refForm1 = null;

        //生成する
        public void Generate()
        {
            //JSON文字列
            string strColorList = @"
                {
                    DarkRed         : { pos0: { x: 120 , y: 47 }, pos1: { x: 130 , y: 47 } },
                    Red             : { pos0: { x: 120 , y: 46 }, pos1: { x: 130 , y: 46 } },
                    Brown           : { pos0: { x: 120 , y: 45 }, pos1: { x: 130 , y: 45 } },
                    LightCoral      : { pos0: { x: 120 , y: 44 }, pos1: { x: 130 , y: 44 } },
                    RosyBrown       : { pos0: { x: 120 , y: 43 }, pos1: { x: 130 , y: 43 } },
                    Tomato          : { pos0: { x: 120 , y: 42 }, pos1: { x: 130 , y: 42 } },
                    DarkSalmon      : { pos0: { x: 120 , y: 41 }, pos1: { x: 130 , y: 41 } },
                    Sienna          : { pos0: { x: 120 , y: 40 }, pos1: { x: 130 , y: 40 } },
                    Chocolate       : { pos0: { x: 120 , y: 39 }, pos1: { x: 130 , y: 39 } },
                    SaddleBrown     : { pos0: { x: 120 , y: 38 }, pos1: { x: 130 , y: 38 } },
                    SandyBrown      : { pos0: { x: 120 , y: 37 }, pos1: { x: 130 , y: 37 } },
                    DarkOrange      : { pos0: { x: 120 , y: 36 }, pos1: { x: 130 , y: 36 } },
                    BurlyWood       : { pos0: { x: 120 , y: 35 }, pos1: { x: 130 , y: 35 } },
                    Tan             : { pos0: { x: 120 , y: 34 }, pos1: { x: 130 , y: 34 } },
                    Orange          : { pos0: { x: 120 , y: 33 }, pos1: { x: 130 , y: 33 } },
                    DarkGoldenrod   : { pos0: { x: 120 , y: 32 }, pos1: { x: 130 , y: 32 } },
                    GoldenRod       : { pos0: { x: 120 , y: 31 }, pos1: { x: 130 , y: 31 } },
                    Gold            : { pos0: { x: 120 , y: 30 }, pos1: { x: 130 , y: 30 } },
                    DarkKhaki       : { pos0: { x: 120 , y: 29 }, pos1: { x: 130 , y: 29 } },
                    Olive           : { pos0: { x: 120 , y: 28 }, pos1: { x: 130 , y: 28 } },
                    Yellow          : { pos0: { x: 120 , y: 27 }, pos1: { x: 130 , y: 27 } },
                    OliveDrab       : { pos0: { x: 120 , y: 26 }, pos1: { x: 130 , y: 26 } },
                    YellowGreen     : { pos0: { x: 120 , y: 25 }, pos1: { x: 130 , y: 25 } },
                    DarkOliveGreen  : { pos0: { x: 120 , y: 24 }, pos1: { x: 130 , y: 24 } },
                    LawnGreen       : { pos0: { x: 120 , y: 23 }, pos1: { x: 130 , y: 23 } },
                    DarkSeaGreen    : { pos0: { x: 120 , y: 22 }, pos1: { x: 130 , y: 22 } },
                    LightGreen      : { pos0: { x: 120 , y: 21 }, pos1: { x: 130 , y: 21 } },
                    ForestGreen     : { pos0: { x: 120 , y: 20 }, pos1: { x: 130 , y: 20 } },
                    LimeGreen       : { pos0: { x: 120 , y: 19 }, pos1: { x: 130 , y: 19 } },
                    DarkGreen       : { pos0: { x: 120 , y: 18 }, pos1: { x: 130 , y: 18 } },
                    Green           : { pos0: { x: 135 , y: 47 }, pos1: { x: 145 , y: 47 } },
                    SeaGreen        : { pos0: { x: 135 , y: 46 }, pos1: { x: 145 , y: 46 } },
                    MediumSeaGreen  : { pos0: { x: 135 , y: 45 }, pos1: { x: 145 , y: 45 } },
                    LightSeaGreen   : { pos0: { x: 135 , y: 44 }, pos1: { x: 145 , y: 44 } },
                    DarkSlateGray   : { pos0: { x: 135 , y: 43 }, pos1: { x: 145 , y: 43 } },
                    DarkCyan        : { pos0: { x: 135 , y: 42 }, pos1: { x: 145 , y: 42 } },
                    Cyan            : { pos0: { x: 135 , y: 41 }, pos1: { x: 145 , y: 41 } },
                    Aqua            : { pos0: { x: 135 , y: 40 }, pos1: { x: 145 , y: 40 } },
                    SteelBlue       : { pos0: { x: 135 , y: 39 }, pos1: { x: 145 , y: 39 } },
                    DodgerBlue      : { pos0: { x: 135 , y: 38 }, pos1: { x: 145 , y: 38 } },
                    SlateGray       : { pos0: { x: 135 , y: 37 }, pos1: { x: 145 , y: 37 } },
                    LightSlateGray  : { pos0: { x: 135 , y: 36 }, pos1: { x: 145 , y: 36 } },
                    CornflowerBlue  : { pos0: { x: 135 , y: 35 }, pos1: { x: 145 , y: 35 } },
                    RoyalBlue       : { pos0: { x: 135 , y: 34 }, pos1: { x: 145 , y: 34 } },
                    DarkBlue        : { pos0: { x: 135 , y: 33 }, pos1: { x: 145 , y: 33 } },
                    Blue            : { pos0: { x: 135 , y: 32 }, pos1: { x: 145 , y: 32 } },
                    SlateBlue       : { pos0: { x: 135 , y: 31 }, pos1: { x: 145 , y: 31 } },
                    DarkSlateBlue   : { pos0: { x: 135 , y: 30 }, pos1: { x: 145 , y: 30 } },
                    MediumPurple    : { pos0: { x: 135 , y: 29 }, pos1: { x: 145 , y: 29 } },
                    BlueViolet      : { pos0: { x: 135 , y: 28 }, pos1: { x: 145 , y: 28 } },
                    DarkOrchid      : { pos0: { x: 135 , y: 27 }, pos1: { x: 145 , y: 27 } },
                    DarkViolet      : { pos0: { x: 135 , y: 26 }, pos1: { x: 145 , y: 26 } },
                    Violet          : { pos0: { x: 135 , y: 25 }, pos1: { x: 145 , y: 25 } },
                    Purple          : { pos0: { x: 135 , y: 24 }, pos1: { x: 145 , y: 24 } },
                    DarkMagenta     : { pos0: { x: 135 , y: 23 }, pos1: { x: 145 , y: 23 } },
                    Fuchsia         : { pos0: { x: 135 , y: 22 }, pos1: { x: 145 , y: 22 } },
                    Magenta         : { pos0: { x: 135 , y: 21 }, pos1: { x: 145 , y: 21 } },
                    Orchid          : { pos0: { x: 135 , y: 20 }, pos1: { x: 145 , y: 20 } },
                    MediumVioletRed : { pos0: { x: 135 , y: 19 }, pos1: { x: 145 , y: 19 } },
                    DeepPink        : { pos0: { x: 135 , y: 18 }, pos1: { x: 145 , y: 18 } },
                    HotPink         : { pos0: { x: 150 , y: 47 }, pos1: { x: 160 , y: 47 } },
                    PaleVioletRed   : { pos0: { x: 150 , y: 46 }, pos1: { x: 160 , y: 46 } },
                    Crimson         : { pos0: { x: 150 , y: 45 }, pos1: { x: 160 , y: 45 } },
                    Pink            : { pos0: { x: 150 , y: 44 }, pos1: { x: 160 , y: 44 } },
                    LightPink       : { pos0: { x: 150 , y: 43 }, pos1: { x: 160 , y: 43 } }
                }";
            // 文字列の空白文字を削除する
            strColorList = System.Text.RegularExpressions.Regex.Replace(strColorList, @"[\s]+", "");
            Dictionary<string, Dictionary<string, Dictionary<string, string>>> colorList = new JsonParser().ParseDictSDictSDictSS(strColorList);

            //描画する
            Draw(colorList);

            //mapBoxを再描画
            refForm1.mapBox.Refresh();
        }

        private Color ReturnColor(string strColor)
        {
            Color color = Color.Black;
            switch (strColor)
            {
                case "DarkRed"         : color = Color.DarkRed         ; break;
                case "Red"             : color = Color.Red             ; break;
                case "Brown"           : color = Color.Brown           ; break;
                case "LightCoral"      : color = Color.LightCoral      ; break;
                case "RosyBrown"       : color = Color.RosyBrown       ; break;
                case "Tomato"          : color = Color.Tomato          ; break;
                case "DarkSalmon"      : color = Color.DarkSalmon      ; break;
                case "Sienna"          : color = Color.Sienna          ; break;
                case "Chocolate"       : color = Color.Chocolate       ; break;
                case "SaddleBrown"     : color = Color.SaddleBrown     ; break;
                case "SandyBrown"      : color = Color.SandyBrown      ; break;
                case "DarkOrange"      : color = Color.DarkOrange      ; break;
                case "BurlyWood"       : color = Color.BurlyWood       ; break;
                case "Tan"             : color = Color.Tan             ; break;
                case "Orange"          : color = Color.Orange          ; break;
                case "DarkGoldenrod"   : color = Color.DarkGoldenrod   ; break;
                case "Gold"            : color = Color.Gold            ; break;
                case "DarkKhaki"       : color = Color.DarkKhaki       ; break;
                case "Olive"           : color = Color.Olive           ; break;
                case "Yellow"          : color = Color.Yellow          ; break;
                case "OliveDrab"       : color = Color.OliveDrab       ; break;
                case "YellowGreen"     : color = Color.YellowGreen     ; break;
                case "DarkOliveGreen"  : color = Color.DarkOliveGreen  ; break;
                case "LawnGreen"       : color = Color.LawnGreen       ; break;
                case "DarkSeaGreen"    : color = Color.DarkSeaGreen    ; break;
                case "LightGreen"      : color = Color.LightGreen      ; break;
                case "ForestGreen"     : color = Color.ForestGreen     ; break;
                case "LimeGreen"       : color = Color.LimeGreen       ; break;
                case "DarkGreen"       : color = Color.DarkGreen       ; break;
                case "Green"           : color = Color.Green           ; break;
                case "SeaGreen"        : color = Color.SeaGreen        ; break;
                case "MediumSeaGreen"  : color = Color.MediumSeaGreen  ; break;
                case "LightSeaGreen"   : color = Color.LightSeaGreen   ; break;
                case "DarkSlateGray"   : color = Color.DarkSlateGray   ; break;
                case "DarkCyan"        : color = Color.DarkCyan        ; break;
                case "Cyan"            : color = Color.Cyan            ; break;
                case "Aqua"            : color = Color.Aqua            ; break;
                case "SteelBlue"       : color = Color.SteelBlue       ; break;
                case "DodgerBlue"      : color = Color.DodgerBlue      ; break;
                case "SlateGray"       : color = Color.SlateGray       ; break;
                case "LightSlateGray"  : color = Color.LightSlateGray  ; break;
                case "CornflowerBlue"  : color = Color.CornflowerBlue  ; break;
                case "RoyalBlue"       : color = Color.RoyalBlue       ; break;
                case "DarkBlue"        : color = Color.DarkBlue        ; break;
                case "Blue"            : color = Color.Blue            ; break;
                case "SlateBlue"       : color = Color.SlateBlue       ; break;
                case "DarkSlateBlue"   : color = Color.DarkSlateBlue   ; break;
                case "MediumPurple"    : color = Color.MediumPurple    ; break;
                case "BlueViolet"      : color = Color.BlueViolet      ; break;
                case "DarkOrchid"      : color = Color.DarkOrchid      ; break;
                case "DarkViolet"      : color = Color.DarkViolet      ; break;
                case "Violet"          : color = Color.Violet          ; break;
                case "Purple"          : color = Color.Purple          ; break;
                case "DarkMagenta"     : color = Color.DarkMagenta     ; break;
                case "Fuchsia"         : color = Color.Fuchsia         ; break;
                case "Magenta"         : color = Color.Magenta         ; break;
                case "Orchid"          : color = Color.Orchid          ; break;
                case "MediumVioletRed" : color = Color.MediumVioletRed ; break;
                case "DeepPink"        : color = Color.DeepPink        ; break;
                case "HotPink"         : color = Color.HotPink         ; break;
                case "PaleVioletRed"   : color = Color.PaleVioletRed   ; break;
                case "Crimson"         : color = Color.Crimson         ; break;
                case "Pink"            : color = Color.Pink            ; break;
                case "LightPink"       : color = Color.LightPink       ; break;
                default: break;
            }
            return color;
        }

        //描画する
        private void Draw(Dictionary<string, Dictionary<string, Dictionary<string, string>>> colorList)
        {
            foreach (var color in colorList)
            {
                //レイヤを作成 レイヤ名 = color.Key (wake1,wake2,wake3,…)
                string layername = color.Key;
                //レイヤ生成
                VectorLayer layer = new VectorLayer(layername);
                //ジオメトリ生成
                List<IGeometry> igeoms = new List<IGeometry>();

                //座標リストを作成
                List<Coordinate> listCoordinate = new List<Coordinate>();
                //座標を取得
                foreach (var pos in color.Value)
                {
                    Coordinate coordinate = new Coordinate(double.Parse(pos.Value["x"]), double.Parse(pos.Value["y"]));
                    listCoordinate.Add(coordinate);
                }
                Coordinate[] coordinates = listCoordinate.ToArray();

                //図形生成クラス
                GeometryFactory gf = new GeometryFactory();
                //座標リストの線を生成し、ジオメトリのコレクションに追加
                igeoms.Add(gf.CreateLineString(coordinates));

                //ジオメトリをレイヤに反映
                GeometryProvider gpro = new GeometryProvider(igeoms);
                layer.DataSource = gpro;
                //スタイル設定
                layer.Style.Line = new Pen(ReturnColor(color.Key), 1.0f);
                //レイヤをmapBoxに追加
                refForm1.mapBox.Map.Layers.Add(layer);

                //ラベル生成
                GenerateLabel(coordinates[0], color.Key);
            }
        }

        //==============================================
        //ラベル操作
        public struct WakeLabel
        {
            public Label label;
            public Coordinate worldPos;
        }
        List<WakeLabel> wakeLabelList = new List<WakeLabel>();

        //ラベル生成
        private void GenerateLabel(Coordinate worldPos, string text)
        {
            //新しいラベルを生成
            Label newLabel = new Label();
            newLabel.Text = text;
            newLabel.AutoSize = true;
            newLabel.Location = System.Drawing.Point.Round(refForm1.mapBox.Map.WorldToImage(worldPos));
            //コントロールに追加
            refForm1.mapBox.Controls.Add(newLabel);
            //リストに追加
            WakeLabel wakeLabel = new WakeLabel();
            wakeLabel.label = newLabel;
            wakeLabel.worldPos = worldPos;
            wakeLabelList.Add(wakeLabel);
        }

        // ラベルをmapboxに合わせて再配置
        public void RelocateLabel()
        {
            //Console.WriteLine("RelocateLabel");
            foreach (WakeLabel wakeLabel in wakeLabelList)
            {
                System.Drawing.PointF pointf = refForm1.mapBox.Map.WorldToImage(wakeLabel.worldPos);
                System.Drawing.Point point = System.Drawing.Point.Round(pointf);
                wakeLabel.label.Location = System.Drawing.Point.Round(point);
            }
        }
        //==============================================
    }
}
