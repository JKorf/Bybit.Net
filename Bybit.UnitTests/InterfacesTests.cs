﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bybit.UnitTests
{
    public class InterfacesTests
    {
        [Test]
        public void CheckRestInterfaces()
        {
            var assembly = Assembly.GetAssembly(typeof(BybitRestClient));
            var ignore = new string[] { "IBybitClient" };
            var clientInterfaces = assembly.GetTypes().Where(t => t.Name.StartsWith("IBybitClient") && !t.Name.EndsWith("Shared") && !ignore.Contains(t.Name));

            foreach (var clientInterface in clientInterfaces)
            {
                var implementation = assembly.GetTypes().Single(t => t.IsAssignableTo(clientInterface) && t != clientInterface);
                int methods = 0;
                foreach (var method in implementation.GetMethods().Where(m => m.ReturnType.IsAssignableTo(typeof(Task))))
                {
                    var interfaceMethod = clientInterface.GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray());
                    ClassicAssert.NotNull(interfaceMethod, $"Missing interface for method {method.Name} in {implementation.Name} implementing interface {clientInterface.Name}");
                    methods++;
                }
                Debug.WriteLine($"{clientInterface.Name} {methods} methods validated");
            }
        }

        [Test]
        public void CheckSocketInterfaces()
        {
            var assembly = Assembly.GetAssembly(typeof(BybitSocketClient));
            var clientInterfaces = assembly.GetTypes().Where(t => t.Name.StartsWith("IBybitSocketClient"));

            foreach (var clientInterface in clientInterfaces.Where(t => t.Name != "IBybitSocketClientBaseApi" && !t.Name.EndsWith("Shared")))
            {
                var implementation = assembly.GetTypes().First(t => t.IsAssignableTo(clientInterface) && t != clientInterface);
                int methods = 0;
                foreach (var method in implementation.GetMethods().Where(m => m.ReturnType.IsAssignableTo(typeof(Task<CallResult<UpdateSubscription>>))))
                {
                    var interfaceMethod = clientInterface.GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray());
                    if (interfaceMethod == null)
                    {
                        var interfaces = clientInterface.GetInterfaces();
                        foreach(var inf in interfaces)
                        {
                            interfaceMethod = inf.GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray());
                            if (interfaceMethod != null)
                                break;
                        }
                    }

                    if (method.Name == "SubscribeToLiquidationUpdatesAsync" 
                        || method.Name == "SubscribeToAllLiquidationUpdatesAsync"
                        || method.Name == "SubscribeToSystemStatusUpdatesAsync"
                        || method.Name == "SubscribeToRpiOrderbookUpdatesAsync"
                        || method.Name == "SubscribeToPriceLimitUpdatesAsync")
                        continue;
                    
                    ClassicAssert.NotNull(interfaceMethod, $"Missing interface for method {method.Name} in {implementation.Name} implementing interface {clientInterface.Name}");
                    methods++;
                }
                Debug.WriteLine($"{clientInterface.Name} {methods} methods validated");
            }
        }
    }
}
