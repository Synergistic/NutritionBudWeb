using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;
using NutritionWeb.WebUI.Models;

namespace NutritionWeb.WebUI.Controllers
{
    public class CalculatorController : Controller
    {
        INutritionCalculator nutCalc;

        public CalculatorController(INutritionCalculator nutCalc)
        {
            this.nutCalc = nutCalc;
        }


        [HttpGet]
        public ViewResult EnergyNeeds(bool usePenn)
        {
            ViewBag.ProteinList = new Factors().Protein();
            if (usePenn)
                return View("PennState");

            ViewBag.ActivityFactor = new Factors().Activity;
            ViewBag.StressFactor = new Factors().Stress;
            return View("Mifflin");
        }

        [HttpPost]
        public ViewResult EnergyNeeds(Patient patient, bool usePenn)
        {
            if (ModelState.IsValid)
            {
                nutCalc.SetPatient(patient);
                nutCalc.MifflinEnergy();
                nutCalc.BodyMassIndex();
                nutCalc.IdealBodyWeight();
                nutCalc.FluidNeeds();
                if (usePenn)
                    nutCalc.PennEnergy();
                PatientViewModel patientViewModel = new PatientViewModel(patient, usePenn);
                return View("Results", patientViewModel);
            }
            else
            {
                ViewBag.ActivityFactor = new Factors().Activity;
                ViewBag.StressFactor = new Factors().Stress;
                ViewBag.ProteinList = new Factors().Protein();
                return View(usePenn ? "PennState" : "Mifflin");
            }
        }

        [HttpGet]
        public ViewResult Mifflin()
        {
            ViewBag.ActivityFactor = new Factors().Activity;
            return View();
        }

        [HttpPost]
        public ViewResult Mifflin(Patient patient)
        {
            if (ModelState.IsValid)
            {
                nutCalc.SetPatient(patient);
                nutCalc.MifflinEnergy();
                nutCalc.BodyMassIndex();
                nutCalc.IdealBodyWeight();
                nutCalc.FluidNeeds();
                nutCalc.UsualBodyWeight();
                PatientViewModel patientViewModel = new PatientViewModel(patient, false);
                ViewBag.calculator = "Mifflin";
                return View("Result", patientViewModel);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ViewResult PennSt()
        {
            return View();
        }

        [HttpPost]
        public ViewResult PennSt(Patient patient)
        {
            if (ModelState.IsValid)
            {
                nutCalc.SetPatient(patient);
                nutCalc.MifflinEnergy();
                nutCalc.BodyMassIndex();
                nutCalc.IdealBodyWeight();
                nutCalc.FluidNeeds();
                nutCalc.PennEnergy();
                PatientViewModel patientViewModel = new PatientViewModel(patient, true);
                ViewBag.calculator = "PennSt";
                return View("Result", patientViewModel);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult All()
        {
            return View();
        }

        [HttpPost]
        public ViewResult All(Patient patient)
        {
            if (ModelState.IsValid)
            {
                nutCalc.SetPatient(patient);
                nutCalc.MifflinEnergy();
                nutCalc.BodyMassIndex();
                nutCalc.IdealBodyWeight();
                nutCalc.FluidNeeds();
                nutCalc.PennEnergy();
                PatientViewModel patientViewModel = new PatientViewModel(patient, true);
                ViewBag.calculator = "PennSt";
                return View("Result", patientViewModel);
            }
            else
            {
                return View();
            }

        }
        public ViewResult Converter()
        {
            return View();
        }
    }
}