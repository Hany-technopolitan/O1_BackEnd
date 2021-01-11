using Microsoft.AspNetCore.Mvc;
using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using Techno_Project.Models;
using Techno_Project.Repos;
using Microsoft.AspNetCore.Hosting;

namespace Techno_Project.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        IFormDbRepository Geneiric;
        IMovableRepository movableRepository;
        IEmailSender emailSender;
        ImailFormRepository ImalFormRepository;
        IRequeststatus IRequeststatus;
        public FormController(IFormDbRepository _postRepository, IEmailSender _emailSender, IMovableRepository MovableRepository, ImailFormRepository ImailFormRepository,IRequeststatus _IRequeststatus)
        {
            Geneiric = _postRepository;
            emailSender = _emailSender;
            movableRepository = MovableRepository; ;
            ImalFormRepository = ImailFormRepository;
            IRequeststatus = _IRequeststatus;
        }

        [HttpPost]
        public async Task<ActionResult> AddPost([FromBody] ViewModel model,string userName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.RequestDate = DateTime.Now;

                    FormData FormData = new FormData()
                    {
                        RequestDate = model.RequestDate,
                        Company = model.Company,
                        RequesterName = model.RequesterName,
                        Position = model.Position,
                        Email = model.Email,
                        MobileNo = model.MobileNo,
                        UnitNo = model.UnitNo,
                        entryOrExit = model.entryOrExit,
                        enterOrExitDateTime = model.enterOrExitDateTime,
                        vistorCompany = model.vistorCompany,
                        RepresentativeName = model.RepresentativeName,
                        RepresntativeMobileNo = model.RepresntativeMobileNo,
                        serialNumber = model.serialNumber
                    };

                    var formid = await Geneiric.Add(FormData);
                    var Movable = await movableRepository.Add(model.type, formid);
                    var emails = await ImalFormRepository.Getall();
                    for (int i = 0; i < emails.Count; i++)
                    {
                        RequestStatus RequestStatus = new RequestStatus();
                        RequestStatus.Req_id = formid;
                        RequestStatus.Status = "0";
                        RequestStatus.username = emails[i].Name;
                    var m = await IRequeststatus.Add(RequestStatus);
                    }

                        if (formid >= 0)
                    {
                        for (int i = 0; i < emails.Count; i++)
                        {
                            var message = new Message(new string[] { emails[i].Email }, "Movable Request" + "-" + model.Company, "Dear " + emails[i].Name + "\n" + "you have movables request pending.... " + "\n " + "submitted at : " + model.RequestDate +"."+ "You can check it from " + "\n" + "<a href=\"http://techno-politan.xyz/#/approve/"+ formid + "\">Here</a>");
                            emailSender.SendEmail(message);
                        }

                        return Ok(1);
                    }
                    else
                    {
                        return StatusCode(404, "There was a problem saving record in the database. Please try again.");
                    }
                }
                catch (Exception ex)
                {

                    return StatusCode(404, "There was a problem saving record in the database. Please try again.");
                }

            }
            return Ok(1);
        }

        [HttpGet]

        public async Task<IActionResult> GetFormData(int formid)
        {
            //if (id == null)
            //{
            //    return BadRequest();
            //}

            try
            {
                var formdata = Geneiric.GetbyId(formid);
                if (formdata == null)
                {
                    return NotFound();
                }
                else
                {
                    var movableItems = movableRepository.GetbyId(formid);
                    var status = IRequeststatus.GetbyId(formid);
                    object o = new { formdata = formdata, movableItems = movableItems,status=status };
                    return Ok(o);
                }

            }
            catch (Exception)
            {
                return StatusCode(404, "There was a problem in getting record from the database. Please try again.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFormData(ViewModel  Form, int id)
        {
            try
            {
              
                FormData FormData = new FormData()
                {
                    RequestDate = Form.RequestDate,
                    Company = Form.Company,
                    RequesterName = Form.RequesterName,
                    Position = Form.Position,
                    Email = Form.Email,
                    MobileNo = Form.MobileNo,
                    UnitNo = Form.UnitNo,
                    entryOrExit = Form.entryOrExit,
                    enterOrExitDateTime = Form.enterOrExitDateTime,
                    vistorCompany = Form.vistorCompany,
                    RepresentativeName = Form.RepresentativeName,
                    RepresntativeMobileNo = Form.RepresntativeMobileNo,
                    serialNumber = Form.serialNumber
                };

                var data = Geneiric.Update(FormData, id);
                var Movable =  movableRepository.Update(Form.type, id);


            }
            catch(Exception e)
            {
                return StatusCode(404, "There was a problem in saving record to the database. Please try again.");
            }
            return Ok(1);
        }

        [HttpGet]
        [Route("geta")]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                var formdata =await  Geneiric.Getall();
                var status = await IRequeststatus.Getall();
                var obj = new { formdata = formdata, status = status };

                if (formdata == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}