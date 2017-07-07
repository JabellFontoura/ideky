﻿using Ideky.Domain.Entity;
using Ideky.Infrastructure.Repository;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.CSharp.RuntimeBinder;
using Ideky.Api.Models;

namespace Ideky.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/user")]
    public class UserController : BasicController
    {
        readonly UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        [HttpPost] //BasicAuthorization(Roles = "Gerente")
        [Route("register")]
        public HttpResponseMessage Post([FromBody]UserModel userModel) //Nome,Senha,Email,Cargo
        {
            try
            {
                List<string> answer = userRepository.CreateNewUser(userModel.FacebookId);
                if (answer == null)
                    return ResponderOK(null);
                else
                    return ResponderErro(answer);
            }
            catch (RuntimeBinderException)
            {
                return ResponderErro("Tipos de atributos inválidos");
            }
        }

        [HttpGet]
        [Route("getByFacebookId/{facebookId:long}")]
        public HttpResponseMessage GetByFacebookId(long facebookId)
        {
            var user = userRepository.GetByFacebookIdFiltered(facebookId);

            if (user == null)
                return ResponderErro("Usuário não encontrado.");

            return ResponderOK(user);
        }

        [HttpPost]
        [Route("setNewRecord")]
        public HttpResponseMessage SetNewRecord([FromBody]UserModel userModel)
        {
            List<string> answer = userRepository.SetNewRecord(userModel.Record, userModel.FacebookId);
            if (answer == null) return ResponderOK(null);
            else return ResponderErro(answer);          
        }

        [HttpPost]
        [Route("setNewLogin")]
        public HttpResponseMessage SetNewLogin(UserModel userModel)
        {
            List<string> answer = userRepository.SetNewLogin(userModel.FacebookId);
            if (answer == null)
                return ResponderOK(null);
            else
                return ResponderErro(answer);
        }

    }
}