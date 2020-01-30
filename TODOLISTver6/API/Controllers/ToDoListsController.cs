﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interface;
using Data.Model;
using Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListServices _toDoListServices;
        
        public ToDoListsController(IToDoListServices toDoListServices)
        {
            _toDoListServices = toDoListServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoList>> Get()
        {
            return await _toDoListServices.Get();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<ToDoList>> Get(int Id)
        {
            return await _toDoListServices.Get(Id);
        }

        [HttpGet]
        [Route("GetTodoLists/{Id}/{status}")]
        public async Task<IEnumerable<ToDoListVM>> GetTodoLists(int Id, int status)
        {
            return await _toDoListServices.GetTodoLists(Id,status);
        }

        [HttpPost]
        public ActionResult Post(ToDoListVM toDoListVM)
        {
            return Ok(_toDoListServices.Create(toDoListVM));
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, ToDoListVM toDoListVM)
        {
            return Ok(_toDoListServices.Update(Id, toDoListVM));
        }


        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            return Ok(_toDoListServices.Delete(Id));
        }

        [HttpDelete]
        [Route("UpdateCheckedTodoList/{Id}")]
        public ActionResult UpdateCheckedTodoList(int Id)
        {
            return Ok(_toDoListServices.UpdateCheckedTodoList(Id));
        }
        [HttpPut]
        [Route("updateUncheckedTodolist/{Id}")]
        public ActionResult updateUncheckedTodolist(int Id)
        {
            return Ok(_toDoListServices.updateUncheckedTodolist(Id));
        }
    }
}