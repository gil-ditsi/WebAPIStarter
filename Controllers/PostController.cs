using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private List<Post> AllPosts { get; set; }
        public PostController(){
            this.AllPosts = new List<Post>(){
                new Post(){ Id = 1, Data = "Nothing"}
            };
        }

        [HttpGet]
        public IEnumerable<Post> GetAll(){
            return this.AllPosts;
        }

        [HttpGet("{id}")]
        public Post GetSpecific(int id){
            try{
                return this.AllPosts.Find( x => x.Id == id );
            }catch(Exception e){
                return null;
            }
            
        }

        [HttpPost]    
        public string CreatePost(Post post){
            try{
                post.Id = this.AllPosts.Count + 1;
                this.AllPosts.Add(post);
                return "AOK";
            }catch(Exception e){
                return $"Not AOK because of error {e.Message}";
            }
            
        }

        [HttpPut("{id}")]
        public string ChangePost([FromRoute] int id, [FromBody] Post post){
            try{
                var myRef = this.AllPosts.Find( x => x.Id == id );
                myRef.Data = post.Data;
                return "AOK";
            }catch(Exception e){
                return $"Not AOK because of error {e.Message}";
            }
        }

        [HttpDelete("{id}")]
        public string DeletePost([FromRoute] int id){
            try{
                this.AllPosts.Remove(this.AllPosts.Find( x => x.Id == id ));
                return "AOK no more";
            }catch(Exception e){
                return $"Not AOK because of error {e.Message}";
            }
        }
        
    }
}