using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PostController : ControllerBase
    {

        private List<Post> AllPosts { get; set; }

        [HttpGet]
        public IEnumerable<Post> GetAll(){
            return this.AllPosts;
        }

        [HttpGet("{id}")]
        public Post GetSpecific(int id){
            return this.AllPosts.Find( x => x.Id == id );
        }

        [HttpPost]    
        public string CreatePost(Post post){
            try{
                this.AllPosts.Add(post);
                return "AOK";
            }catch(Exception e){
                return $"Not AOK because of error {e.Message}";
            }
            
        }

        [HttpPut]
        public string ChangePost(Post post){
            try{
                var myRef = this.AllPosts.Find( x => x.Id == post.Id );
                myRef.Data = post.Data;
                return "AOK";
            }catch(Exception e){
                return $"Not AOK because of error {e.Message}";
            }
        }

        [HttpDelete]
        public string DeletePost(int id){
            try{
                this.AllPosts.Remove(this.AllPosts.Find( x => x.Id == id ));
                return "AOK no more";
            }catch(Exception e){
                return $"Not AOK because of error {e.Message}";
            }
        }
        
    }
}