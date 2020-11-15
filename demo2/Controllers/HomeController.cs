using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demo2.Models;
using demo2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Net;
using RestSharp;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace demo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Icreatev ic;
        private readonly Iaddvoter ia;
        private readonly Icand icnd;
        private readonly Iresult res;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,Icreatev ic,Iaddvoter ia, ApplicationDbContext context, Icand icnd,Iresult res)
        {
            this.ic = ic;
            this.ia = ia;
            this.icnd = icnd;
            this.res = res;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ahome()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Createv()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Createv(vtype v)
        {
            //  await rolemanager.CreateAsync(role);
            vtype vt = new vtype
            {
                voting_type = v.voting_type,
                start_date = v.start_date,
                end_date = v.end_date,
                no=v.no
            };

            ic.Add(vt);
            return View("Createv");
            //return RedirectToAction("ahome");
        }

        [HttpGet]
        public IActionResult addvoter()
        {
            ViewData["vtypeId"] = new SelectList(_context.vtype, "vtypeId", "vtypeId");

            return View();
        }
        [HttpPost]
        public IActionResult addvoter(avoter av)
        {
            vtype vt = new vtype();
            //  await rolemanager.CreateAsync(role);
            avoter a = new avoter
            {
                Name = av.Name,
                password=av.password,
                vtypeId=av.vtypeId

            };
            ViewData["vtypeId"] = new SelectList(_context.vtype, "vtypeId", "vtypeId",av.vtypeId);
            ia.Add(a);
            return RedirectToAction("addvoter");
        }
        public ViewResult viewall()
        {
            var m = ic.Getalltypes();
            return View(m);

        }
        public ViewResult viewallv()
        {
            var m = ic.Getalltypes();
            return View(m);

        }
        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("shizu22099@gmail.com", "WeVote");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "sS@123saloni";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        [HttpGet]
        public ViewResult Addcand()
        {
            ViewData["vtypeId"] = new SelectList(_context.vtype, "vtypeId", "vtypeId");

            return View();
        }
        [HttpPost]
        public IActionResult Addcand(cand c)
        {

            vtype vt = new vtype();
            cand cc = new cand
            {
                Name = c.Name,
                profession = c.profession,
                vtypeId = c.vtypeId
            };
            
            ViewData["vtypeId"] = new SelectList(_context.vtype, "vtypeId", "vtypeId", c.vtypeId);
            icnd.Add(cc);
            return RedirectToAction("Addcand");


        }
        public ViewResult Vote(int Id)
        {
           
                var m = icnd.Getvtype(Id);
                result r = new result
                {
                    cid = Id,
                    vtypeId = m.vtypeId
                };
                res.Add(r);
            string name;
            name = HttpContext.Session.GetString("name");
            var mm=ia.Getvote(name);
            ia.delete(mm.Id);
            return View();
            
        }
        public ViewResult delv(int Id)
        {


            ViewBag.delete = "type is deleted";
            var m=ic.deletec(Id);
            return View();

        }

        [HttpGet]
        public ViewResult GetV()
        {
            return View();
        }


        [HttpPost]
  
        public ViewResult GetV(String Name,String password)
        {
          
            avoter aa = new avoter();
            aa=ia.Getv(Name,password);
            if (aa != null)
            {
                HttpContext.Session.SetString("name",Name);
                ViewBag.Name = Name;
                return View("givevote");
            }
            else
            {
                ViewBag.msg = "enter correct credentials";
                return View("Index");
            }
            

        }
        [HttpGet]
        public ViewResult cadmin()
        {
            return View();
        }
        [HttpPost]

        public ViewResult cadmin(String Name, String password)
        {

            if (Name == "saloni" && password=="saloni")
            {
                
                return View("ahome");
            }
            else
            {
                return View("Index");
            }


        }
        public ViewResult viewcand()
        {
            string name;
            name= HttpContext.Session.GetString("name");
            ViewBag.n = HttpContext.Session.GetString("name");
            var m = ia.Getvote(name);
            int id = m.vtypeId;
            var model = icnd.Getc(id);

            var mm = ic.Getv(id);
            DateTime start = mm.start_date;
            DateTime end = mm.end_date;
            DateTime current = DateTime.Now;
            if(current < start || current > end)
            {
                ViewBag.late = "please check the date of voting";
                return View("Index");
            }
            else {
                return View(model);
            }
            
        }
        public ViewResult viewres(int Id)
        {
            var m = ic.Getv(Id);
            DateTime end = m.end_date;
            DateTime cur = DateTime.Now;
            if (end > cur)
            {
                return View("pending");
            }
            else
            {
                
                var model= icnd.Getc(Id);
                var c = 0;
                var rr = 0;
                var resid = 0;
               // var win = 0;
                foreach (var item in model)
                {
                    rr = c;
                    var mm = res.Getrec(Id,item.Id);
                    c=mm.ToList().Count();
                    if (c>rr)
                    {
                        resid = item.Id;
                        
                    }
                }
                var ans = icnd.Getvtype(resid);
                if (ans == null)
                {
                    ViewBag.no = "No Votes Yet";
                    return View("Index");
                }
                else
                {

                    return View(ans);
                }
            }
        }

        public ViewResult viewresa(int Id)
        {
            var m = ic.Getv(Id);
            DateTime end = m.end_date;
            DateTime cur = DateTime.Now;
            if (end > cur )
            {
                return View("pend");
            }
            else
            {

                var model = icnd.Getc(Id);
                var c = 0;
                var rr = 0;
                var resid = 0;
                // var win = 0;
                foreach (var item in model)
                {
                    rr = c;
                    var mm = res.Getrec(Id, item.Id);
                    c = mm.ToList().Count();
                    if (c > rr)
                    {
                        resid = item.Id;

                    }
                }
                var ans = icnd.Getvtype(resid);
                if (ans == null)
                {
                    ViewBag.noa = "No Votes Yet";

                    return View("ahome");
                }
                else
                {

                    return View(ans);
                }
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
