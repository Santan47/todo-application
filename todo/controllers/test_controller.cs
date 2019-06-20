using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using todo.managers;
using System.Data;


namespace todo.controllers
{
    public class test_controller : ApiController
    {

        
        [Route("api/getTasks"), HttpGet]
        public IHttpActionResult gettask(int id, string state)
        {
            try
            {
                DataTable taskData = DataManager.gettask(id, state);
                List<GetTask> taskList = new List<GetTask>();
                foreach (DataRow tdata in taskData.Rows)
                {
                    GetTask objGetTask = new GetTask();
                    objGetTask.tid = Convert.ToInt32(tdata["tid"]);
                    objGetTask.title = tdata["title"].ToString();
                    objGetTask.img_url = tdata["img_url"].ToString();
                    objGetTask.status = tdata["status"].ToString();
                    taskList.Add(objGetTask);
                }

                return Ok(taskList);
                /*var listOfGettask = new List<GetTask>();
                while (reader.Read())
                {
                    var Task = new GetTask();
                    Task.title = ;
                    Task.img_url = ;
                    Task.status = ;

                    listOfGettask.Add(Task);
                }
                return listOfGettask;

                return Ok(listOfGettask);
                  
                 */

            }
            catch (Exception) 
            {
                return InternalServerError();
            }
        }
       
        
        
        [Route("api/addTask"), HttpPost]
        public IHttpActionResult addtask(AddTask t)
        {
            try
            {
                DataManager.addtask(t);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("api/removeComplete"), HttpPost]
        public IHttpActionResult removeComplete(rmTask r) 
        {
            try
            {
                DataManager.removeComplete(r);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        [Route("api/updateTask"), HttpPost]
        public IHttpActionResult updateTask(upTask u)
        {
            try
            {
                DataManager.updateTask(u);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        [Route("api/updateTaskTitle"), HttpPost]
        public IHttpActionResult updateTaskTitle(upTitle t)
        {
            try
            {
                DataManager.updateTaskTitle(t);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

    }
}