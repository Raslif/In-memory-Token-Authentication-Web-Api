using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CutomTokenAuth.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly ITokenManager _tokenManager = null;
        public AuthenticationController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> Authenticate(string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("Input is not valid.");

                if (await _tokenManager.Authenticate(userName, password))
                {
                    return Ok(new { Token = await _tokenManager.CreateToken() });
                }
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}