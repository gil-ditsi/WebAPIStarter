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

        public PostController(){
            this.AllPosts = new List<Post>(){
                new Post(){Id = 1, Data = "String"}
            };
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(this.AllPosts);
        }

        [HttpGet("{id}")]
        public IActionResult GetSpecific([FromRoute]int id){
            try{
                var res = this.AllPosts.Find( x => x.Id == id );
                if( res == null ) {
                    return base.NotFound();
                }else{
                    return base.Ok(res);
                }             
            }catch(Exception e){
                return base.NotFound(e);
            }
            // return base.Forbid();
        }

        [HttpPost]    
        public IActionResult CreatePost([FromBody]Post post){
            if(ModelState.IsValid){
                try{
                    //this.AllPosts.Add(post);
                    var newRef = this.AllPosts.Find(x => x.Id == post.Id);
                    if(newRef != null){
                        return Ok(post);
                        //There's no resource so it fails
                        // return CreatedAtAction("GetSpecific", new{
                        //     newRef.Id
                        // });
                    }else{
                        return StatusCode(501);
                    }
                }catch(Exception e){
                    return StatusCode(500, e);
                }
            }else{
                return ValidationProblem();
                //They're the same
                // return BadRequest(ModelState);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult ChangePost([FromRoute] int id, [FromBody]Post post){
            try{
                var myRef = this.AllPosts.Find( x => x.Id == id );
                myRef.Data = post.Data;
                return Ok(myRef);
            }catch(Exception e){
                return StatusCode(501, e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromRoute] int id){
            try{
                this.AllPosts.Remove(this.AllPosts.Find( x => x.Id == id ));
                return StatusCode(410);
            }catch(Exception e){
                return StatusCode(501, e);
            }
        }
        
    }
}