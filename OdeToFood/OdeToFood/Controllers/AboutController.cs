using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers {
    [Route("company/[controller]/[action]")] // What needs to be in the url to reach the action. So where we need to see /about in the URL. '[controller]' is a token: In this case, the name of the controller.
    public class AboutController {
        // These are all "actions" because we wrote [action. Second segment of URL. 
        //[Route("[controller]")] // Another way of doing Attribute Routing. This token ([controller]) means that using /about/ will do this action.
        public string Phone() {
            return "1+555+555+5555";
        }

        //[Route("address")] // another way of writing this.
        public string Address() {
            return "Canada";
        }
    }
}
