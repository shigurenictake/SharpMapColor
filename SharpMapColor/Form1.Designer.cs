namespace SharpMap_Test
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mapBox = new SharpMap.Forms.MapBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mapZoomToolStrip1 = new SharpMap.Forms.ToolBar.MapZoomToolStrip(this.components);
            this.mapDigitizeGeometriesToolStrip1 = new SharpMap.Forms.ToolBar.MapDigitizeGeometriesToolStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mapBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mapBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapBox.CustomTool = null;
            this.mapBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBox.FineZoomFactor = 10D;
            this.mapBox.Location = new System.Drawing.Point(0, 0);
            this.mapBox.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBox.Name = "mapBox";
            this.mapBox.QueryGrowFactor = 5F;
            this.mapBox.QueryLayerIndex = 0;
            this.mapBox.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox.ShowProgressUpdate = false;
            this.mapBox.Size = new System.Drawing.Size(596, 638);
            this.mapBox.TabIndex = 0;
            this.mapBox.Text = "mapBox";
            this.mapBox.WheelZoomMagnitude = -2D;
            this.mapBox.MapCenterChanged += new SharpMap.Forms.MapBox.MapCenterChangedHandler(this.mapBox_MapCenterChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mapZoomToolStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.mapDigitizeGeometriesToolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(596, 714);
            this.splitContainer1.SplitterDistance = 638;
            this.splitContainer1.TabIndex = 1;
            // 
            // mapZoomToolStrip1
            // 
            this.mapZoomToolStrip1.Enabled = false;
            this.mapZoomToolStrip1.Location = new System.Drawing.Point(0, 25);
            this.mapZoomToolStrip1.MapControl = this.mapBox;
            this.mapZoomToolStrip1.Name = "mapZoomToolStrip1";
            this.mapZoomToolStrip1.Size = new System.Drawing.Size(596, 25);
            this.mapZoomToolStrip1.TabIndex = 1;
            this.mapZoomToolStrip1.Text = "mapZoomToolStrip1";
            // 
            // mapDigitizeGeometriesToolStrip1
            // 
            this.mapDigitizeGeometriesToolStrip1.Enabled = false;
            this.mapDigitizeGeometriesToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.mapDigitizeGeometriesToolStrip1.MapControl = this.mapBox;
            this.mapDigitizeGeometriesToolStrip1.Name = "mapDigitizeGeometriesToolStrip1";
            this.mapDigitizeGeometriesToolStrip1.Size = new System.Drawing.Size(596, 25);
            this.mapDigitizeGeometriesToolStrip1.TabIndex = 0;
            this.mapDigitizeGeometriesToolStrip1.Text = "mapDigitizeGeometriesToolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 714);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public SharpMap.Forms.MapBox mapBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SharpMap.Forms.ToolBar.MapZoomToolStrip mapZoomToolStrip1;
        private SharpMap.Forms.ToolBar.MapDigitizeGeometriesToolStrip mapDigitizeGeometriesToolStrip1;
    }
}

