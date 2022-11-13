//using Core.Utilities.IoC;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System.IdentityModel.Tokens.Jwt;

//namespace MusicAdminPanel.Interseptor
//{
//    public class SecuredPage : ActionFilterAttribute
//    {
//        private string[] _role;
//        private IHttpContextAccessor? _httpContextAccessor;

//        public SecuredPage(string roles)
//        {
//            _role = roles.Split(",");
//            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

//        }
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            //var actionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
//            //var controllerName = actionDescriptor.ControllerName;
//            //var actionName = actionDescriptor.ActionName;
//            //var parameters = actionDescriptor.Parameters;
//            //var fullName = actionDescriptor.DisplayName;

//            string area = "";// leave empty if not using area's
//            string controller = "auth";
//            string action = "login";
//            var token = _httpContextAccessor?.HttpContext?.Session.GetString("Authorization");
//            if (token == null)
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area, controller, action }));
//            }
//            else
//            {
//                var jwtEncodedString = token?.Replace("Bearer ", "");
//                var tokenString = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
//                var roleClaim = tokenString?.Claims?.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Select(x => x?.Value).ToList();
//                foreach (var role in _role)
//                {

//                    if (roleClaim.Contains(role))
//                    {
//                        return;
//                    }

//                }
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area, controller, action }));
//            }
//            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area, controller, action }));

//        }
//    }
//}
