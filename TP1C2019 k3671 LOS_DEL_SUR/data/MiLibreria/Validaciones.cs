using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;


namespace MiLibreria
{
    public class Validaciones
    {
        
        //Validaciones para que se llenen los campos obligatorios.
        public static Boolean ValidarTextBox(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            Boolean MailValidado = true;
            Boolean CuitValidado = true;
            
            foreach (Control element in Objeto.Controls)  
            {

                if (element is GroupBox)
                {
                    foreach (Control Item in element.Controls)
                    {
                        if (Item is ErrorTxtBox)
                        {

                            ErrorTxtBox Obj = (ErrorTxtBox)Item;
                            if (Obj.Validar == true)
                            {
                                if (string.IsNullOrEmpty(Obj.Text.Trim()))
                                {
                                    ErrorProvider.SetError(Obj, "Este campo es obligatorio");
                                    SinErrores = false;
                                }
                                else
                                {
                                    ErrorProvider.SetError(Obj, "");
                                }

                                if (Obj.Name == "txtCuit")
                                {
                                    CuitValidado = ValidarCuit(Obj, ErrorProvider);
                                }
                                
                            }

                        }
                        if (Item is TxtBoxMail)
                        {
                            TxtBoxMail ObjMail = (TxtBoxMail)Item;
                            MailValidado = ValidarEmail(ObjMail, ErrorProvider);
                        }
                        if (Item is NumericTextBox)
                        {

                            NumericTextBox Obj = (NumericTextBox)Item;
                            if (Obj.Validar == true)
                            {
                                if (string.IsNullOrEmpty(Obj.Text.Trim()))
                                {
                                    ErrorProvider.SetError(Obj, "Este campo es obligatorio");
                                    SinErrores = false;
                                }
                                else
                                {
                                    ErrorProvider.SetError(Obj, "");
                                }

                            }

                        }
                        if (Item is ComboBox)
                        {
                            ComboBox cb = (ComboBox)Item;
                            if (cb.SelectedIndex == -1)
                            {
                                ErrorProvider.SetError(Item, "Este campo es obligatorio");
                                SinErrores = false;
                            }
                            else
                            {
                                ErrorProvider.SetError(cb, "");
                            }

                        }
                    }
                }
            }
            return (SinErrores && MailValidado && CuitValidado && CuitValidado);
        }

        //Funcion para validar el input del mail.
        public static Boolean ValidarEmail(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            Regex patronEmail = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase);


            SinErrores = (!string.IsNullOrEmpty(Objeto.Text.Trim()) && patronEmail.IsMatch(Objeto.Text.Trim()));


            if (!SinErrores)
            {
                ErrorProvider.SetError(Objeto, "Formato no valido para Mail");
            }
            else 
            {
                ErrorProvider.SetError(Objeto, "");
            }

            return SinErrores;
        }

        public static Boolean ValidarNumericTxt(Control Objeto, ErrorProvider ErrorProvider)
        {
           Boolean sinError = true;
                NumericTextBox Obj = (NumericTextBox)Objeto;
                if (Obj.Validar == true)
                {
                    if (string.IsNullOrEmpty(Obj.Text.Trim()))
                    {
                        ErrorProvider.SetError(Obj, "Este campo es obligatorio");
                        sinError = false;
                    }
                    else
                    {
                        ErrorProvider.SetError(Obj, "");
                    }

                }

                return sinError;
        }
        
        
        void numText_Validating(Control Objeto, ErrorProvider ErrorProvider)
        {
            NumericTextBox miTxt = (NumericTextBox)Objeto;
            
            if (string.IsNullOrEmpty(miTxt.Text))
            {
                miTxt.Select(0, miTxt.Text.Length);
                ErrorProvider.SetError(Objeto, "Formato no valido para dni");
            }
        }

