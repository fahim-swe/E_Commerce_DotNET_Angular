using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketReposity;

        public BasketController(IBasketRepository basketRepository){
            _basketReposity = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketReposity.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));

        }


        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updateBasket = await _basketReposity.UpdateBasketAsync(basket);
            return Ok(updateBasket);
        }
        

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketReposity.DeleteBasketAsync(id);
        }
    }
}