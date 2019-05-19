using Proyecto.Context;
//using Proyecto.Interfaces.Security;
using Proyecto.Interfaces.SQLite;
using Proyecto.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
namespace Proyecto.Services.Security
{

    public class FicServiceSecurity : IFicServiceSecurity
    {
        private readonly FicDataBaseContext _FicDataBaseContex;
        private readonly HttpClient FicHttpClient;
        public FicServiceSecurity()
        {
            this._FicDataBaseContex = new FicDataBaseContext(DependencyService.Get < IFicDataBasePathSQLite >().FicGetDataBasePath());
            this.FicHttpClient = new HttpClient() { MaxResponseContentBufferSize = 256000 }; // builder
        }
        private async Task<temp_model_data_login> FicMetGetWebApiDataLogin(string FicUser, string FicPassword)
        {

            try
            {
                //if (!CrossConnectivity.Current.IsConnected) //{ // //await App.Current.MainPage.DisplayAlert("ALERTA", "SIN CONEXION A INTERNET.", "OK"); // return null; //}//You will only search if you have an internet connection 
                string url = FicAppSettings.FicURLBase.ToString() + "api/seguridad/login" + "?user=" + FicUser.ToString() + "&password=" + FicPassword.ToString();
                var response = await FicHttpClient.GetAsync(url); var respuesta = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await App.Current.MainPage.DisplayAlert("ALERTA", respuesta, "OK");
                    return null;
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    await App.Current.MainPage.DisplayAlert("ALERTA", "StatusCode: " + respuesta, "OK"); 
                    return null;
                }
                var FicJSonConvert = JsonConvert.DeserializeObject<temp_model_data_login>(await response.Content.ReadAsStringAsync()); return FicJSonConvert;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error de conexion", "Imposible Conectarse con el servidor", "OK"); return null;
            }
        }//GET: This method receives the information to manage the login locally 

        public async Task<bool> FicMetAddUser(temp_model_add_user FicDataUser)
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected(1))
                {
                    string url = FicAppSettings.FicURLBase.ToString() + "api/seguridad/nuevo_registro";
                    //var response = await FicHttpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(FicDataUser)));
                    HttpResponseMessage response = await FicHttpClient.PostAsync(
                        new Uri(string.Format(url, string.Empty)),
                        new StringContent(JsonConvert.SerializeObject(FicDataUser), Encoding.UTF8, "application/json"));
                    var respuesta = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        await App.Current.MainPage.DisplayAlert("ALERTA", respuesta, "OK");
                        return false;
                    }
                    else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        await App.Current.MainPage.DisplayAlert("ALERTA", "StatusCode: " + response.StatusCode.ToString(), "OK");
                        return false;
                    } //var FicMessageResponse = await response.Content.ReadAsStringAsync(); 
                    await App.Current.MainPage.DisplayAlert("REGISTRADO CON EXITO", await response.Content.ReadAsStringAsync(), "CK");
                    return true;
                }
                await App.Current.MainPage.DisplayAlert("ALERTA", "Sin Conexion a internet.", "OK");
                return false;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("AERTA.", e.Message.ToString(), "OK");
                return false;
            }
        }//This method confirms 


    }
}