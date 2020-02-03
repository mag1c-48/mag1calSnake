using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace SnakeGame
{
	public class Form1 : Form
	{
		private List<Circle> Snake = new List<Circle>();

		private Circle food = new Circle();

		private int HighScore = 0;

		private IContainer components = null;

		private PictureBox pbCanvas;

		private Label label1;

		private Label label2;

		private Label label3;

		private System.Windows.Forms.Timer gameTimer;

		private Label label4;

		private Label label5;

		private Label label6;

		public Form1()
		{
			this.InitializeComponent();
			Settings setting = new Settings();
			this.gameTimer.Interval = 1000 / Settings.Speed;
			this.gameTimer.Tick += new EventHandler(this.updateScreen);
			this.gameTimer.Start();
			this.label3.Visible = false;
			this.label6.Text = "Welcome to mag1cal Snek \nPress Enter to start";
		}

		private void die()
		{
			this.PlayFile("C:\\Users\\matsp\\source\\repos\\mag1cRecovered\\SnakeGame\\sounds\\gameover.mp3");
			if (Settings.Score > this.HighScore)
			{
				this.HighScore = Settings.Score;
				this.label5.Text = this.HighScore.ToString();
			}
			Settings.GameOver = true;
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void eat()
		{
			Circle circle = new Circle()
			{
				X = this.Snake[this.Snake.Count - 1].X,
				Y = this.Snake[this.Snake.Count - 1].Y
			};
			this.PlayFile("C:\\Users\\matsp\\source\\repos\\mag1cRecovered\\SnakeGame\\sounds\\bite.mp3");
			this.Snake.Add(circle);
			Settings.Score = Settings.Score + Settings.Points;
			if (Settings.Speed < 40)
			{
				Settings.Speed = Settings.Speed + 5;
				this.gameTimer.Interval = 1000 / Settings.Speed;
			}
			this.label2.Text = Settings.Score.ToString();
			this.generateFood();
		}

		private void generateFood()
		{
			System.Drawing.Size size = this.pbCanvas.Size;
			int width = size.Width / Settings.Width;
			size = this.pbCanvas.Size;
			int height = size.Height / Settings.Height - 1;
			Random random = new Random();
			this.food = new Circle()
			{
				X = random.Next(0, width),
				Y = random.Next(0, height)
			};
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pbCanvas = new PictureBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			((ISupportInitialize)this.pbCanvas).BeginInit();
			base.SuspendLayout();
			this.pbCanvas.AccessibleName = "Default";
			this.pbCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.pbCanvas.BackColor = Color.Cyan;
			this.pbCanvas.Location = new Point(13, 13);
			this.pbCanvas.Name = "pbCanvas";
			this.pbCanvas.Size = new System.Drawing.Size(882, 604);
			this.pbCanvas.TabIndex = 0;
			this.pbCanvas.TabStop = false;
			this.pbCanvas.Paint += new PaintEventHandler(this.updateGraphics);
			this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Cyan;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(728, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "Score:";
			this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Cyan;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(823, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 29);
			this.label2.TabIndex = 2;
			this.label2.Text = "00";
			this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Black;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Yellow;
			this.label3.Location = new Point(360, 335);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 29);
			this.label3.TabIndex = 3;
			this.label3.Text = "End Text";
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.Cyan;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(23, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(150, 29);
			this.label4.TabIndex = 4;
			this.label4.Text = "High Score:";
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Cyan;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(179, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 29);
			this.label5.TabIndex = 5;
			this.label5.Text = "00";
			this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			this.label6.AutoSize = true;
			this.label6.BackColor = Color.Black;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.ForeColor = Color.Yellow;
			this.label6.Location = new Point(325, 265);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(125, 29);
			this.label6.TabIndex = 6;
			this.label6.Text = "Start Text";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(907, 623);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pbCanvas);
			base.Name = "Form1";
			this.Text = "mag1calSnek";
			base.KeyDown += new KeyEventHandler(this.keyisdown);
			base.KeyUp += new KeyEventHandler(this.keyisup);
			((ISupportInitialize)this.pbCanvas).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void keyisdown(object sender, KeyEventArgs e)
		{
			Input.changeState(e.KeyCode, true);
		}

		private void keyisup(object sender, KeyEventArgs e)
		{
			Input.changeState(e.KeyCode, false);
		}

		private void movePlayer()
		{
			for (int i = this.Snake.Count - 1; i >= 0; i--)
			{
				if (i != 0)
				{
					this.Snake[i].X = this.Snake[i - 1].X;
					this.Snake[i].Y = this.Snake[i - 1].Y;
				}
				else
				{
					switch (Settings.direction)
					{
						case Directions.Left:
						{
							Circle item = this.Snake[i];
							item.X = item.X - 1;
							break;
						}
						case Directions.Right:
						{
							Circle x = this.Snake[i];
							x.X = x.X + 1;
							break;
						}
						case Directions.Down:
						{
							Circle y = this.Snake[i];
							y.Y = y.Y + 1;
							break;
						}
						case Directions.Up:
						{
							Circle circle = this.Snake[i];
							circle.Y = circle.Y - 1;
							break;
						}
					}
					System.Drawing.Size size = this.pbCanvas.Size;
					int width = size.Width / Settings.Width;
					size = this.pbCanvas.Size;
					int height = size.Height / Settings.Height - 1;
					if ((this.Snake[i].X < 0 || this.Snake[i].Y < 0 || this.Snake[i].X > width ? true : this.Snake[i].Y > height))
					{
						this.die();
					}
					for (int j = 1; j < this.Snake.Count; j++)
					{
						if ((this.Snake[i].X != this.Snake[j].X ? false : this.Snake[i].Y == this.Snake[j].Y))
						{
							this.die();
						}
					}
					if ((this.Snake[0].X != this.food.X ? false : this.Snake[0].Y == this.food.Y))
					{
						this.eat();
					}
				}
			}
		}

		private void PlayFile(string url)
		{
			WindowsMediaPlayer variable = (WindowsMediaPlayer)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6")));
			variable.URL = url;
			variable.controls.play();
		}

		private void startGame()
		{
			Settings.Speed = 20;
			this.gameTimer.Interval = 1000 / Settings.Speed;
			this.label3.Visible = false;
			Thread.Sleep(300);
			Settings setting = new Settings();
			this.Snake.Clear();
			Circle circle = new Circle()
			{
				X = 10,
				Y = 5
			};
			this.Snake.Add(circle);
			this.label2.Text = Settings.Score.ToString();
			this.generateFood();
		}

		private void updateGraphics(object sender, PaintEventArgs e)
		{
			Brush green;
			Brush red;
			Graphics graphics = e.Graphics;
			if (Settings.GameOver)
			{
				string[] str = new string[] { "Game Over \nFinal Score is ", null, null, null, null };
				str[1] = Settings.Score.ToString();
				str[2] = "\nHigh Score is ";
				str[3] = this.HighScore.ToString();
				str[4] = "\nPress enter to Restart \n";
				string str1 = string.Concat(str);
				this.label3.Text = str1;
				this.label3.Visible = true;
			}
			else
			{
				for (int i = 0; i < this.Snake.Count; i++)
				{
					if (i != 0)
					{
						green = Brushes.Green;
						red = Brushes.Red;
					}
					else
					{
						green = Brushes.Black;
						red = Brushes.Red;
					}
					graphics.FillEllipse(green, new Rectangle(this.Snake[i].X * Settings.Width, this.Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
					graphics.FillEllipse(red, new Rectangle(this.food.X * Settings.Width, this.food.Y * Settings.Height, Settings.Width, Settings.Height));
				}
			}
		}

		private void updateScreen(object sender, EventArgs e)
		{
			if (Input.KeyPress(Keys.Return))
			{
				this.label6.Visible = false;
				this.startGame();
			}
			if (!Settings.GameOver)
			{
				if ((!Input.KeyPress(Keys.Right) ? false : Settings.direction != Directions.Left))
				{
					Settings.direction = Directions.Right;
				}
				else if ((!Input.KeyPress(Keys.Left) ? false : Settings.direction != Directions.Right))
				{
					Settings.direction = Directions.Left;
				}
				else if ((!Input.KeyPress(Keys.Up) ? false : Settings.direction != Directions.Down))
				{
					Settings.direction = Directions.Up;
				}
				else if ((!Input.KeyPress(Keys.Down) ? false : Settings.direction != Directions.Up))
				{
					Settings.direction = Directions.Down;
				}
				this.movePlayer();
			}
			else if (Input.KeyPress(Keys.Return))
			{
				this.startGame();
			}
			this.pbCanvas.Invalidate();
		}
	}
}