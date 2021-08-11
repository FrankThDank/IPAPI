using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using IPAPI.JSONClasses;
using IPAPI.Data;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace IPAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IPAPIController : ControllerBase
    {
        private readonly ILogger<IPAPIController> _logger;
        private readonly IConfiguration _iconfiguration;

        public IPAPIController(IConfiguration iconfiguration, ILogger<IPAPIController> logger)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
        }

        [HttpGet("{ipordomain}/{getGeo}/{getRDAP}/{getReverseDNS}/{getPing}", Name = "Get")]
        public async Task<IPConfluence> DefaultGetIP(string ipordomain = "127.0.0.1", bool getGeo = true, bool getRDAP = true, bool getReverseDNS = true, bool getPing = true)
        {
            var ipapi = new IPConfluence();
            var isIP = IsValidIP(ipordomain);
            var isDomain = IsValidDomain(ipordomain);
            if(!isIP && !isDomain)
            {
                ipordomain = "127.0.0.1";
            }
            
            var geoIPService = new GeoIPService(_iconfiguration);
            var rdapService = new RDAPService(_iconfiguration);
            var reverseDNSService = new ReverseDNSService(_iconfiguration);
            var pingService = new PingService(_iconfiguration);

            var geoIPTask = geoIPService.GetJSONFromAPI(ipordomain);
            var rdapTask = rdapService.GetJSONFromAPI(ipordomain);
            var reverseDNSTask = reverseDNSService.GetJSONFromAPI(ipordomain);
            var pingTask = pingService.GetJSONFromAPI(ipordomain);

            if (isIP)
            {
                await Task.WhenAll(geoIPTask, rdapTask, reverseDNSTask);

                if (getGeo)
                {
                    ipapi.GeoIP = geoIPTask.Result;
                }
                if (getRDAP)
                {
                    ipapi.RDAP = rdapTask.Result;
                }
                if (getReverseDNS)
                {
                    ipapi.ReverseDNS = reverseDNSTask.Result;
                }
            }
            else if (isDomain)
            {
                await Task.WhenAll(geoIPTask, rdapTask, reverseDNSTask, pingTask);

                if (getGeo)
                {
                    ipapi.GeoIP = geoIPTask.Result;
                }
                if (getRDAP)
                {
                    ipapi.RDAP = rdapTask.Result;
                }
                if (getReverseDNS)
                {
                    ipapi.ReverseDNS = reverseDNSTask.Result;
                }
                if (getPing)
                {
                    ipapi.Ping = pingTask.Result;
                }
            }

            return ipapi;
        }

        private bool IsValidIP(string mightBeAnIP)
        {
            string ipPattern = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            Regex ipRegex = new Regex(ipPattern);

            if (!ipRegex.IsMatch(mightBeAnIP))
            {
                return false;
            }
            return true;
        }

        private bool IsValidDomain(string mightBeADomain)
        {
            string domainPattern = @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$";
            Regex domainRegex = new Regex(domainPattern);

            if (!domainRegex.IsMatch(mightBeADomain))
            {
                return false;
            }
            return true;
        }
    }
}
