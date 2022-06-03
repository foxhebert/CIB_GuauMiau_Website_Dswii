using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//------------------------------------ Consumir Servicios
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SisGuauMiauWeb.Models
{
    public class LoginRestfulClient
    {

        private string BASE_URL = "http://localhost:7070/apiProcesos/gmValidarUsuario";

        public Task<string> usuarioValidacion(String usu, String psw)
        {

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                //HttpResponseMessage response = client.GetAsync(String.Format("validarUsuario")).Result;
                HttpResponseMessage response = client.GetAsync(String.Format("gmValidarUsuario/{0}/{1}", usu, psw)).Result;
                //HttpResponseMessage response = client.GetAsync(String.Format($"/gmValidarUsuario/{usu}")).Result;
                return response.Content.ReadAsStringAsync();

                //api/products/id={0}&type={1}",param.Id.Value,param.Id.Type
            }
            catch(Exception ex)
            {
                String msgex = ex.Message;
                Console.WriteLine(ex.Message);
                return null;
            }


        }

    }
}