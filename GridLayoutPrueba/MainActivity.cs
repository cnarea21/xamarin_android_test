using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using System;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Text;
using Android.Text.Style;
using ChiralCode.ColorPickerLib;
using System.Collections.Generic;
using Android.Icu.Util;
using Com.Wdullaer.Materialdatetimepicker.Date;
using System.Linq;

namespace GridLayoutPrueba
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ColorPickerDialog.IOnColorSelectedListener, Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener
    {
        //Estatico
        //GridLayout grid_layout;
        TextView txt_actual;
        int color_actual = 0;

        //Dinamico
        HorizontalScrollView hscroll;

        EditText txt_columna, txt_fila;
        Button btn_generar, btn_colorear_seleccion, btn_datepicker;

        List<TextView> ls_seleccionados = new List<TextView>();

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Estatico
            //grid_layout = FindViewById<GridLayout>(Resource.Id.grid_layout);


            //Dinamico
            hscroll = FindViewById<HorizontalScrollView>(Resource.Id.hscroll);
            btn_generar = FindViewById<Button>(Resource.Id.btn_generar);
            txt_columna = FindViewById<EditText>(Resource.Id.txt_columna);
            txt_fila = FindViewById<EditText>(Resource.Id.txt_fila);
            btn_colorear_seleccion = FindViewById<Button>(Resource.Id.btn_colorear_seleccion);
            btn_datepicker = FindViewById<Button>(Resource.Id.btn_datepicker);

            btn_generar.Click += Btn_generar_Click;

            btn_colorear_seleccion.Click += Btn_colorear_seleccion_Click;

            btn_datepicker.Click += btn_datepicker_Click;

            txt_columna.Text = "10";
            txt_fila.Text = "15";
            //Estatico

            //int columnas = 50;
            //int filas = 60;
            //int cuadricula = columnas * filas;

            //grid_layout.ColumnCount = columnas;
            //grid_layout.RowCount = filas;

            //for (int i = 0; i < cuadricula; i++) {

            //    TextView text_view = new TextView(this);
            //    text_view.Text = i.ToString();
            //    text_view.Id = i;
            //    text_view.SetWidth(80);
            //    text_view.SetHeight(50);
            //    grid_layout.AddView(text_view);

            //    if (text_view.Text.EndsWith("1")) {
            //        //text_view.SetBackgroundColor(Color.Azure);

            //        GradientDrawable gd = new GradientDrawable();
            //        gd.SetColor(Color.Yellow);
            //        gd.SetCornerRadius(5);
            //        gd.SetStroke(1, Color.Black);
            //        text_view.Background = gd;

            //    } else if (text_view.Text.EndsWith("2")) {
            //        //text_view.SetBackgroundColor(Color.Red);

            //        GradientDrawable gd = new GradientDrawable();
            //        gd.SetColor(Color.Red);
            //        gd.SetCornerRadius(5);
            //        gd.SetStroke(1, Color.Black);
            //        text_view.Background = gd;

            //    } else if (text_view.Text.EndsWith("3")) {
            //        //text_view.SetBackgroundColor(Color.Orange);

            //        GradientDrawable gd = new GradientDrawable();
            //        gd.SetColor(Color.Orange);
            //        gd.SetCornerRadius(5);
            //        gd.SetStroke(1, Color.Black);
            //        text_view.Background = gd;

            //    } else if (text_view.Text.EndsWith("4")) {
            //        //text_view.SetBackgroundColor(Color.Pink);

            //        GradientDrawable gd = new GradientDrawable();
            //        gd.SetColor(Color.Pink);
            //        gd.SetCornerRadius(5);
            //        gd.SetStroke(1, Color.Black);
            //        text_view.Background = gd;

            //    } 

            //    else {
            //        GradientDrawable gd = new GradientDrawable();
            //        gd.SetColor(Color.White);
            //        gd.SetCornerRadius(5);
            //        gd.SetStroke(1, Color.Black);
            //        text_view.Background = gd;
            //    }

            //    text_view.Click += delegate (object s, EventArgs e_) {
            //        TextView txt_ = (TextView)s;
            //        txt_.Text = "E";
            //        Toast.MakeText(this, "N#: " + txt_.Id.ToString(), ToastLength.Long).Show();
            //    }; ;

            //}

        }
        
        private void Btn_generar_Click(object sender, EventArgs e) {

            if (txt_fila.Text.Trim() ==string.Empty && txt_columna.Text.Trim() == string.Empty)
            {
                Toast.MakeText(this, "Ingrese número de filas y columnas", ToastLength.Long).Show();
            }

            else
            {
                hscroll.RemoveAllViews();
                GridLayout grid_layout = new GridLayout(this);
                hscroll.AddView(grid_layout);

                int columnas = Int32.Parse(txt_columna.Text);
                int filas = Int32.Parse(txt_fila.Text);
                int cuadricula = columnas * filas;

                grid_layout.ColumnCount = columnas;
                grid_layout.RowCount = filas;

                for (int i = 0; i < cuadricula; i++)
                {

                    TextView text_view = new TextView(this);
                    //text_view.Text = i.ToString();
                    text_view.Text = "";
                    text_view.Id = i;
                    text_view.SetWidth(80);
                    text_view.SetHeight(50);
                    text_view.Gravity = Android.Views.GravityFlags.Center;
                    text_view.SetTextColor(Color.Blue);
                    //text_view.Hint = "H1";
                    text_view.SetHintTextColor(Color.Black);

                    grid_layout.AddView(text_view);

                    if (text_view.Text.EndsWith("1"))
                    {
                        //text_view.SetBackgroundColor(Color.Azure);

                        //SpannableString spannableString = new SpannableString("Palet1 Palet2");
                        //Java.Lang.Object green_span = new BackgroundColorSpan(Color.Green);
                        //Java.Lang.Object red_span = new BackgroundColorSpan(Color.White);
                        //spannableString.SetSpan(green_span, 0, 6, 0);
                        //spannableString.SetSpan(red_span, 6, spannableString.Length(), 0);
                        //text_view.TextFormatted = spannableString;


                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(Color.Yellow);
                        gd.SetCornerRadius(5);
                        gd.SetStroke(1, Color.Black);
                        text_view.Background = gd;
                        //text_view.Text = "";




                    }
                    else if (text_view.Text.EndsWith("2"))
                    {
                        //text_view.SetBackgroundColor(Color.Red);


                        //SpannableString spannableString = new SpannableString("Palet1 Vacío");
                        //Java.Lang.Object green_span = new BackgroundColorSpan(Color.Green);
                        //Java.Lang.Object red_span = new BackgroundColorSpan(Color.White);
                        //spannableString.SetSpan(green_span, 0, 6, 0);
                        //spannableString.SetSpan(red_span, 6, spannableString.Length(), 0);
                        //text_view.TextFormatted = spannableString;

                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(Color.Red);
                        gd.SetCornerRadius(5);
                        gd.SetStroke(1, Color.Black);
                        text_view.Background = gd;

                    }
                    else if (text_view.Text.EndsWith("3"))
                    {
                        //text_view.SetBackgroundColor(Color.Orange);

                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(Color.Orange);
                        gd.SetCornerRadius(5);
                        gd.SetStroke(1, Color.Black);
                        text_view.Background = gd;

                    }
                    else if (text_view.Text.EndsWith("4"))
                    {
                        //text_view.SetBackgroundColor(Color.Pink);

                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(Color.Pink);
                        gd.SetCornerRadius(5);
                        gd.SetStroke(1, Color.Black);
                        text_view.Background = gd;

                    }
                    else
                    {
                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(Color.White);
                        gd.SetCornerRadius(5);
                        gd.SetStroke(1, Color.Black);
                        text_view.Background = gd;

                    }

                    text_view.Click += delegate (object s, EventArgs e_) {
                        TextView txt_ = (TextView)s;
                        txt_actual = txt_;
                        if (txt_.Text == "S")
                        {
                            txt_.Text = "";

                            GradientDrawable gd = (GradientDrawable)txt_.Background;
                            gd.SetCornerRadius(5);
                            gd.SetStroke(1, Color.Black);

                            ls_seleccionados.Remove(txt_);
                        }
                        else
                        {
                            txt_.Text = "S";

                            GradientDrawable gd = (GradientDrawable)txt_.Background;
                            gd.SetCornerRadius(5);
                            gd.SetStroke(4, Color.Red);

                            ls_seleccionados.Add(txt_);
                        }

                        //GridLayout padre = (GridLayout)txt_.Parent;



                        //ColorPickerDialog dialog = new ColorPickerDialog(this, color_actual , this);

                        //dialog.Show();

                        Toast.MakeText(this, "N#: " + txt_.Id.ToString(), ToastLength.Long).Show();
                    }; ;



                }
            }
       
        }


        private void Btn_colorear_seleccion_Click(object sender, EventArgs e)
        {
           ColorPickerDialog dialog = new ColorPickerDialog(this, color_actual, this);

            dialog.Show();
        }

        public void OnColorSelected(int color)
        {
            //Toast.MakeText(Application.Context, "Color Elegido" + color.ToString(), ToastLength.Long).Show();

            //Cambio de color individual

            //GradientDrawable gd = new GradientDrawable();
            //gd.SetColor(color);
            //gd.SetCornerRadius(5);
            //gd.SetStroke(1, Color.Black);
            //txt_actual.Background = gd;


            //Cambio de Color en Lote

            foreach (TextView txt_actual in ls_seleccionados)
            {
                
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(color);
                gd.SetCornerRadius(5);
                gd.SetStroke(1, Color.Black);
                txt_actual.Background = gd;
                txt_actual.Text = "";
            }

            color_actual = color;

            ls_seleccionados.Clear();
           
        }


        private void btn_datepicker_Click(object sender, EventArgs e)
        {
            try
            {
                if (ls_seleccionados.Count==0)
                {
                    #region  OPCION PARA RESTRINGIR DÍAS DEL CALENDARIO            

                    Java.Util.Calendar day_java = Java.Util.Calendar.Instance;

                    Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog dpd = Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.NewInstance(
                           this,
                           day_java.Get(Java.Util.CalendarField.Year),
                           day_java.Get(Java.Util.CalendarField.Month),
                           day_java.Get(Java.Util.CalendarField.DayOfMonth));

                    dpd.FirstDayOfWeek = Java.Util.Calendar.Monday;

                    //    #region  SETEAR DÍAS ESPECÍFICOS PARA EL CALENDARIO

                    //    List<Java.Util.Calendar> dias_array_java = new List<Java.Util.Calendar>();


                    //    var lista_fechas =  mt_ws_gis_inspeccion_desarrollo.cabecera_proceso_coccion_traer_todos();
                    //    foreach (var item in lista_fechas)
                    //    {
                    //        Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
                    //        DateTime fecha = item.fecha_proceso_coccion;
                    //        calendar.Set(fecha.Year, fecha.Month - 1, fecha.Day, fecha.Hour, fecha.Minute);
                    //        dias_array_java.Add(calendar);
                    //    }              
                    //    dpd.SetSelectableDays(dias_array_java.ToArray());
                    //    #endregion

                    //    //HABILITAR SOLO FINES DE SEMANA

                    //    //List<Java.Util.Calendar> weekends_java = new List<Java.Util.Calendar>();

                    //    //for (int i = 0; i < 365; i++)
                    //    //{
                    //    //    if (day_java.Get(Java.Util.CalendarField.DayOfWeek) == Java.Util.Calendar.Saturday || day_java.Get(Java.Util.CalendarField.DayOfWeek) == Java.Util.Calendar.Sunday)
                    //    //    {
                    //    //        Java.Util.Calendar d = (Java.Util.Calendar)day_java.Clone();
                    //    //        weekends_java.Add(d);
                    //    //    }

                    //    //    day_java.Add(Java.Util.CalendarField.Date, 1);
                    //    //}

                    //    //dpd.SetSelectableDays(weekends_java.ToArray());

                    //HABILITAR SOLO DÍAS DE SEMANA
                    List<Java.Util.Calendar> weekdays_java = new List<Java.Util.Calendar>();

                    for (int i = 0; i < 365; i++)
                    {
                        if (day_java.Get(Java.Util.CalendarField.DayOfWeek) != Java.Util.Calendar.Saturday && day_java.Get(Java.Util.CalendarField.DayOfWeek) != Java.Util.Calendar.Sunday)
                        {
                            Java.Util.Calendar d = (Java.Util.Calendar)day_java.Clone();
                            weekdays_java.Add(d);
                        }

                        day_java.Add(Java.Util.CalendarField.Date, 1);
                    }

                    dpd.SetSelectableDays(weekdays_java.ToArray());

                    //MOSTRAR CALENDARIO
                    dpd.Show(FragmentManager, "DatePicker");

                    #endregion

                    //    #region OPCION PARA CALENDARIO NORMAL SIN RESTRICCIÖN DE DÍAS

                    //    //Java.Util.Calendar now = Java.Util.Calendar.Instance;

                    //    //Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog datePicker = Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.NewInstance(
                    //    //        this,
                    //    //        now.Get(Java.Util.CalendarField.Year),
                    //    //        now.Get(Java.Util.CalendarField.Month),
                    //    //        now.Get(Java.Util.CalendarField.DayOfMonth));

                    //    //datePicker.SetTitle("Calendario de Proceso");
                    //    //datePicker.Show(FragmentManager, "DatePicker");
                    //    #endregion
                }

                else
                {
                    GradientDrawable gradiant =(GradientDrawable) ls_seleccionados.First().Background;
                    color_actual =  gradiant.Color.DefaultColor;
                }
            }
            catch (Exception)
            {

                
            }

          
        }

        public void OnDateSet(Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog p0, int year, int month, int day)
        {
            Toast.MakeText(this, day.ToString() + "/" + (month + 1).ToString() + "/" + year.ToString(), ToastLength.Long).Show();
        }




        //public interface IOnColorSelectedListener
        //{
        //    void OnColorSelected(int color);
        //}
    }

   

}