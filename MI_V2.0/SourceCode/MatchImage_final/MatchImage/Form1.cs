using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace MatchImage
{
    public partial class Form1 : Form
    {
        int[] check_picturebox_value_index = new int[20];
        int focused_picturebox_index;
        int store_second;

        public Form1()
        {
            InitializeComponent();
            initialization_form();
            //start_over();
        }

        

        Dictionary<PictureBox, int> list_picture_box_int = new Dictionary<PictureBox, int>();
        Dictionary<int, Bitmap> list_int_image = new Dictionary<int, Bitmap>();
        Dictionary<int, PictureBox> list_int_picture_box = new Dictionary<int, PictureBox>();
        Dictionary<Bitmap, int> list_image_int = new Dictionary<Bitmap, int>();
        Dictionary<Image, int> list_image_name_int = new Dictionary<Image, int>();

        bool compare_two_images(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  
            if (bmp1.Size == bmp2.Size)
            {
                for (int i=0; i<bmp1.Width;++i)
                {
                    for (int j=0; j<bmp1.Height; ++j)
                        if (bmp1.GetPixel(i, j) != bmp2.GetPixel(i, j))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    if (!flag) break;
                }
            }
            else equals = false;
            return equals;
        }

        void show_label_of_picturebox()
        {
            /*label_picturebox1.Text = list_picture_box_int[pictureBox_one].ToString();
            label_picturebox2.Text = list_picture_box_int[pictureBox_two].ToString();
            label_picturebox3.Text = list_picture_box_int[pictureBox_three].ToString();
            label_picturebox4.Text = list_picture_box_int[pictureBox_four].ToString();
            label_picturebox5.Text = list_picture_box_int[pictureBox_five].ToString();
            label_picturebox6.Text = list_picture_box_int[pictureBox_six].ToString();
            label_picturebox7.Text = list_picture_box_int[pictureBox_seven].ToString();
            label_picturebox8.Text = list_picture_box_int[pictureBox_eight].ToString();*/
        }

        void show_label_of_picturebox_image() 
        {
            //label_image1.Text = list_image_int[(Bitmap)pictureBox_one.Image].ToString();
        }

        void show_lavel_of_picturebox_and_image()
        {
            show_label_of_picturebox();
            show_label_of_picturebox_image();
        }

        void start_over()
        {
            assign_picturebox_one_to_empty_image();
            focused_picturebox_index = 1;
            assign_check_picturebox_value_index_array(-1);
            assign_image_to_all_picturebox();
            button_exit.Visible = true;
            button_reset.Visible = true;
            button_play_again.Visible = false;
        }

        bool check_all_images_match()
        {
            bool flag = true;
            //show_lavel_of_picturebox_and_image();

            if (compare_two_images((Bitmap)pictureBox_one.Image, (Bitmap)MatchImage.Properties.Resources.image_one) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_two.Image, (Bitmap)MatchImage.Properties.Resources.image_two) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_three.Image, (Bitmap)MatchImage.Properties.Resources.image_three) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_four.Image, (Bitmap)MatchImage.Properties.Resources.image_four) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_five.Image, (Bitmap)MatchImage.Properties.Resources.image_five) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_six.Image, (Bitmap)MatchImage.Properties.Resources.image_six) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_seven.Image, (Bitmap)MatchImage.Properties.Resources.image_seven) == false) flag = false;
            if (compare_two_images((Bitmap)pictureBox_eight.Image, (Bitmap)MatchImage.Properties.Resources.image_eight) == false) flag = false;
            return flag;
        }

        void show_matxched_pop_up_message_box()
        {
            DialogResult dialog_result = MessageBox.Show("Play Again", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog_result.ToString() == "Yes") { start_over(); }
            else close_application();
        }

        void check_game_finished() 
        {
            if (check_all_images_match() == true)
            {
                //show_matxched_pop_up_message_box();
                matched_image_procedure();
            }
        }

        void matched_image_procedure() 
        {
            button_play_again.Visible = true;
            button_exit.Visible = false;
            button_reset.Visible = false;
            pictureBox_nine.Image = MatchImage.Properties.Resources.image_nine;
        }

        void initialization_form()
        {
            start_timer_for_logo_image();
            assign_dictionary_picturebox_int();
            assign_dictionary_int_bitmap_image();
            assign_dictionary_int_picturebox();
            assign_dictionary_bitmap_image_int();
            assign_image_to_log_pictrebox();
            pictureBox_temp.Visible = false;
            button_exit.Visible = false;
            button_reset.Visible = false;
            button_play_again.Visible = false;
        }

        void start_timer_for_logo_image()
        {
            store_second = 2;
            timer_logo_image.Interval = 1000;
            timer_logo_image.Enabled = true;
        }

        void assign_image_to_log_pictrebox()
        {
            pictureBox_logo_image.Image = MatchImage.Properties.Resources.logo_image;
        }

        void assign_dictionary_int_picturebox()
        {
            list_int_picture_box.Add(1, pictureBox_one);
            list_int_picture_box.Add(2, pictureBox_two);
            list_int_picture_box.Add(3, pictureBox_three);
            list_int_picture_box.Add(4, pictureBox_four);
            list_int_picture_box.Add(5, pictureBox_five);
            list_int_picture_box.Add(6, pictureBox_six);
            list_int_picture_box.Add(7, pictureBox_seven);
            list_int_picture_box.Add(8, pictureBox_eight);
            list_int_picture_box.Add(9, pictureBox_nine);
        }

        void assign_image_to_picturebox()
        {
            pictureBox_one.Image = MatchImage.Properties.Resources.image_one;
            pictureBox_two.Image = MatchImage.Properties.Resources.image_two;
            pictureBox_three.Image = MatchImage.Properties.Resources.image_three;
            pictureBox_four.Image = MatchImage.Properties.Resources.image_four;
            pictureBox_five.Image = MatchImage.Properties.Resources.image_five;
            pictureBox_six.Image = MatchImage.Properties.Resources.image_six;
            pictureBox_seven.Image = MatchImage.Properties.Resources.image_seven;
            pictureBox_eight.Image = MatchImage.Properties.Resources.image_eight;
            pictureBox_nine.Image = MatchImage.Properties.Resources.image_nine;
        }

        void assign_dictionary_int_bitmap_image()
        {
            list_int_image.Add(1, MatchImage.Properties.Resources.image_one);
            list_int_image.Add(2, MatchImage.Properties.Resources.image_two);
            list_int_image.Add(3, MatchImage.Properties.Resources.image_three);
            list_int_image.Add(4, MatchImage.Properties.Resources.image_four);
            list_int_image.Add(5, MatchImage.Properties.Resources.image_five);
            list_int_image.Add(6, MatchImage.Properties.Resources.image_six);
            list_int_image.Add(7, MatchImage.Properties.Resources.image_seven);
            list_int_image.Add(8, MatchImage.Properties.Resources.image_eight);
            list_int_image.Add(9, MatchImage.Properties.Resources.image_nine);
        }

        void assign_dictionary_image_name_int()
        {
            list_image_name_int.Add(MatchImage.Properties.Resources.image_one, 1);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_two, 2);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_three, 3);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_four, 4);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_five, 5);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_six, 6);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_seven, 7);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_eight, 8);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_nine, 9);
            list_image_name_int.Add(MatchImage.Properties.Resources.image_empty, 0);
        }

        void assign_dictionary_bitmap_image_int()
        {
            list_image_int.Add(MatchImage.Properties.Resources.image_one, 1);
            list_image_int.Add(MatchImage.Properties.Resources.image_two, 2);
            list_image_int.Add(MatchImage.Properties.Resources.image_three, 3);
            list_image_int.Add(MatchImage.Properties.Resources.image_four, 4);
            list_image_int.Add(MatchImage.Properties.Resources.image_five, 5);
            list_image_int.Add(MatchImage.Properties.Resources.image_six, 6);
            list_image_int.Add(MatchImage.Properties.Resources.image_seven, 7);
            list_image_int.Add(MatchImage.Properties.Resources.image_eight, 8);
            list_image_int.Add(MatchImage.Properties.Resources.image_nine, 9);
            list_image_int.Add(MatchImage.Properties.Resources.image_empty, 0);
        }

        void assign_dictionary_picturebox_int()
        {
            list_picture_box_int.Add(pictureBox_one, 1);
            list_picture_box_int.Add(pictureBox_two, 2);
            list_picture_box_int.Add(pictureBox_three, 3);
            list_picture_box_int.Add(pictureBox_four, 4);
            list_picture_box_int.Add(pictureBox_five, 5);
            list_picture_box_int.Add(pictureBox_six, 6);
            list_picture_box_int.Add(pictureBox_seven, 7);
            list_picture_box_int.Add(pictureBox_eight, 8);
            list_picture_box_int.Add(pictureBox_nine, 9);
        }

        void swap_picturebox_image(PictureBox pb1, PictureBox pb2)
        {
            pictureBox_temp.Image = pb1.Image;
            pb1.Image = pb2.Image;
            pb2.Image = pictureBox_temp.Image;
        }

        int generate_random_number()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 9);
            return value;
        }

        void assign_check_picturebox_value_index_array(int value)
        {
            for (int i = 0; i < 15; i++) check_picturebox_value_index[i] = value;
        }

        bool check_value_available(int index)
        {
            if(check_picturebox_value_index[index] == 1) return false;
            check_picturebox_value_index[index] = 1;
            return true;
        }

        void assign_image_to_a_picturebox_by_int(PictureBox picturebox, int value)
        {
            picturebox.Image = list_int_image[value];
        }

        void close_application()
        {
            Application.Exit();
        }

        void assign_image_to_all_picturebox()
        {
            assign_image_to_specific_picturebox(pictureBox_two);
            assign_image_to_specific_picturebox(pictureBox_three);
            assign_image_to_specific_picturebox(pictureBox_four);
            assign_image_to_specific_picturebox(pictureBox_five);
            assign_image_to_specific_picturebox(pictureBox_six);
            assign_image_to_specific_picturebox(pictureBox_seven);
            assign_image_to_specific_picturebox(pictureBox_eight);
            assign_image_to_specific_picturebox(pictureBox_nine);
        }

        void assign_image_to_specific_picturebox(PictureBox picturebox)
        {
            int value;
            while (true)
            {
                value = generate_random_number();
                if (check_value_available(value)) break;
            }
            assign_image_to_a_picturebox_by_int(picturebox, value);
        }

        bool up_key_changer(int value)
        {
            if (value == 1 || value == 2 || value == 3 || value == 4 || value == 5 || value == 6) return true;
            return false;
        }

        bool down_key_changer(int value)
        {
            if (value == 4 || value == 5 || value == 6 || value == 7 || value == 8 || value == 9) return true;
            return false;
        }

        bool left_key_changer(int value)
        {
            if (value == 1 || value == 2 || value == 4 || value == 5 || value == 7 || value == 8) return true;
            return false;
        }

        bool right_key_changer(int value)
        {
            if (value == 2 || value == 3 || value == 5 || value == 6 || value == 8 || value == 9) return true;
            return false;
        }

        void key_up()
        {
            if (up_key_changer(focused_picturebox_index))
            {
                swap_picturebox_image(list_int_picture_box[focused_picturebox_index], list_int_picture_box[focused_picturebox_index + 3]);
                focused_picturebox_index += 3;
                check_game_finished();
            }

        }

        void key_down()
        {
            if (down_key_changer(focused_picturebox_index))
            {
                swap_picturebox_image(list_int_picture_box[focused_picturebox_index], list_int_picture_box[focused_picturebox_index - 3]);
                focused_picturebox_index -= 3;
                check_game_finished();
            }
        }

        void key_left()
        {
            if (left_key_changer(focused_picturebox_index))
            {
                swap_picturebox_image(list_int_picture_box[focused_picturebox_index], list_int_picture_box[focused_picturebox_index + 1]);
                focused_picturebox_index += 1;
                check_game_finished();
            }
        }

        void key_right()
        {
            if (right_key_changer(focused_picturebox_index))
            {
                swap_picturebox_image(list_int_picture_box[focused_picturebox_index], list_int_picture_box[focused_picturebox_index - 1]);
                focused_picturebox_index -= 1;
                check_game_finished();
            }
        }

        void assign_picturebox_one_to_empty_image()
        {
            pictureBox_one.Image = MatchImage.Properties.Resources.image_empty;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    //Handle down arrow key event
                    key_down();
                    break;
                case Keys.Up:
                    //MessageBox.Show("Up");
                    //Handle up arrow key event
                    key_up();
                    break;
                case Keys.Right:
                    key_right();
                    //MessageBox.Show("Right");
                    //Handle right arrow key event
                    break;
                case Keys.Left:
                    key_left();
                    //MessageBox.Show("Left");
                    //Handle left arrow key event
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            start_over();
        }

        private void timer_logo_image_Tick(object sender, EventArgs e)
        {
            if (store_second == 0) {
                timer_logo_image.Enabled = false;
                pictureBox_logo_image.Visible = false;
                //button_reset.Visible = true;
                //button_exit.Visible = true;
                start_over();
            }
            else {
                button_reset.Visible = false;
                button_exit.Visible = false;
                button_play_again.Visible = false;
            }
            store_second--;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            close_application();
        }

        private void pictureBox_logo_image_Click(object sender, EventArgs e)
        {

        }

        private void button_play_again_Click(object sender, EventArgs e)
        {
            start_over();
        }
    }
}
