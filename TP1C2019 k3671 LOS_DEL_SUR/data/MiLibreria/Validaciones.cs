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

        //VALIDACION PARA CAMPO NUMERIC
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
        
        //Validaciones PARA EL DNI
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

        //Validacion de fecha vencimiento DE LA TARJETA EN EL PROCESO DE CARGAR CREDITO
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

        //VALIDACION DE CONTRASEÑAS
        public static Boolean ValidarContrasenias(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            //DateTime fecha = Objeto.Value;
            return SinErrores;
         //   ErrorProvider.SetError(Objeto, "Formato no valido para dni");
        }

        //VALIDACION DEL FORMULARIO EN EL PROCESO DE CARGA DE CREDITO
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


        //VALIDACION FORMULARIO PARA CREACION DE OFERTAS
        public static Boolean ValidarCrearOferta(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean SinErrores = true;
            
            Control Campos = Objeto.Controls ["groupBox1"];
            int precioLista = 0;
            int precioOferta = 0;
            int stock = 0;
            int limiteCompra = 0;

            if (!string.IsNullOrEmpty(Campos.Controls ["numPrecLista"].Text.Trim()))
            {
                precioLista = (Convert.ToInt32(Campos.Controls ["numPrecLista"].Text));
            }

            if (!string.IsNullOrEmpty(Campos.Controls ["numPreOferta"].Text.Trim()))
            {
                 precioOferta = (Convert.ToInt32(Campos.Controls ["numPreOferta"].Text));
            }

            if (!string.IsNullOrEmpty(Campos.Controls ["numStock"].Text.Trim()))
            {
                 stock = (Convert.ToInt32(Campos.Controls ["numStock"].Text));
            }

            if (!string.IsNullOrEmpty(Campos.Controls ["numLimite"].Text.Trim()))
            {
                 limiteCompra = (Convert.ToInt32(Campos.Controls ["numLimite"].Text));
            }


            //VAlidacion de la descripcion
            if (string.IsNullOrEmpty(Campos.Controls ["txtDescr"].Text.Trim()))
            {
                ErrorProvider.SetError(Campos.Controls ["txtDescr"], "Este campo es obligatorio");
                SinErrores = false;
            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["txtDescr"], "");
            }

            //Validaciones de valores entre precio de lista y precio de oferta

            if (precioLista <= 0)
            {
                ErrorProvider.SetError(Campos.Controls ["numPrecLista"], "El precio de lista debe ser mayor a 0");
                SinErrores = false;
            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["numPrecLista"], "");
            }


            if (precioOferta >= precioLista | precioOferta == 0)
            {
                SinErrores = false;
                if (precioOferta == 0)
                {
                    ErrorProvider.SetError(Campos.Controls ["numPreOferta"], "El precio de oferta debe ser mayor a 0");
                }
                
                else
                {
                    ErrorProvider.SetError(Campos.Controls ["numPreOferta"], "El precio de oferta debe ser menor al precio de lista");
                }
            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["numPreOferta"], "");
            }

            //Validaciones de valores entre stock y liite de compra
            if (stock <= 0)
            {
                ErrorProvider.SetError(Campos.Controls ["numStock"], "El stock debe ser mayor a 0");
                SinErrores = false;
            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["numStock"], "");
            }

            if (limiteCompra > stock | limiteCompra == 0)
            {
                SinErrores = false;
                if (limiteCompra == 0)
                {
                    ErrorProvider.SetError(Campos.Controls ["numLimite"], "El limite de compra debe ser mayor a 0");
                }

                else
                {
                    ErrorProvider.SetError(Campos.Controls ["numLimite"], "El Limite de compra debe ser menor o igual al Stock");
                }
                
            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["numLimite"], "");
            }

            //Validaciones de valores entre stock y liite de compra
            if (stock <= 0)
            {
                ErrorProvider.SetError(Campos.Controls ["numStock"], "El stock debe ser mayor a 0");
                SinErrores = false;
            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["numStock"], "");
            }

            if (limiteCompra > stock | limiteCompra == 0)
            {
                SinErrores = false;
                if (limiteCompra == 0)
                {
                    ErrorProvider.SetError(Campos.Controls ["numLimite"], "El limite de compra debe ser mayor a 0");
                }

                else
                {
                    ErrorProvider.SetError(Campos.Controls ["numLimite"], "El Limite de compra debe ser menor o igual al Stock");
                }

            }
            else
            {
                ErrorProvider.SetError(Campos.Controls ["numLimite"], "");
            }


            //Validaciones de fecha de inciio y venicmiento de la oferta
            if (Convert.ToDateTime(Campos.Controls ["dateInicio"].Text) >= Convert.ToDateTime(Campos.Controls ["dateVencimiento"].Text))
           {
               SinErrores = false;
               ErrorProvider.SetError(Campos.Controls ["dateInicio"], "La fecha de vencimiento debe ser posterior a la fecha de incio");
                ErrorProvider.SetError(Campos.Controls ["dateVencimiento"], "La fecha de vencimiento debe ser posterior a la fecha de incio");
           }
           else
           {
               ErrorProvider.SetError(Campos.Controls ["dateVencimiento"], "");
               ErrorProvider.SetError(Campos.Controls ["dateInicio"], "");
           }
            return SinErrores;
        }


        //VALIDACION PARA COMPRAR OFERTAS
        public static Boolean ValidarComprarOferta(Control Objeto, ErrorProvider ErrorProvider, int clienteID, int ofertaID)
        {
            Boolean SinErrores = true;

            if (string.IsNullOrEmpty(Objeto.Controls ["numCantidad"].Text.Trim()))
            {
                ErrorProvider.SetError(Objeto.Controls ["numCantidad"], "Este campo es obligatorio");
                SinErrores = false;
                return SinErrores;
            }
            else
            {
                ErrorProvider.SetError(Objeto.Controls ["numCantidad"], "");
            }

             int limiteCompra = Convert.ToInt32(Objeto.Controls ["txtLimite"].Text.ToString());
            int stock = Convert.ToInt32(Objeto.Controls ["txtStock"].Text.ToString());
            int cantidad = Convert.ToInt32(Objeto.Controls ["numCantidad"].Text.ToString());
            float totalCompra = float.Parse(Objeto.Controls ["numTotal"].Text.ToString());
            float saldo = float.Parse(Objeto.Controls ["txtSaldo"].Text.ToString());


            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad a comprar no debe superar el stock disponible");
                SinErrores = false;
                return SinErrores;
            }

            if (saldo < totalCompra)
            {
                MessageBox.Show("No tiene saldo suficiente para realizar esta compra");
                SinErrores = false;
                return SinErrores;
            }

            /*
             Validacion con Store procedure para el limite de compra
             */
             if (!(BaseDatos.ValidarLimiteDeCompra( clienteID,  ofertaID, limiteCompra, cantidad)))
            {
                MessageBox.Show("Con esta compra excede el limite de compra por usuario para dicha oferta");
                SinErrores = false;
                return SinErrores;
            }
            return SinErrores;
        }
    }
}
