using System.Web.Optimization;

namespace StoreWeb
{
    public class JavascriptObfuscator:IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var p = new ECMAScriptPacker(ECMAScriptPacker.PackerEncoding.Normal, true, false);
            response.Content = p.Pack(response.Content);
        }
    }
}