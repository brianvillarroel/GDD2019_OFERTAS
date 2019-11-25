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
                    }
                }
            }
            return (SinErrores && MailValidado);
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


        public static Boolean ValidarContrasenias(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            //DateTime fecha = Objeto.Value;
            return SinErrores;
            ErrorProvider.SetError(Objeto, "Formato no valido para dni");
        }
    }
}
