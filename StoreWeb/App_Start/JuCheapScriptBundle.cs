using System.Web.Optimization;

namespace StoreWeb
{
    public class JuCheapScriptBundle:ScriptBundle
    {
        readonly JavascriptObfuscator _jso=new JavascriptObfuscator();

        public JuCheapScriptBundle(string virtualPath):base(virtualPath)
        {
            Transforms.Add(_jso);
        }
    }
}