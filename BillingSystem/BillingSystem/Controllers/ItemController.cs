using BillingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BillingSystem.Controllers
{

    public class ItemController : Controller
    {
        public static List<Item> ItemList = new List<Item>();
        public static int i=0;
               
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScanItem()
        {
            return PartialView();
        }

        public ActionResult AddItem(int itemcode) //parameter should be same as field name , not case sensitive
        {
            string apiURI = "https://localhost:44369/api/Items/";

            apiURI = apiURI + itemcode.ToString();
            var client = new HttpClient();

            var response = client.GetAsync(apiURI);

            string op = "";
            Item item;
            if (response.Result.IsSuccessStatusCode)
            {
                using (HttpContent cont = response.Result.Content)
                {
                    Task<string> res = cont.ReadAsStringAsync();
                    op = res.Result;
                    
                    //User user=JsonConvert.DeserializeObject<User>
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    item = js.Deserialize<Item>(op);

                }

                item.index = i;

                ItemList.Add(item);
                i++;
                
                return RedirectToAction("Index");

            }
            else
            {
                
                return View();
            }
        }
        public ActionResult Details()
        {
            return PartialView(ItemList);
        }

        public ActionResult Delete(int id)
        {
            Item item = new Item();
            var query = ItemList.Where(i => i.index == id);
            foreach (var i in query)
            {
                item = i;
            }

            ItemList.Remove(item);
            
            return RedirectToAction("Index");
        }

        
    }
}

