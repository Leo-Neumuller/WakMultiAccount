namespace MultiAccount
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.listViewWithReordering1 = new MultiAccount.ListViewWithReordering();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewWithReordering1
            // 
            this.listViewWithReordering1.AllowDrop = true;
            this.listViewWithReordering1.HideSelection = false;
            this.listViewWithReordering1.Location = new System.Drawing.Point(292, 102);
            this.listViewWithReordering1.Name = "listViewWithReordering1";
            this.listViewWithReordering1.Size = new System.Drawing.Size(334, 214);
            this.listViewWithReordering1.TabIndex = 1;
            this.listViewWithReordering1.UseCompatibleStateImageBehavior = false;
            this.listViewWithReordering1.View = System.Windows.Forms.View.List;
            this.listViewWithReordering1.DoubleClick += new System.EventHandler(this.listViewWithReordering1_DoubleClick);
            this.listViewWithReordering1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewWithReordering1_MouseDoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "delock form";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listViewWithReordering1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "multi_account";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ListViewWithReordering listViewWithReordering1;
        private System.Windows.Forms.Button button2;
    }
}

