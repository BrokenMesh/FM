﻿using FM_API.Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public void Get() {
            if (Auth.ProtectedHandler(Response, Request, out string _username)) {

                int? _id = DBManager.GetUserIDFromUsername(_username);
                if (_id == null) {
                    Responses.InternalServerError(Response);
                    Console.WriteLine("UserController: Failed to fetch UserID");
                    return;
                }

                var _transactions = DBManager.GetTransactions((int)_id);
                Responses.JsonOk(Response, _transactions);
            }
        }


    }
}