        //Funcion para validar el input del CUIT.
        public static Boolean ValidarCuit(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            Regex patronCuit = new Regex("^[0-9]{2}[-][0-9]{7,8}[-][0-9]{1}$");


            SinErrores = (!string.IsNullOrEmpty(Objeto.Text.Trim()) && patronCuit.IsMatch(Objeto.Text.Trim()));


            if (!SinErrores)
            {
                ErrorProvider.SetError(Objeto, "El Cuit debe respetar el siguiente formato: **-*******-*");
            }
            else
            {
                ErrorProvider.SetError(Objeto, "");
            }

            return SinErrores;
        }

        //Validacion de numero de tarjeta
        public static Boolean ValidarTarjetaVencimiento(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            string vencimiento = ("01/" + Objeto.Text.Trim());

            Regex patronVenc = new Regex("^0([1-9]{1})|1[]0,1,2]{1}[/]((19[0-9]{2})|(20[0-9]{2}))$");
            
            SinErrores = (patronVenc.IsMatch(Objeto.Text.Trim()));


            if (!SinErrores)
            {
                ErrorProvider.SetError(Objeto, "La fecha de vencimiento debe respetar el siguiente formato: MM/AAAA");
            }
            else
            {
                DateTime fechaVenc = Convert.ToDateTime(vencimiento);
                DateTime fechaSistema = BaseDatos.ObtenerFechaSistema();
                if (fechaVenc <= fechaSistema)
                {
                     ErrorProvider.SetError(Objeto, "Su tarjeta está vencida");
                     SinErrores = false;
                }
                else
                {
                    ErrorProvider.SetError(Objeto, "");
                }
                
            }

            return SinErrores;
        }

        //Validacion de fecha vencimiento
        public static Boolean ValidarTarjeta(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            Regex patronCuit = new Regex("^[0-9]{16}$");


            SinErrores = (patronCuit.IsMatch(Objeto.Text.Trim()));


            if (!SinErrores)
            {
                ErrorProvider.SetError(Objeto, "El numero de tarjeta deben ser 12 digitos");
            }
            else
            {
                ErrorProvider.SetError(Objeto, "");
            }

            return SinErrores;
        }

        public static Boolean ValidarContrasenias(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            //DateTime fecha = Objeto.Value;
            return SinErrores;
         //   ErrorProvider.SetError(Objeto, "Formato no valido para dni");
        }

        //Validar campos en la caga de credito
        public static Boolean ValidarCargaCredito(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            Boolean tarjVenc = true;
            Boolean tarjNum = true;

            
            foreach (Control element in Objeto.Controls)
            {

                if (element is GroupBox)
                {
                    foreach (Control Item in element.Controls)
                    {
                         if (Item is ErrorTxtBox)
                        {
                            ErrorTxtBox Obj = (ErrorTxtBox)Item;
                            if (Obj.Validar == true)
                            {
                                if (string.IsNullOrEmpty(Obj.Text.Trim()))
                                {
                                    ErrorProvider.SetError(Obj, "Este campo es obligatorio");
                                    SinErrores = false;
                                }
                                else
                                {
                                    ErrorProvider.SetError(Obj, "");
                                }

                                if (Obj.Name == "dateVenc")
                                {
                                    tarjVenc = ValidarTarjetaVencimiento(Obj, ErrorProvider);
                                }
                            }
                         }

                        if(Item is NumericTextBox)
                        {
                            NumericTextBox Obj = (NumericTextBox)Item;
                            SinErrores = ValidarNumericTxt(Obj, ErrorProvider);
                        }

                        if (Item is NumericTextBox && Item.Name == "numTarjeta")
                        {
                            NumericTextBox Obj = (NumericTextBox)Item;
                            tarjNum = ValidarTarjeta(Obj, ErrorProvider);
                        }

                        if (Item is ComboBox)
                        {
                            ComboBox Obj = (ComboBox)Item;
                            if (Obj.SelectedIndex == -1)
                            {
                                ErrorProvider.SetError(Obj, "Este campo es obligatorio");
                            }
                            else
                            {
                                ErrorProvider.SetError(Obj, "");
                            }
                            
                        }
                    }
                }
            }
            return (SinErrores &&  tarjVenc &&  tarjNum );
        }
    }
}
