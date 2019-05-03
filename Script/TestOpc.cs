using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using UnityEngine.UI;

public class TestOpc : MonoBehaviour
{
    public Text opcCurrentData;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
   void Update()
    {
        Debug.Log("OPC: Inside unity Update function");
        var client = new OpcClient("opc.tcp://192.168.0.103:53530/OPCUA/SimulationServer");
        Debug.Log("OPC: Setting Client Successfull");
        /* var certificate = OpcCertificateManager.CreateCertificate(client);
         OpcCertificateManager.SaveCertificate("MyClientCertificate.pfx", certificate);
         if (!client.CertificateStores.ApplicationStore.Contains(certificate))
         {
             client.CertificateStores.ApplicationStore.Add(certificate);
         }
         */
        //client.Security.AutoAcceptUntrustedCertificates = true;
        //client.Security.VerifyServersCertificateDomains = false;
        //client.Security.UseOnlySecureEndpoints = false;
        Debug.Log("OPC: Setting security Parameters successfull");

        Debug.Log("OPC: Trying to connect OPC using connect");
        client.Connect(); // Connect to Server

        Debug.Log("OPC: opc Client Connected");

        OpcValue value = client.ReadNode("ns=5;s=Counter1");
        Debug.Log("OPC: Read Value Successfull");
        Debug.Log("Counter1: " + value.ToString());
        try
        {
            opcCurrentData.text = value.ToString();
            Debug.Log("OPC: Value Display Successfull");
        }
        catch (Exception e)
        {
            Debug.Log("OPC: Value Setting failed" + e.InnerException);
        }
    }
    
}
