using GeoAPI.Geometries;//SharpMap
using NetTopologySuite.Geometries;//SharpMap
using SharpMap.Data.Providers;//SharpMap
using SharpMap.Forms;
using SharpMap.Layers;//SharpMap
using SharpMap;//SharpMap
using System;
using System.Collections.Generic;//SharpMap
using System.Drawing;//SharpMap
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SharpMap.Rendering.Symbolizer;
using System.Drawing.Drawing2D;
using SharpMap.Styles;
using System.Linq;
using SharpMap.Rendering.Thematics;
using NetTopologySuite.IO;

namespace SharpMap_Test
{
    public partial class Form1 : Form
    {
        //クラス変数
        Coordinate g_worldPos = new Coordinate();                       //地理座標
        System.Drawing.Point g_imagePos = new System.Drawing.Point();   //イメージ座標
        WakeController refWakeController = new WakeController();

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            //SharpMap初期化
            this.InitializeMap();

            //Form1参照用
            refWakeController.refForm1 = this;

            //オブジェクト生成
            refWakeController.Generate();
        }

        //マップ初期化
        private void InitializeMap()
        {
            //baseLayerレイヤ初期化
            this.InitializeBaseLayer();

            //Zoom制限
            mapBox.Map.MinimumZoom = 0.1;
            mapBox.Map.MaximumZoom = 360.0;

            //レイヤ全体を表示する(全レイヤの範囲にズームする)
            mapBox.Map.ZoomToExtents();
            
            //mapBoxを再描画
            mapBox.Refresh();
        }

        //基底レイヤ初期化
        private void InitializeBaseLayer()
        {
            //Map生成
            mapBox.Map = new Map(new Size(mapBox.Width, mapBox.Height));
            mapBox.Map.BackColor = System.Drawing.Color.LightBlue;

            //レイヤーの作成
            VectorLayer baseLayer = new VectorLayer("baseLayer");
            baseLayer.DataSource = new ShapeFile(@"..\..\ShapeFiles\polbnda_jpn\polbnda_jpn.shp");
            //baseLayer.DataSource = new ShapeFile(@"..\..\ShapeFiles\ne_10m_coastline\ne_10m_coastline.shp");

            baseLayer.Style.Fill = Brushes.LimeGreen;
            baseLayer.Style.Outline = Pens.Black;
            baseLayer.Style.EnableOutline = true;

            //マップにレイヤーを追加
            mapBox.Map.Layers.Add(baseLayer);
        }

        private void mapBox_MapCenterChanged(Coordinate center)
        {
            refWakeController.RelocateLabel();
        }
    }
}
