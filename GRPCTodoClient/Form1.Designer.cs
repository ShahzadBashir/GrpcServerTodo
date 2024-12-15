namespace GRPCTodoClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddTodo = new Button();
            txtTodoTitle = new TextBox();
            btnStartStreaming = new Button();
            SuspendLayout();
            // 
            // btnAddTodo
            // 
            btnAddTodo.Location = new Point(562, 138);
            btnAddTodo.Name = "btnAddTodo";
            btnAddTodo.Size = new Size(112, 34);
            btnAddTodo.TabIndex = 0;
            btnAddTodo.Text = "Add Todo";
            btnAddTodo.UseVisualStyleBackColor = true;
            btnAddTodo.Click += btnAddTodo_ClickAsync;
            // 
            // txtTodoTitle
            // 
            txtTodoTitle.Location = new Point(12, 138);
            txtTodoTitle.Name = "txtTodoTitle";
            txtTodoTitle.Size = new Size(544, 31);
            txtTodoTitle.TabIndex = 1;
            // 
            // btnStartStreaming
            // 
            btnStartStreaming.Location = new Point(225, 255);
            btnStartStreaming.Name = "btnStartStreaming";
            btnStartStreaming.Size = new Size(352, 73);
            btnStartStreaming.TabIndex = 2;
            btnStartStreaming.Text = "Stream";
            btnStartStreaming.UseVisualStyleBackColor = true;
            btnStartStreaming.Click += btnStartStreaming_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStartStreaming);
            Controls.Add(txtTodoTitle);
            Controls.Add(btnAddTodo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddTodo;
        private TextBox txtTodoTitle;
        private Button btnStartStreaming;
    }
}
