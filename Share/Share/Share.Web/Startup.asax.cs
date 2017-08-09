//================================================================
// Project  :   Share.Web
// Model    :   Startup
//================================================================
// Author   :   Leno Carvalho
// Location :   SOCRATES
//================================================================
// Created  :   2017/8/3 8:58:46
//================================================================

using Shared.Web.Configurators;

namespace Share.Web
{
    public class Startup : GenericConfigurator
    {
        public Startup()
            : base("Share.Web")
        {
        }
    }
}