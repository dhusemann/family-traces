namespace Family_Traces
{
    partial class FamilyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butHusbandParents = new System.Windows.Forms.Button();
            this.txtHusbandDiedDate = new System.Windows.Forms.TextBox();
            this.txtHusbandBornDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHusbandDiedPlace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHusbandBornPlace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHusbandName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butWifeParents = new System.Windows.Forms.Button();
            this.txtWifeDiedDate = new System.Windows.Forms.TextBox();
            this.txtWifeBornDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWifeDiedPlace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWifeBornPlace = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWifeName = new System.Windows.Forms.TextBox();
            this.txtMarriedDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMariedPlace = new System.Windows.Forms.TextBox();
            this.grdChildren = new System.Windows.Forms.DataGridView();
            this.ChildId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChildName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Born = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Died = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attachSpouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attachChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detachSpouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detachChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ancestorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbrBack = new System.Windows.Forms.ToolStripButton();
            this.excelAncestryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildren)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butHusbandParents);
            this.groupBox1.Controls.Add(this.txtHusbandDiedDate);
            this.groupBox1.Controls.Add(this.txtHusbandBornDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHusbandDiedPlace);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHusbandBornPlace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHusbandName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Husband";
            // 
            // butHusbandParents
            // 
            this.butHusbandParents.Location = new System.Drawing.Point(430, 16);
            this.butHusbandParents.Name = "butHusbandParents";
            this.butHusbandParents.Size = new System.Drawing.Size(22, 20);
            this.butHusbandParents.TabIndex = 10;
            this.butHusbandParents.Text = "P";
            this.butHusbandParents.UseVisualStyleBackColor = true;
            this.butHusbandParents.Click += new System.EventHandler(this.butHusbandParents_Click);
            // 
            // txtHusbandDiedDate
            // 
            this.txtHusbandDiedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHusbandDiedDate.Location = new System.Drawing.Point(53, 62);
            this.txtHusbandDiedDate.Name = "txtHusbandDiedDate";
            this.txtHusbandDiedDate.Size = new System.Drawing.Size(133, 20);
            this.txtHusbandDiedDate.TabIndex = 3;
            this.txtHusbandDiedDate.Leave += new System.EventHandler(this.txtHusbandDiedDate_Leave);
            this.txtHusbandDiedDate.Enter += new System.EventHandler(this.txtHusbandDiedDate_Enter);
            // 
            // txtHusbandBornDate
            // 
            this.txtHusbandBornDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHusbandBornDate.Location = new System.Drawing.Point(53, 39);
            this.txtHusbandBornDate.Name = "txtHusbandBornDate";
            this.txtHusbandBornDate.Size = new System.Drawing.Size(133, 20);
            this.txtHusbandBornDate.TabIndex = 1;
            this.txtHusbandBornDate.Leave += new System.EventHandler(this.txtHusbandBornDate_Leave);
            this.txtHusbandBornDate.Enter += new System.EventHandler(this.txtHusbandBornDate_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "in";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Died:";
            // 
            // txtHusbandDiedPlace
            // 
            this.txtHusbandDiedPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHusbandDiedPlace.Location = new System.Drawing.Point(213, 61);
            this.txtHusbandDiedPlace.Name = "txtHusbandDiedPlace";
            this.txtHusbandDiedPlace.Size = new System.Drawing.Size(352, 20);
            this.txtHusbandDiedPlace.TabIndex = 4;
            this.txtHusbandDiedPlace.Leave += new System.EventHandler(this.txtHusbandDiedPlace_Leave);
            this.txtHusbandDiedPlace.Enter += new System.EventHandler(this.txtHusbandDiedPlace_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "in";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Born:";
            // 
            // txtHusbandBornPlace
            // 
            this.txtHusbandBornPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHusbandBornPlace.Location = new System.Drawing.Point(213, 39);
            this.txtHusbandBornPlace.Name = "txtHusbandBornPlace";
            this.txtHusbandBornPlace.Size = new System.Drawing.Size(352, 20);
            this.txtHusbandBornPlace.TabIndex = 2;
            this.txtHusbandBornPlace.Leave += new System.EventHandler(this.txtHusbandBornPlace_Leave);
            this.txtHusbandBornPlace.Enter += new System.EventHandler(this.txtHusbandBornPlace_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // txtHusbandName
            // 
            this.txtHusbandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHusbandName.Location = new System.Drawing.Point(53, 16);
            this.txtHusbandName.Name = "txtHusbandName";
            this.txtHusbandName.Size = new System.Drawing.Size(371, 20);
            this.txtHusbandName.TabIndex = 0;
            this.txtHusbandName.Leave += new System.EventHandler(this.txtHusbandName_Leave);
            this.txtHusbandName.Enter += new System.EventHandler(this.txtHusbandName_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butWifeParents);
            this.groupBox2.Controls.Add(this.txtWifeDiedDate);
            this.groupBox2.Controls.Add(this.txtWifeBornDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtWifeDiedPlace);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtWifeBornPlace);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtWifeName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 91);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wife";
            // 
            // butWifeParents
            // 
            this.butWifeParents.Location = new System.Drawing.Point(430, 16);
            this.butWifeParents.Name = "butWifeParents";
            this.butWifeParents.Size = new System.Drawing.Size(22, 20);
            this.butWifeParents.TabIndex = 15;
            this.butWifeParents.Text = "P";
            this.butWifeParents.UseVisualStyleBackColor = true;
            this.butWifeParents.Click += new System.EventHandler(this.butWifeParents_Click);
            // 
            // txtWifeDiedDate
            // 
            this.txtWifeDiedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWifeDiedDate.Location = new System.Drawing.Point(53, 62);
            this.txtWifeDiedDate.Name = "txtWifeDiedDate";
            this.txtWifeDiedDate.Size = new System.Drawing.Size(133, 20);
            this.txtWifeDiedDate.TabIndex = 13;
            this.txtWifeDiedDate.Leave += new System.EventHandler(this.txtWifeDiedDate_Leave);
            this.txtWifeDiedDate.Enter += new System.EventHandler(this.txtWifeDiedDate_Enter);
            // 
            // txtWifeBornDate
            // 
            this.txtWifeBornDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWifeBornDate.Location = new System.Drawing.Point(53, 39);
            this.txtWifeBornDate.Name = "txtWifeBornDate";
            this.txtWifeBornDate.Size = new System.Drawing.Size(133, 20);
            this.txtWifeBornDate.TabIndex = 11;
            this.txtWifeBornDate.Leave += new System.EventHandler(this.txtWifeBornDate_Leave);
            this.txtWifeBornDate.Enter += new System.EventHandler(this.txtWifeBornDate_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(192, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "in";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Died:";
            // 
            // txtWifeDiedPlace
            // 
            this.txtWifeDiedPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWifeDiedPlace.Location = new System.Drawing.Point(213, 61);
            this.txtWifeDiedPlace.Name = "txtWifeDiedPlace";
            this.txtWifeDiedPlace.Size = new System.Drawing.Size(352, 20);
            this.txtWifeDiedPlace.TabIndex = 14;
            this.txtWifeDiedPlace.Leave += new System.EventHandler(this.txtWifeDiedPlace_Leave);
            this.txtWifeDiedPlace.Enter += new System.EventHandler(this.txtWifeDiedPlace_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(192, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "in";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Born:";
            // 
            // txtWifeBornPlace
            // 
            this.txtWifeBornPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWifeBornPlace.Location = new System.Drawing.Point(213, 39);
            this.txtWifeBornPlace.Name = "txtWifeBornPlace";
            this.txtWifeBornPlace.Size = new System.Drawing.Size(352, 20);
            this.txtWifeBornPlace.TabIndex = 12;
            this.txtWifeBornPlace.Leave += new System.EventHandler(this.txtWifeBornPlace_Leave);
            this.txtWifeBornPlace.Enter += new System.EventHandler(this.txtWifeBornPlace_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Name:";
            // 
            // txtWifeName
            // 
            this.txtWifeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWifeName.Location = new System.Drawing.Point(53, 16);
            this.txtWifeName.Name = "txtWifeName";
            this.txtWifeName.Size = new System.Drawing.Size(371, 20);
            this.txtWifeName.TabIndex = 10;
            this.txtWifeName.Leave += new System.EventHandler(this.txtWifeName_Leave);
            this.txtWifeName.Enter += new System.EventHandler(this.txtWifeName_Enter);
            // 
            // txtMarriedDate
            // 
            this.txtMarriedDate.Location = new System.Drawing.Point(53, 223);
            this.txtMarriedDate.Name = "txtMarriedDate";
            this.txtMarriedDate.Size = new System.Drawing.Size(133, 20);
            this.txtMarriedDate.TabIndex = 15;
            this.txtMarriedDate.Leave += new System.EventHandler(this.txtMarriedDate_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "in";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Married:";
            // 
            // txtMariedPlace
            // 
            this.txtMariedPlace.Location = new System.Drawing.Point(213, 223);
            this.txtMariedPlace.Name = "txtMariedPlace";
            this.txtMariedPlace.Size = new System.Drawing.Size(350, 20);
            this.txtMariedPlace.TabIndex = 16;
            this.txtMariedPlace.Leave += new System.EventHandler(this.txtMariedPlace_Leave);
            // 
            // grdChildren
            // 
            this.grdChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChildren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChildId,
            this.ChildName,
            this.Sex,
            this.Born,
            this.Died});
            this.grdChildren.Location = new System.Drawing.Point(0, 272);
            this.grdChildren.Name = "grdChildren";
            this.grdChildren.Size = new System.Drawing.Size(571, 136);
            this.grdChildren.TabIndex = 20;
            this.grdChildren.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdChildren_CellLeave);
            this.grdChildren.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdChildren_CellContentDoubleClick);
            this.grdChildren.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdChildren_CellEndEdit);
            this.grdChildren.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ChildId
            // 
            this.ChildId.HeaderText = "Id";
            this.ChildId.Name = "ChildId";
            this.ChildId.Visible = false;
            // 
            // ChildName
            // 
            this.ChildName.HeaderText = "Name";
            this.ChildName.Name = "ChildName";
            // 
            // Sex
            // 
            this.Sex.HeaderText = "Sex";
            this.Sex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.Sex.Name = "Sex";
            // 
            // Born
            // 
            this.Born.HeaderText = "Born";
            this.Born.Name = "Born";
            this.Born.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Born.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Died
            // 
            this.Died.HeaderText = "Died";
            this.Died.Name = "Died";
            this.Died.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Died.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Children";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(424, 245);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(198, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexToolStripMenuItem,
            this.addNewIndividualToolStripMenuItem,
            this.attachSpouseToolStripMenuItem,
            this.attachChildToolStripMenuItem,
            this.detachSpouseToolStripMenuItem,
            this.detachChildToolStripMenuItem,
            this.deleteIndividualToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.indexToolStripMenuItem.Text = "&Index...";
            this.indexToolStripMenuItem.Click += new System.EventHandler(this.indexToolStripMenuItem_Click);
            // 
            // addNewIndividualToolStripMenuItem
            // 
            this.addNewIndividualToolStripMenuItem.Name = "addNewIndividualToolStripMenuItem";
            this.addNewIndividualToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addNewIndividualToolStripMenuItem.Text = "Add &New Individual";
            this.addNewIndividualToolStripMenuItem.Click += new System.EventHandler(this.addNewIndividualToolStripMenuItem_Click);
            // 
            // attachSpouseToolStripMenuItem
            // 
            this.attachSpouseToolStripMenuItem.Name = "attachSpouseToolStripMenuItem";
            this.attachSpouseToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.attachSpouseToolStripMenuItem.Text = "Attach &Spouse";
            this.attachSpouseToolStripMenuItem.Click += new System.EventHandler(this.attachSpouseToolStripMenuItem_Click);
            // 
            // attachChildToolStripMenuItem
            // 
            this.attachChildToolStripMenuItem.Name = "attachChildToolStripMenuItem";
            this.attachChildToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.attachChildToolStripMenuItem.Text = "Attach &Child";
            this.attachChildToolStripMenuItem.Click += new System.EventHandler(this.attachChildToolStripMenuItem_Click);
            // 
            // detachSpouseToolStripMenuItem
            // 
            this.detachSpouseToolStripMenuItem.Name = "detachSpouseToolStripMenuItem";
            this.detachSpouseToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.detachSpouseToolStripMenuItem.Text = "Detach Spouse";
            this.detachSpouseToolStripMenuItem.Click += new System.EventHandler(this.detachSpouseToolStripMenuItem_Click);
            // 
            // detachChildToolStripMenuItem
            // 
            this.detachChildToolStripMenuItem.Name = "detachChildToolStripMenuItem";
            this.detachChildToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.detachChildToolStripMenuItem.Text = "Detach Child";
            this.detachChildToolStripMenuItem.Click += new System.EventHandler(this.detachChildToolStripMenuItem_Click);
            // 
            // deleteIndividualToolStripMenuItem
            // 
            this.deleteIndividualToolStripMenuItem.Name = "deleteIndividualToolStripMenuItem";
            this.deleteIndividualToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.deleteIndividualToolStripMenuItem.Text = "&Delete Individual";
            this.deleteIndividualToolStripMenuItem.Click += new System.EventHandler(this.deleteIndividualToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ancestorsToolStripMenuItem,
            this.descendantsToolStripMenuItem,
            this.excelAncestryToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // ancestorsToolStripMenuItem
            // 
            this.ancestorsToolStripMenuItem.Name = "ancestorsToolStripMenuItem";
            this.ancestorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ancestorsToolStripMenuItem.Text = "&Ancestors";
            this.ancestorsToolStripMenuItem.Click += new System.EventHandler(this.ancestorsToolStripMenuItem_Click);
            // 
            // descendantsToolStripMenuItem
            // 
            this.descendantsToolStripMenuItem.Name = "descendantsToolStripMenuItem";
            this.descendantsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.descendantsToolStripMenuItem.Text = "&Descendants";
            this.descendantsToolStripMenuItem.Click += new System.EventHandler(this.descendantsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbrBack});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbrBack
            // 
            this.tbrBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrBack.Enabled = false;
            this.tbrBack.Image = ((System.Drawing.Image)(resources.GetObject("tbrBack.Image")));
            this.tbrBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrBack.Name = "tbrBack";
            this.tbrBack.Size = new System.Drawing.Size(23, 22);
            this.tbrBack.Text = "tbrBack";
            this.tbrBack.Click += new System.EventHandler(this.tbrBack_Click);
            // 
            // excelAncestryToolStripMenuItem
            // 
            this.excelAncestryToolStripMenuItem.Name = "excelAncestryToolStripMenuItem";
            this.excelAncestryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excelAncestryToolStripMenuItem.Text = "&Excel Ancestry";
            // 
            // FamilyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 420);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.grdChildren);
            this.Controls.Add(this.txtMarriedDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMariedPlace);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FamilyForm";
            this.Text = "Family";
            this.Load += new System.EventHandler(this.FamilyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildren)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHusbandName;
        private System.Windows.Forms.TextBox txtHusbandDiedDate;
        private System.Windows.Forms.TextBox txtHusbandBornDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHusbandDiedPlace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHusbandBornPlace;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtWifeDiedDate;
        private System.Windows.Forms.TextBox txtWifeBornDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWifeDiedPlace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWifeBornPlace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWifeName;
        private System.Windows.Forms.TextBox txtMarriedDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMariedPlace;
        private System.Windows.Forms.DataGridView grdChildren;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChildId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChildName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Born;
        private System.Windows.Forms.DataGridViewTextBoxColumn Died;
        private System.Windows.Forms.Button butHusbandParents;
        private System.Windows.Forms.Button butWifeParents;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewIndividualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attachSpouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attachChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detachSpouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detachChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteIndividualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ancestorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbrBack;
        private System.Windows.Forms.ToolStripMenuItem descendantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelAncestryToolStripMenuItem;
    }
}