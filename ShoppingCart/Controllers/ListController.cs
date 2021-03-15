using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Util;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        [HttpGet("{id}")]
        [Route("api/list/get/{id}")]
        public List GetList(string ListId)
        {
            return DbHelper.GetListInfo(ListId);
        }

        [HttpPost]
        [Route("api/list/update")]
        public List UpdateList([FromBody] List list)
        {
            if(list.Id == null)
            {
                return DbHelper.CreateList(list);
            }
            else
            {
                DbHelper.UpdateListItems(list.Id, list);
                return list;
            }
        }
    }
}
