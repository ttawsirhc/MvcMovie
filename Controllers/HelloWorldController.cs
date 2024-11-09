using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web; // NOTE: this is not used in the original example, but in the amended Welcome() below
namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    /*
    Every public method in a controller is callable as an HTTP endpoint; An HTTP endpoint:
    - Is a targetable URL in the web application, such as https://localhost:5001/HelloWorld.
    - Combines:
    -- The protocol used: HTTPS.
    -- The network location of the web server, including the TCP port: localhost:5001.
    -- The target URI: HelloWorld.
    */

    /*
    Note the comments below preceding the method.
    NOTE that the Index() method returns a string 
    The first comment states this is an HTTP GET method that's invoked by appending /HelloWorld/ to the base URL.

    Originally, the Index method returns a string with a message in the controller class.
    BUT, in the HelloWorldController class, we will replace the Index method with the following code:
    NOTE: the original code for the function was: public string Index(){return "This is my default action...";}
    NOTE: the updated code for the function was: public IActionResult Index(){return View();} 
    The following code:
    -Calls the controller's View method.
    -Uses a view template to generate an HTML response.
    Controller methods:
    -Are referred to as action methods. For example, the Index action method in the following code.
    -Generally return an IActionResult or a class derived from ActionResult, not a type like string.
    */
    // GET: /HelloWorld/
    public IActionResult Index() // returns a string
    {
        // return "This is my default action..."; // original code
        return View();
    } // end function Index()

    /*
    NOTE: the comments below preceding the method; also the Welcome() method returns a string
    The second comment specifies an HTTP GET method that's invoked by appending /HelloWorld/Welcome/ to the URL.
    Later on in the tutorial, the scaffolding engine is used to generate HTTP POST methods, which update data.

    After testing this file, change the Welcome method to include two parameters as shown in the code below (in the next comment section):
    NOTE: the original code for the function was: public string Welcome(){return "This is the Welcome action method...";}
    NOTE: the updated code for the function was: public string Welcome(string name, int numTimes = 1) 
    NOTE: the additional updates requires using System.Text.Encodings.Web, at the top of the file; also, new parameters were added
    Below, the following changes were made when edited, so the code:
    1. Uses the C# optional-parameter feature to indicate that the numTimes parameter defaults to 1 if no value is passed for that parameter.
    2. Uses HtmlEncoder.Default.Encode to protect the app from malicious input, such as through JavaScript.
    3. Uses Interpolated Strings in $"Hello {name}, NumTimes is: {numTimes}".
    
    After testing the changes above, change the Welcome method as shown in the code below:
    NOTE: the original code for the function was: public string Welcome(string name, int numTimes = 1){return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");}
    NOTE: the updated code for the function was: public string Welcome(string name, int ID = 1){return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");}
    Below, the following changes were made when edited, so the code:
    */
    // GET: /HelloWorld/Welcome/
    
    public string Welcome(string name, int ID = 1) // returns a string  
    {
        // return "This is the Welcome action method..."; // original code
        // return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}"); // modified code (1)
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}"); // modified code (2)
    } // end function Welcome()
} // end class HelloWorldController