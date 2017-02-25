using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMIteat.Models;

namespace BMIteat.Controllers
{
    public class BMIController : Controller
    {
        // GET: BMI
        public ActionResult Index()
        {
            using (OurDBContext db = new OurDBContext())
            {
               // List all BMI and Types
                List<UserBMI> data = db.userBMI.ToList();

                // Set all viewbags
                ViewBag.under = db.userBMI.Where(o => o.BMItype == 1).Count();
                ViewBag.normal = db.userBMI.Where(o => o.BMItype == 2).Count();
                ViewBag.pre = db.userBMI.Where(o => o.BMItype == 3).Count();
                ViewBag.obe1 = db.userBMI.Where(o => o.BMItype == 4).Count();
                ViewBag.obeh = db.userBMI.Where(o => o.BMItype == 5).Count();

                return View(data);
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserBMI bmi)
        {
            if (ModelState.IsValid)
            {

                // Process the BMI for its type
                
                bmi.BMItype = Check_BMI(bmi.Height, bmi.Weight);
                
                using (OurDBContext db = new OurDBContext())
                {
                    db.userBMI.Add(bmi);
                    db.SaveChanges();
                    
                }
                ModelState.Clear();
                ViewBag.message = @"Records Archived.";

            }
            return View();

        }

        // view data
        //public ActionResult 

        //Calculate BMI

        private byte Check_BMI(double H, double W) {
            byte BMIType = 0;
            double bmi;
            
            // Calculate BMI inseter into same function as it will not change soon.

            // BMI Calculation :: X = Weight / ((Height / 100) * (Height / 100))
            bmi = W / ((H / 100.0) * (H / 100.0));


            if(bmi > 18.5) { BMIType = 1; };
            if(bmi > 24.9 && bmi < 18.6) { BMIType = 2; };
            if (bmi > 30.0 && bmi < 25.1) { BMIType = 3; };
            if (bmi > 34.9 && bmi < 30.1) { BMIType = 4; };
            if (bmi < 35.0 ) { BMIType = 5; };

            return BMIType;
        }


        //private string DecodeBMI(byte type) {
        //    string rtn;

        //    switch (type) {
        //        case 1:
        //            rtn = "Underwieght";
        //            break;
        //        case 2:
        //            rtn = "Normal Weight";
        //            break;
        //        case 3:
        //            rtn = "Pre Obesity";
        //            break;
        //        case 4:
        //            rtn = "Obesity type 1";
        //            break;
        //        case 5:
        //            rtn = "Obesity Higher level";
        //            break;
        //        default:
        //            rtn = "Default value not found";
        //            break;

        //    }

        //    return rtn;
        //}

    }
}