﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using Microsoft.Rest;
using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using BlobStorageTest.Client;
using BlobStorageTest.Client.Models;
using BlobStorageTest.Tests;
using Microsoft.Rest.Azure;

//<dump disabled/>

public class Test00396 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00396_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00396_s.txt", Encoding.UTF8);

    public Test00396() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00403 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00403_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00403_s.txt", Encoding.UTF8);

    public Test00403() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00399 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00399_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00399_s.txt", Encoding.UTF8);

    public Test00399() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00401 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00401_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00401_s.txt", Encoding.UTF8);

    public Test00401() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00397 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00397_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00397_s.txt", Encoding.UTF8);

    public Test00397() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00578 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00578_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00578_s.txt", Encoding.UTF8);

    public Test00578() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{65,239,191,189,10,12,239,191,189,103,239,191,189,239,191,189,239,191,189,7,81,239,191,189,100,239,191,189,239,191,189,65,125,99,50,68,19,5,239,191,189,57,64,239,191,189,120,86,239,191,189,36,239,191,189,21,80,239,191,189,18,239,191,189,87,239,191,189,122,97,239,191,189,239,191,189,239,191,189,81,239,191,189,44,95,117,239,191,189,239,191,189,239,191,189,122,239,191,189,239,191,189,239,191,189,60,0,239,191,189,239,191,189,25,239,191,189,38,239,191,189,69,59,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,104,47,67,102,239,191,189,20,95,3,239,191,189,27,92,71,93,200,181,213,169,239,191,189,239,191,189,97,115,90,239,191,189,11,11,73,239,191,189,239,191,189,239,191,189,115,239,191,189,239,191,189,239,191,189,31,239,191,189,239,191,189,239,191,189,28,239,191,189,239,191,189,239,191,189,239,191,189,10,90,239,191,189,239,191,189,239,191,189,10,239,191,189,99,9,239,191,189,93,13,112,55,90,107,124,239,191,189,76,53,91,113,239,191,189,118,239,191,189,239,191,189,239,191,189,15,105,29,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,108,203,149,239,191,189,239,191,189,92,239,191,189,8,239,191,189,17,78,239,191,189,63,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,72,102,34,19,12,239,191,189,239,191,189,239,191,189,239,191,189,213,139,239,191,189,239,191,189,77,239,191,189,239,191,189,42,125,83,239,191,189,239,191,189,239,191,189,237,151,168,26,207,184,239,191,189,239,191,189,239,191,189,5,239,191,189,239,191,189,6,239,191,189,239,191,189,239,191,189,95,98,239,191,189,39,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,33,80,239,191,189,88,239,191,189,120,239,191,189,107,239,191,189,65,8,52,235,172,183,239,191,189,239,191,189,239,191,189,8,239,191,189,239,191,189,243,157,154,133,56,17,23,239,191,189,239,191,189,5,90,239,191,189,200,142,86,110,40,239,191,189,30,22,208,173,32,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,121,104,239,191,189,239,191,189,40,102,92,17,239,191,189,22,64,121,83,16,239,191,189,60,239,191,189,88,35,30,97,81,96,107,239,191,189,239,191,189,70,124,239,191,189,239,191,189,111,55,61,103,116,74,217,180,98,49,69,239,191,189,18,77,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,239,191,189,239,191,189,120,39,8,79,239,191,189,239,191,189,124,22,239,191,189,16,239,191,189,239,191,189,66,22,239,191,189,96,239,191,189,212,164,239,191,189,239,191,189,28,239,191,189,78,30,68,239,191,189,42,110,239,191,189,110,239,191,189,239,191,189,123,239,191,189,63,108,239,191,189,66,29,239,191,189,27,239,191,189,239,191,189,239,191,189,124,99,239,191,189,23,119,239,191,189,106,239,191,189,239,191,189,239,191,189,91,239,191,189,239,191,189,49,83,239,191,189,81,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,80,105,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,107,0,239,191,189,239,191,189,239,191,189,33,18,239,191,189,239,191,189,3,1,239,191,189,105,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,115,239,191,189,239,191,189,2,118,239,191,189,92,239,191,189,239,191,189,239,191,189,239,191,189,112,10,239,191,189,239,191,189,239,191,189,239,191,189,114,239,191,189,63,239,191,189,85,239,191,189,239,191,189,33,27,239,191,189,67,44,239,191,189,49,70,93,239,191,189,1,239,191,189,42,68,239,191,189,100,116,239,191,189,43,239,191,189,218,172,122,50,239,191,189,58,124,239,191,189,84,239,191,189,95,97,119,85,239,191,189,118,239,191,189,63,239,191,189,53,62,195,161,56,239,191,189,61,101,46,239,191,189,239,191,189,61,239,191,189,114,239,191,189,70,110,108,125,239,191,189,239,191,189,38})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers83463da440b947fdb1ad7b396ce19cbd",
                        blob: "Blob1bfb72c0bfd4476a98453eac52e3cc0b",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00402 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00402_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00402_s.txt", Encoding.UTF8);

    public Test00402() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00398 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00398_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00398_s.txt", Encoding.UTF8);

    public Test00398() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test00400 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00400_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\00400_s.txt", Encoding.UTF8);

    public Test00400() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa5215e60dfcd49019bbb0b1920120471",
                        blob: "Blobf14f4258f2f14978b2244698f718bf7e",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test01117 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\01117_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\01117_s.txt", Encoding.UTF8);

    public Test01117() : base(recordedRequest, recordedResponse, "accounts8d439fe1570e3a2")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{36,239,191,189,239,191,189,239,191,189,75,66,239,191,189,123,91,239,191,189,89,66,239,191,189,239,191,189,239,191,189,78,91,239,191,189,239,191,189,21,44,239,191,189,239,191,189,31,239,191,189,239,191,189,96,239,191,189,74,239,191,189,123,239,191,189,58,239,191,189,239,191,189,239,191,189,75,239,191,189,95,239,191,189,100,239,191,189,239,191,189,79,22,80,100,74,2,239,191,189,239,191,189,24,239,191,189,213,191,239,191,189,239,191,189,43,239,191,189,58,92,239,191,189,16,239,191,189,239,191,189,113,117,61,5,239,191,189,2,239,191,189,37,239,191,189,239,191,189,52,67,239,191,189,9,48,81,21,239,191,189,117,239,191,189,99,54,101,239,191,189,239,191,189,11,32,239,191,189,37,127,239,191,189,239,191,189,113,239,191,189,239,191,189,38,68,57,239,191,189,47,239,191,189,239,191,189,36,239,191,189,239,191,189,81,34,239,191,189,239,191,189,71,31,239,191,189,13,122,58,16,89,6,239,191,189,239,191,189,1,0,46,24,77,239,191,189,39,99,86,42,239,191,189,114,239,191,189,239,191,189,112,72,65,90,99,239,191,189,239,191,189,60,60,55,120,76,239,191,189,239,191,189,106,239,191,189,239,191,189,62,124,239,191,189,46,239,191,189,11,60,22,42,239,191,189,58,239,191,189,119,239,191,189,239,191,189,115,10,239,191,189,239,191,189,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,1,239,191,189,48,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,108,125,239,191,189,54,29,76,239,191,189,63,1,125,239,191,189,239,191,189,84,61,239,191,189,120,239,191,189,205,154,120,11,105,46,239,191,189,107,58,66,239,191,189,197,174,97,239,191,189,68,6,239,191,189,104,239,191,189,239,191,189,87,117,239,191,189,239,191,189,70,53,212,173,239,191,189,69,239,191,189,239,191,189,239,191,189,239,191,189,125,239,191,189,3,78,239,191,189,239,191,189,239,191,189,9,239,191,189,121,83,28,239,191,189,21,15,55,93,16,99,239,191,189,67,3,101,239,191,189,232,147,150,239,191,189,239,191,189,239,191,189,67,31,239,191,189,239,191,189,56,239,191,189,2,63,239,191,189,239,191,189,239,191,189,77,239,191,189,43,112,41,89,239,191,189,239,191,189,95,239,191,189,113,43,239,191,189,239,191,189,122,66,93,101,44,51,85,94,239,191,189,54,51,75,239,191,189,239,191,189,114,52,30,103,239,191,189,239,191,189,239,191,189,35,57,53,239,191,189,57,239,191,189,239,191,189,75,239,191,189,239,191,189,239,191,189,45,57,239,191,189,90,239,191,189,239,191,189,123,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,60,239,191,189,107,239,191,189,43,43,239,191,189,9,239,191,189,239,191,189,239,191,189,86,9,39,239,191,189,239,191,189,91,101,18,20,99,64,29,239,191,189,30,23,239,191,189,68,239,191,189,239,191,189,66,7,35,67,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,31,1,239,191,189,93,118,122,103,81,126,52,239,191,189,62,68,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,19,239,191,189,239,191,189,29,239,191,189,116,239,191,189,51,239,191,189,45,239,191,189,36,101,239,191,189,239,191,189,18,239,191,189,239,191,189,58,239,191,189,239,191,189,16,15,99,239,191,189,239,191,189,43,56,239,191,189,239,191,189,33,23,51,239,191,189,239,191,189,123,239,191,189,239,191,189,2,239,191,189,52,239,191,189,80,111,100,216,162,239,191,189,239,191,189,239,191,189,25,24,124,11,77,239,191,189,118,239,191,189,239,191,189,117,239,191,189,239,191,189,20,48,239,191,189,12,49,239,191,189,112,239,191,189,239,191,189,31,239,191,189,118,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,92,66,96,239,191,189,239,191,189,8,239,191,189,39,98,239,191,189,5,239,191,189,239,191,189,56,57,119,32,239,191,189,87,239,191,189,239,191,189,120})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439fe1570e3a2",
                        container: "containers31b38a5cd89644379db9490d83b56e06",
                        blob: "a97f6500-a0d9-4da4-8abf-9154d465aa50.vhd",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test03653 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03653_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03653_s.txt", Encoding.UTF8);

    public Test03653() : base(recordedRequest, recordedResponse, "accounts8d439fea03dca8d")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,7,76,239,191,189,239,191,189,239,191,189,239,191,189,65,103,89,28,239,191,189,2,198,138,97,62,97,239,191,189,239,191,189,85,31,239,191,189,239,191,189,1,239,191,189,13,239,191,189,92,79,25,239,191,189,1,76,19,60,90,239,191,189,90,239,191,189,125,52,239,191,189,116,93,27,239,191,189,239,191,189,239,191,189,239,191,189,116,239,191,189,239,191,189,239,191,189,209,136,85,99,239,191,189,239,191,189,239,191,189,239,191,189,23,64,239,191,189,203,182,239,191,189,78,6,239,191,189,6,239,191,189,85,32,53,61,239,191,189,239,191,189,8,23,239,191,189,239,191,189,239,191,189,104,239,191,189,67,122,239,191,189,239,191,189,239,191,189,13,101,239,191,189,80,239,191,189,51,239,191,189,80,50,67,239,191,189,239,191,189,222,170,239,191,189,104,239,191,189,83,24,215,181,239,191,189,239,191,189,239,191,189,27,60,216,159,239,191,189,59,39,104,15,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,9,239,191,189,239,191,189,239,191,189,239,191,189,85,59,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,56,239,191,189,31,87,119,22,239,191,189,53,239,191,189,91,46,239,191,189,239,191,189,28,62,126,86,8,78,239,191,189,239,191,189,239,191,189,15,26,32,23,4,109,239,191,189,64,26,239,191,189,239,191,189,113,239,191,189,239,191,189,48,42,239,191,189,239,191,189,239,191,189,204,174,239,191,189,239,191,189,223,184,23,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,71,239,191,189,5,55,95,18,239,191,189,86,84,64,127,26,239,191,189,45,239,191,189,239,191,189,37,222,181,54,70,35,96,239,191,189,84,56,76,86,33,239,191,189,101,13,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,203,135,12,68,119,110,14,239,191,189,90,239,191,189,116,47,239,191,189,239,191,189,239,191,189,210,161,36,93,120,239,191,189,38,239,191,189,56,52,239,191,189,239,191,189,114,118,239,191,189,239,191,189,197,164,44,19,46,42,2,239,191,189,239,191,189,125,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,25,239,191,189,32,239,191,189,239,191,189,127,113,22,239,191,189,239,191,189,239,191,189,15,239,191,189,239,191,189,239,191,189,59,94,5,239,191,189,239,191,189,84,195,190,239,191,189,239,191,189,120,107,239,191,189,65,71,4,86,65,239,191,189,76,81,239,191,189,19,2,70,51,21,110,108,86,239,191,189,239,191,189,95,239,191,189,102,239,191,189,239,191,189,51,103,239,191,189,239,191,189,98,43,73,10,19,118,239,191,189,92,239,191,189,125,239,191,189,28,70,74,239,191,189,74,3,104,87,62,85,81,80,239,191,189,239,191,189,12,24,239,191,189,239,191,189,73,34,239,191,189,219,128,239,191,189,120,239,191,189,239,191,189,50,239,191,189,65,17,239,191,189,239,191,189,36,239,191,189,24,239,191,189,239,191,189,53,239,191,189,239,191,189,16,239,191,189,118,16,218,157,239,191,189,7,93,239,191,189,239,191,189,115,90,239,191,189,65,239,191,189,91,32,127,11,53,239,191,189,239,191,189,67,239,191,189,119,239,191,189,239,191,189,239,191,189,13,239,191,189,239,191,189,87,239,191,189,85,10,222,157,45,118,42,94,71,124,61,126,48,239,191,189,82,59,239,191,189,239,191,189,239,191,189,239,191,189,117,239,191,189,50,111,99,22,239,191,189,19,239,191,189,239,191,189,3,239,191,189,3,42,239,191,189,124,239,191,189,82,239,191,189,10,60,239,191,189,239,191,189,100,239,191,189,86,40,239,191,189,69,95,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,111,58,23,239,191,189,22,239,191,189,91,120,91,122,6,239,191,189,239,191,189,239,191,189,43,99,23,239,191,189,56,239,191,189,107,10,106,239,191,189,239,191,189,114,239,191,189,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439fea03dca8d",
                        container: "containersb1774f3bf8b8480d96cb489ecbc9d495",
                        blob: "PageBlob7482437690354ad8ad399d3e8f19d3b0",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04211 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04211_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04211_s.txt", Encoding.UTF8);

    public Test04211() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa582456b9a6b45988a7eb7997e6c078c",
                        blob: "Blob6f0573dfe7bf4f4882db979c7057bfe4",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        ifSequenceNumberLessThan: 1,
                        ifSequenceNumberEqualTo: 2,
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04212 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04212_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04212_s.txt", Encoding.UTF8);

    public Test04212() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa582456b9a6b45988a7eb7997e6c078c",
                        blob: "Blob6f0573dfe7bf4f4882db979c7057bfe4",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        ifSequenceNumberLessThanOrEqualTo: 1,
                        ifSequenceNumberEqualTo: 2,
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04183 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04183_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04183_s.txt", Encoding.UTF8);

    public Test04183() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlob860088e50ace490088a08e43ef91761b",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04184 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04184_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04184_s.txt", Encoding.UTF8);

    public Test04184() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlob860088e50ace490088a08e43ef91761b",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04197 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04197_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04197_s.txt", Encoding.UTF8);

    public Test04197() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlobb0e8557c941043f6975faeda52a1d893",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        leaseId: "bb2f10ac-7824-44cf-abe2-86f9803a1c48",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04198 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04198_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04198_s.txt", Encoding.UTF8);

    public Test04198() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlobb0e8557c941043f6975faeda52a1d893",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        leaseId: "bb2f10ac-7824-44cf-abe2-86f9803a1c48",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04186 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04186_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04186_s.txt", Encoding.UTF8);

    public Test04186() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlob860088e50ace490088a08e43ef91761b",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        leaseId: "bfb8a160-8bf1-42f0-9d8d-ba09a960df3a",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04187 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04187_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04187_s.txt", Encoding.UTF8);

    public Test04187() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlob860088e50ace490088a08e43ef91761b",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        leaseId: "bfb8a160-8bf1-42f0-9d8d-ba09a960df3a",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test03661 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03661_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03661_s.txt", Encoding.UTF8);

    public Test03661() : base(recordedRequest, recordedResponse, "accounts8d439fea05682dd")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,13,72,59,239,191,189,239,191,189,91,79,9,126,80,239,191,189,10,239,191,189,52,119,239,191,189,54,28,239,191,189,108,101,239,191,189,87,16,239,191,189,239,191,189,239,191,189,79,93,56,48,239,191,189,239,191,189,239,191,189,239,191,189,40,50,239,191,189,125,118,28,1,239,191,189,111,26,103,15,87,239,191,189,48,11,239,191,189,35,119,239,191,189,120,239,191,189,239,191,189,79,206,140,239,191,189,239,191,189,69,32,239,191,189,88,239,191,189,81,79,239,191,189,239,191,189,239,191,189,239,191,189,80,99,239,191,189,239,191,189,239,191,189,60,239,191,189,119,239,191,189,45,45,118,98,59,10,106,67,93,71,239,191,189,239,191,189,28,85,239,191,189,79,27,15,58,5,96,239,191,189,107,27,239,191,189,39,68,239,191,189,239,191,189,239,191,189,18,239,191,189,21,96,125,23,239,191,189,239,191,189,28,239,191,189,239,191,189,12,61,88,239,191,189,51,14,59,239,191,189,239,191,189,45,239,191,189,113,62,239,191,189,239,191,189,91,239,191,189,20,239,191,189,239,191,189,71,127,52,239,191,189,212,188,215,144,239,191,189,239,191,189,239,191,189,112,30,84,88,18,43,4,239,191,189,53,90,100,3,239,191,189,80,239,191,189,33,239,191,189,85,78,239,191,189,8,4,19,196,189,36,50,239,191,189,118,54,239,191,189,239,191,189,90,58,49,82,239,191,189,64,239,191,189,47,239,191,189,32,239,191,189,121,239,191,189,124,79,108,48,239,191,189,239,191,189,59,87,239,191,189,239,191,189,108,11,239,191,189,239,191,189,239,191,189,239,191,189,62,124,239,191,189,239,191,189,114,239,191,189,239,191,189,30,81,55,239,191,189,239,191,189,30,23,239,191,189,115,239,191,189,239,191,189,65,239,191,189,198,149,239,191,189,67,111,239,191,189,239,191,189,81,239,191,189,71,90,239,191,189,239,191,189,55,239,191,189,239,191,189,239,191,189,239,191,189,111,212,164,78,239,191,189,99,77,239,191,189,56,239,191,189,1,239,191,189,113,239,191,189,88,25,50,239,191,189,239,191,189,239,191,189,63,239,191,189,239,191,189,89,89,9,239,191,189,239,191,189,239,191,189,239,191,189,69,239,191,189,239,191,189,115,109,48,119,239,191,189,120,239,191,189,239,191,189,98,33,79,239,191,189,214,173,77,239,191,189,4,239,191,189,2,213,138,239,191,189,239,191,189,75,239,191,189,213,134,78,239,191,189,80,239,191,189,239,191,189,21,239,191,189,57,239,191,189,239,191,189,239,191,189,40,239,191,189,101,117,239,191,189,9,239,191,189,51,47,239,191,189,62,239,191,189,66,12,69,220,142,239,191,189,239,191,189,239,191,189,41,17,39,239,191,189,239,191,189,52,116,97,239,191,189,74,239,191,189,239,191,189,16,36,33,10,65,104,239,191,189,86,239,191,189,113,110,60,121,8,91,93,93,4,55,17,54,29,59,100,239,191,189,117,239,191,189,239,191,189,239,191,189,80,239,191,189,239,191,189,239,191,189,104,239,191,189,33,239,191,189,239,191,189,239,191,189,26,63,239,191,189,10,239,191,189,239,191,189,239,191,189,25,239,191,189,239,191,189,22,3,239,191,189,19,211,163,239,191,189,239,191,189,93,203,148,239,191,189,239,191,189,76,239,191,189,239,191,189,100,17,12,58,239,191,189,239,191,189,97,29,210,154,18,239,191,189,239,191,189,239,191,189,92,37,38,239,191,189,76,202,133,4,239,191,189,8,56,239,191,189,38,215,133,239,191,189,0,239,191,189,239,191,189,204,134,8,239,191,189,239,191,189,116,42,87,239,191,189,1,8,239,191,189,101,239,191,189,239,191,189,111,111,123,239,191,189,0,37,81,95,77,4,1,239,191,189,239,191,189,239,191,189,239,191,189,52,239,191,189,84,239,191,189,239,191,189,60,83,239,191,189,239,191,189,47,34,114,239,191,189,3,239,191,189,39,239,191,189,3})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439fea05682dd",
                        container: "containers43a2953c39f9496fbf32c14fdfdd376a",
                        blob: "PageBlob424a31bbd6654f30bba64693f8121455",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test03674 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03674_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03674_s.txt", Encoding.UTF8);

    public Test03674() : base(recordedRequest, recordedResponse, "accounts8d439fea07a85e8")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{58,239,191,189,75,74,239,191,189,48,120,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,101,239,191,189,24,73,239,191,189,239,191,189,22,29,239,191,189,6,239,191,189,8,239,191,189,84,239,191,189,91,239,191,189,22,32,239,191,189,239,191,189,239,191,189,239,191,189,57,73,48,23,196,177,239,191,189,239,191,189,105,54,97,114,52,61,239,191,189,35,239,191,189,239,191,189,68,239,191,189,122,112,239,191,189,127,3,239,191,189,31,239,191,189,68,90,239,191,189,57,77,239,191,189,90,88,239,191,189,89,22,111,239,191,189,1,239,191,189,239,191,189,239,191,189,86,38,92,41,239,191,189,239,191,189,49,239,191,189,42,239,191,189,239,191,189,75,239,191,189,239,191,189,17,119,31,112,15,93,40,36,239,191,189,239,191,189,37,75,107,239,191,189,239,191,189,120,239,191,189,43,239,191,189,239,191,189,121,194,163,71,102,239,191,189,239,191,189,34,239,191,189,13,102,239,191,189,5,239,191,189,212,144,239,191,189,91,239,191,189,49,239,191,189,122,239,191,189,216,167,239,191,189,239,191,189,78,70,7,31,12,19,239,191,189,239,191,189,124,41,239,191,189,239,191,189,239,191,189,1,239,191,189,97,239,191,189,239,191,189,239,191,189,102,239,191,189,7,239,191,189,66,239,191,189,239,191,189,123,239,191,189,72,14,111,239,191,189,239,191,189,239,191,189,212,174,122,239,191,189,90,239,191,189,109,66,87,102,239,191,189,65,47,26,25,12,25,239,191,189,95,239,191,189,71,94,239,191,189,78,75,239,191,189,239,191,189,107,110,239,191,189,239,191,189,214,178,45,239,191,189,239,191,189,100,45,239,191,189,239,191,189,239,191,189,239,191,189,92,43,126,75,239,191,189,47,2,85,201,129,239,191,189,80,239,191,189,239,191,189,14,239,191,189,239,191,189,239,191,189,239,191,189,206,143,1,60,50,114,239,191,189,239,191,189,102,77,239,191,189,239,191,189,104,35,239,191,189,77,10,60,108,100,32,85,194,161,239,191,189,48,239,191,189,86,64,80,239,191,189,239,191,189,239,191,189,95,93,239,191,189,73,125,239,191,189,239,191,189,239,191,189,1,26,239,191,189,239,191,189,115,77,123,64,239,191,189,239,191,189,239,191,189,125,72,239,191,189,121,239,191,189,96,239,191,189,1,119,93,239,191,189,22,239,191,189,239,191,189,8,8,239,191,189,239,191,189,3,239,191,189,62,239,191,189,239,191,189,31,58,31,239,191,189,26,239,191,189,127,21,239,191,189,239,191,189,41,72,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,239,191,189,23,67,121,4,25,35,106,69,239,191,189,98,239,191,189,16,92,239,191,189,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,30,239,191,189,72,239,191,189,100,95,239,191,189,123,239,191,189,239,191,189,26,239,191,189,66,197,128,239,191,189,54,5,239,191,189,239,191,189,239,191,189,201,178,4,239,191,189,204,166,7,198,165,115,52,56,239,191,189,30,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,211,166,239,191,189,80,25,239,191,189,4,22,8,239,191,189,43,239,191,189,47,239,191,189,239,191,189,195,146,239,191,189,115,239,191,189,60,72,239,191,189,100,239,191,189,239,191,189,20,239,191,189,75,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,80,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,8,82,93,239,191,189,101,239,191,189,239,191,189,38,239,191,189,122,2,239,191,189,94,239,191,189,201,181,53,127,2,114,92,60,37,239,191,189,57,239,191,189,96,114,239,191,189,23,112,13,239,191,189,125,239,191,189,53,7,239,191,189,32,101,239,191,189,37,56,69,239,191,189,94,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,41,110,239,191,189,45,239,191,189,239,191,189,239,191,189,78,106,70})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439fea07a85e8",
                        container: "containers8191e25b06a746b1b20661258b777a2e",
                        blob: "PageBlob21b2c8922bf24abd85eb87316f3ebec5",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04218 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04218_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04218_s.txt", Encoding.UTF8);

    public Test04218() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{97,239,191,189,61,239,191,189,107,59,10,239,191,189,239,191,189,112,54,239,191,189,239,191,189,74,239,191,189,36,239,191,189,41,102,239,191,189,239,191,189,239,191,189,239,191,189,100,239,191,189,1,239,191,189,90,239,191,189,51,239,191,189,239,191,189,239,191,189,35,239,191,189,107,50,66,239,191,189,239,191,189,239,191,189,88,0,21,1,239,191,189,239,191,189,52,11,210,150,239,191,189,113,92,239,191,189,106,239,191,189,239,191,189,239,191,189,106,107,239,191,189,11,239,191,189,122,239,191,189,239,191,189,239,191,189,201,147,239,191,189,73,239,191,189,239,191,189,19,114,239,191,189,127,98,14,54,239,191,189,79,239,191,189,76,21,92,110,22,110,89,81,29,23,239,191,189,76,98,239,191,189,82,239,191,189,239,191,189,107,119,239,191,189,77,8,239,191,189,73,66,117,125,118,239,191,189,52,239,191,189,95,26,1,45,239,191,189,239,191,189,94,239,191,189,36,239,191,189,239,191,189,239,191,189,239,191,189,33,37,239,191,189,239,191,189,16,49,56,47,239,191,189,16,80,68,239,191,189,19,43,239,191,189,239,191,189,239,191,189,111,239,191,189,71,239,191,189,50,97,109,239,191,189,92,239,191,189,239,191,189,82,71,84,239,191,189,239,191,189,39,29,239,191,189,101,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,239,191,189,16,108,50,18,51,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,49,119,86,213,151,118,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,14,239,191,189,89,124,239,191,189,239,191,189,10,41,239,191,189,239,191,189,239,191,189,239,191,189,109,239,191,189,31,239,191,189,239,191,189,239,191,189,58,239,191,189,42,239,191,189,33,15,239,191,189,100,42,1,63,239,191,189,42,72,239,191,189,35,85,239,191,189,57,201,172,223,132,201,129,239,191,189,239,191,189,42,239,191,189,102,55,47,212,141,84,239,191,189,11,55,109,239,191,189,124,9,239,191,189,239,191,189,90,96,111,74,81,69,88,2,61,90,19,97,48,46,97,239,191,189,57,89,239,191,189,8,239,191,189,85,239,191,189,44,63,73,239,191,189,239,191,189,239,191,189,35,99,122,223,135,239,191,189,77,118,239,191,189,127,33,239,191,189,45,239,191,189,51,64,239,191,189,239,191,189,9,11,239,191,189,79,34,110,239,191,189,116,5,239,191,189,67,10,7,239,191,189,239,191,189,28,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,20,126,90,239,191,189,120,40,88,239,191,189,239,191,189,239,191,189,109,239,191,189,239,191,189,239,191,189,239,191,189,65,11,239,191,189,18,239,191,189,239,191,189,51,239,191,189,119,126,83,16,125,60,239,191,189,1,50,116,239,191,189,112,239,191,189,72,239,191,189,239,191,189,27,71,29,87,77,239,191,189,10,239,191,189,38,70,239,191,189,239,191,189,239,191,189,239,191,189,1,108,75,239,191,189,98,239,191,189,239,191,189,71,64,75,67,239,191,189,59,36,201,133,239,191,189,239,191,189,21,69,239,191,189,76,239,191,189,219,135,239,191,189,116,239,191,189,239,191,189,54,239,191,189,26,125,239,191,189,114,239,191,189,36,112,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,19,239,191,189,94,239,191,189,2,239,191,189,104,239,191,189,119,62,239,191,189,239,191,189,239,191,189,112,239,191,189,239,191,189,239,191,189,78,94,10,239,191,189,41,61,239,191,189,239,191,189,62,96,109,20,26,97,34,69,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,72,239,191,189,202,163,63,239,191,189,239,191,189,239,191,189,239,191,189,115,95,118,239,191,189,117,239,191,189,12,239,191,189,84,239,191,189,51,239,191,189,65,239,191,189,239,191,189,93,239,191,189,124,112,39,239,191,189,8,6,239,191,189,239,191,189,21,59,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersfb205ec10bb2405ab343d60ec9aff645",
                        blob: "Blob6584c18998f44abb8560e8d03aee341a",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        leaseId: "abc",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04219 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04219_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04219_s.txt", Encoding.UTF8);

    public Test04219() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersfb205ec10bb2405ab343d60ec9aff645",
                        blob: "Blob6584c18998f44abb8560e8d03aee341a",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        leaseId: "abc",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test03666 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03666_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\03666_s.txt", Encoding.UTF8);

    public Test03666() : base(recordedRequest, recordedResponse, "accounts8d439fea05682dd")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,239,191,189,123,38,239,191,189,239,191,189,239,191,189,239,191,189,118,239,191,189,94,239,191,189,110,239,191,189,239,191,189,6,95,27,239,191,189,239,191,189,239,191,189,221,178,239,191,189,91,239,191,189,239,191,189,46,239,191,189,40,33,239,191,189,18,239,191,189,239,191,189,20,120,21,239,191,189,239,191,189,239,191,189,95,239,191,189,239,191,189,48,55,76,239,191,189,38,239,191,189,43,76,41,47,67,239,191,189,239,191,189,239,191,189,40,239,191,189,109,48,77,239,191,189,221,185,239,191,189,239,191,189,239,191,189,73,239,191,189,7,5,103,49,12,239,191,189,36,69,65,7,239,191,189,239,191,189,239,191,189,87,239,191,189,77,239,191,189,34,239,191,189,74,111,35,126,46,94,239,191,189,83,126,111,239,191,189,239,191,189,111,239,191,189,239,191,189,33,41,219,174,239,191,189,40,239,191,189,239,191,189,127,101,239,191,189,79,215,133,213,143,60,117,239,191,189,239,191,189,19,239,191,189,56,239,191,189,20,62,239,191,189,213,154,120,51,28,12,54,239,191,189,113,9,60,239,191,189,239,191,189,239,191,189,239,191,189,25,239,191,189,14,33,206,168,239,191,189,105,26,239,191,189,239,191,189,61,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,0,14,239,191,189,239,191,189,88,51,239,191,189,78,28,29,51,56,55,92,239,191,189,63,109,239,191,189,239,191,189,239,191,189,112,239,191,189,239,191,189,49,94,239,191,189,58,86,239,191,189,22,239,191,189,45,107,239,191,189,239,191,189,125,239,191,189,43,73,239,191,189,86,127,239,191,189,239,191,189,54,239,191,189,105,239,191,189,45,239,191,189,52,12,23,239,191,189,121,2,24,239,191,189,239,191,189,239,191,189,239,191,189,116,85,5,78,6,204,139,239,191,189,10,127,66,76,239,191,189,239,191,189,114,51,239,191,189,124,41,239,191,189,40,239,191,189,239,191,189,239,191,189,22,239,191,189,50,239,191,189,100,12,239,191,189,239,191,189,239,191,189,239,191,189,42,239,191,189,115,47,21,239,191,189,239,191,189,35,125,239,191,189,46,66,239,191,189,239,191,189,239,191,189,18,239,191,189,68,75,89,35,239,191,189,239,191,189,63,88,25,239,191,189,114,239,191,189,239,191,189,7,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,102,74,239,191,189,5,126,239,191,189,2,239,191,189,74,239,191,189,15,127,84,239,191,189,230,157,151,239,191,189,98,239,191,189,63,214,133,239,191,189,126,10,77,239,191,189,38,239,191,189,194,164,37,239,191,189,82,90,69,239,191,189,52,239,191,189,8,239,191,189,10,38,30,26,239,191,189,106,33,239,191,189,239,191,189,218,139,239,191,189,239,191,189,56,239,191,189,115,239,191,189,12,239,191,189,239,191,189,239,191,189,106,90,103,222,148,67,81,239,191,189,45,91,55,239,191,189,215,167,87,239,191,189,50,19,239,191,189,103,239,191,189,27,74,98,27,239,191,189,34,239,191,189,103,239,191,189,126,70,52,198,160,204,182,60,79,39,239,191,189,239,191,189,91,126,83,239,191,189,239,191,189,47,239,191,189,110,239,191,189,5,88,27,78,15,5,239,191,189,6,32,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,16,6,239,191,189,53,239,191,189,195,148,239,191,189,239,191,189,239,191,189,239,191,189,14,108,239,191,189,239,191,189,239,191,189,239,191,189,36,239,191,189,64,219,171,81,239,191,189,239,191,189,121,72,6,61,112,239,191,189,239,191,189,97,2,221,138,239,191,189,80,120,52,113,239,191,189,78,239,191,189,67,239,191,189,87,102,239,191,189,2,239,191,189,117,87,239,191,189,239,191,189,100,239,191,189,206,132,125,123,239,191,189,91,91,0,42,239,191,189,105,239,191,189,6,236,144,172,80,239,191,189,26,92})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439fea05682dd",
                        container: "containers43a2953c39f9496fbf32c14fdfdd376a",
                        blob: "PageBlob424a31bbd6654f30bba64693f8121455",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04206 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04206_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04206_s.txt", Encoding.UTF8);

    public Test04206() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{2,68,23,78,222,153,59,239,191,189,104,239,191,189,43,239,191,189,78,23,37,17,112,55,239,191,189,77,239,191,189,239,191,189,239,191,189,239,191,189,126,100,28,30,239,191,189,239,191,189,211,170,239,191,189,96,124,26,239,191,189,107,88,106,239,191,189,239,191,189,114,16,76,239,191,189,239,191,189,106,239,191,189,78,6,239,191,189,75,239,191,189,93,39,68,64,239,191,189,122,124,28,81,239,191,189,239,191,189,239,191,189,103,239,191,189,10,239,191,189,5,239,191,189,93,239,191,189,13,103,239,138,133,208,178,88,70,122,239,191,189,95,239,191,189,3,84,239,191,189,68,239,191,189,239,191,189,237,135,145,239,191,189,23,203,145,239,191,189,206,187,239,191,189,0,239,191,189,239,191,189,17,79,239,191,189,85,239,191,189,74,239,191,189,239,191,189,239,191,189,11,110,239,191,189,34,239,191,189,239,191,189,71,52,71,106,0,111,33,124,239,191,189,216,190,239,191,189,42,227,156,132,121,4,113,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,80,52,35,194,133,28,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,126,239,191,189,239,191,189,239,191,189,124,239,191,189,85,127,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,25,239,191,189,75,95,239,191,189,239,191,189,239,191,189,22,239,191,189,111,92,21,8,239,191,189,12,239,191,189,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,39,34,239,191,189,38,239,191,189,239,191,189,239,191,189,239,191,189,125,43,51,239,191,189,239,191,189,36,239,191,189,239,191,189,92,16,239,191,189,18,126,18,239,191,189,4,84,5,239,191,189,33,29,23,14,239,191,189,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,66,70,101,239,191,189,65,5,239,191,189,70,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,127,21,55,56,33,48,239,191,189,36,239,191,189,95,19,36,239,191,189,239,191,189,34,194,137,37,1,239,191,189,56,239,191,189,9,0,239,191,189,79,123,105,107,126,114,92,61,120,239,191,189,100,230,177,186,239,191,189,29,239,191,189,6,206,154,118,34,239,191,189,35,239,191,189,22,126,239,191,189,239,191,189,71,103,45,56,95,239,191,189,82,239,191,189,53,239,191,189,199,141,106,9,239,191,189,239,191,189,239,191,189,107,70,239,191,189,239,191,189,239,191,189,59,101,76,44,125,69,120,104,239,191,189,239,191,189,48,27,55,239,191,189,82,239,191,189,105,98,111,37,45,239,191,189,239,191,189,239,191,189,101,22,62,19,105,3,239,191,189,239,191,189,239,191,189,239,191,189,18,239,191,189,239,191,189,117,239,191,189,119,239,191,189,27,6,58,239,191,189,47,239,191,189,239,191,189,239,191,189,80,36,239,191,189,13,239,191,189,100,117,239,191,189,239,191,189,98,42,239,191,189,66,239,191,189,124,90,68,239,191,189,63,36,239,191,189,236,177,173,239,191,189,239,191,189,239,191,189,125,5,239,191,189,231,184,128,239,191,189,239,191,189,239,191,189,62,239,191,189,63,239,191,189,62,74,239,191,189,90,77,239,191,189,216,131,239,191,189,239,191,189,65,84,69,110,72,99,114,211,141,220,131,239,191,189,239,191,189,1,123,113,96,239,191,189,239,191,189,239,191,189,28,96,239,191,189,239,191,189,239,191,189,74,87,87,96,239,191,189,239,191,189,93,239,191,189,114,239,191,189,239,191,189,114,18,67,78,29,106,87,99,42,69,198,148,239,191,189,239,191,189,107,33,239,191,189,239,191,189,119,225,184,179,239,191,189,239,191,189,12,27,115,239,191,189,239,191,189,37,56,17,100,239,191,189,239,191,189,77,115,239,191,189,207,177,8,56,103,239,191,189,239,191,189,239,191,189,119,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,191,239,191,189,68,66,2,239,191,189,127,101,5,13,239,191,189,48,239,191,189,239,191,189,30,239,191,189,48,1,239,191,189,216,128,76,239,191,189,122,73,239,191,189,239,191,189,64,121,73,21,239,191,189,14,63,239,191,189,47,63,204,186,239,191,189,239,191,189,97,239,191,189,207,146,239,191,189,239,191,189,42,15,123,239,191,189,53,239,191,189,89,114,239,191,189,239,191,189,239,191,189,94,7,239,191,189,36,239,191,189,195,159,239,191,189,239,191,189,91,126,239,191,189,52,11,79,239,191,189,239,191,189,84,239,191,189,239,191,189,35,72,100,49,239,191,189,91,239,191,189,198,181,239,191,189,32,100,70,110,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,47,11,239,191,189,9,207,144,239,191,189,239,191,189,42,239,191,189,239,191,189,239,191,189,77,31,66,59,239,191,189,239,191,189,239,191,189,103,239,191,189,239,191,189,50,239,191,189,58,25,239,191,189,239,191,189,88,239,191,189,239,191,189,22,239,191,189,123,239,191,189,239,191,189,62,239,191,189,239,191,189,115,239,191,189,239,191,189,50,9,70,239,191,189,69,3,51,239,191,189,14,239,191,189,71,104,111,74,101,57,239,191,189,118,239,191,189,239,191,189,239,191,189,221,171,112,200,163,239,191,189,239,191,189,239,191,189,239,191,189,82,25,239,191,189,10,239,191,189,40,239,191,189,103,212,166,239,191,189,101,239,191,189,68,239,191,189,28,11,95,36,4,0,42,239,191,189,239,191,189,239,191,189,84,93,239,191,189,10,239,191,189,107,239,191,189,114,24,105,45,239,191,189,101,239,191,189,61,239,191,189,44,239,191,189,57,96,107,54,103,239,191,189,239,191,189,239,191,189,56,239,191,189,124,239,191,189,40,239,191,189,21,38,57,202,179,93,51,59,16,239,191,189,219,161,121,239,191,189,239,191,189,239,191,189,84,211,136,90,78,120,30,239,191,189,52,94,9,51,239,191,189,239,191,189,34,65,239,191,189,239,191,189,62,239,191,189,114,239,191,189,239,191,189,110,239,191,189,80,120,239,191,189,239,191,189,239,191,189,50,239,191,189,39,33,239,191,189,43,198,174,26,239,191,189,127,239,191,189,42,8,25,239,191,189,108,239,191,189,239,191,189,239,191,189,103,31,117,87,4,26,92,239,191,189,0,118,105,52,43,23,239,191,189,83,239,191,189,0,239,191,189,123,198,144,104,239,191,189,125,239,191,189,67,239,191,189,54,123,59,239,191,189,5,70,239,191,189,117,46,239,191,189,28,239,191,189,239,191,189,200,173,239,191,189,106,75,239,191,189,19,106,239,191,189,46,107,239,191,189,126,37,214,182,239,191,189,239,191,189,53,239,191,189,103,199,132,59,119,47,239,191,189,40,36,239,191,189,239,191,189,27,239,191,189,239,191,189,239,191,189,239,191,189,51,50,239,191,189,47,239,191,189,112,76,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,87,239,191,189,239,191,189,103,0,41,104,239,191,189,28,239,191,189,66,239,191,189,48,239,191,189,239,191,189,239,191,189,38,239,191,189,239,191,189,58,239,191,189,239,191,189,86,56,108,126,239,191,189,239,191,189,239,191,189,105,239,191,189,8,239,191,189,109,70,239,191,189,239,191,189,92,64,22,12,239,191,189,72,239,191,189,27,72,28,239,191,189,239,191,189,239,191,189,205,179,76,239,191,189,7,239,191,189,239,191,189,239,191,189,239,191,189,116,115,42,239,191,189,239,191,189,239,191,189,39,239,191,189,111,239,191,189,39,58,239,191,189,98,239,191,189,45,239,191,189,239,191,189,239,191,189,29,36,98,239,191,189,239,191,189,26,239,191,189,25,239,191,189,79,101,239,191,189,85,239,191,189,95,204,162,239,191,189,239,191,189,111,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa582456b9a6b45988a7eb7997e6c078c",
                        blob: "Blob6f0573dfe7bf4f4882db979c7057bfe4",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        ifSequenceNumberLessThanOrEqualTo: 2,
                        ifSequenceNumberLessThan: 1,
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04207 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04207_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04207_s.txt", Encoding.UTF8);

    public Test04207() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{2,68,23,78,222,153,59,239,191,189,104,239,191,189,43,239,191,189,78,23,37,17,112,55,239,191,189,77,239,191,189,239,191,189,239,191,189,239,191,189,126,100,28,30,239,191,189,239,191,189,211,170,239,191,189,96,124,26,239,191,189,107,88,106,239,191,189,239,191,189,114,16,76,239,191,189,239,191,189,106,239,191,189,78,6,239,191,189,75,239,191,189,93,39,68,64,239,191,189,122,124,28,81,239,191,189,239,191,189,239,191,189,103,239,191,189,10,239,191,189,5,239,191,189,93,239,191,189,13,103,239,138,133,208,178,88,70,122,239,191,189,95,239,191,189,3,84,239,191,189,68,239,191,189,239,191,189,237,135,145,239,191,189,23,203,145,239,191,189,206,187,239,191,189,0,239,191,189,239,191,189,17,79,239,191,189,85,239,191,189,74,239,191,189,239,191,189,239,191,189,11,110,239,191,189,34,239,191,189,239,191,189,71,52,71,106,0,111,33,124,239,191,189,216,190,239,191,189,42,227,156,132,121,4,113,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,80,52,35,194,133,28,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,126,239,191,189,239,191,189,239,191,189,124,239,191,189,85,127,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,25,239,191,189,75,95,239,191,189,239,191,189,239,191,189,22,239,191,189,111,92,21,8,239,191,189,12,239,191,189,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,39,34,239,191,189,38,239,191,189,239,191,189,239,191,189,239,191,189,125,43,51,239,191,189,239,191,189,36,239,191,189,239,191,189,92,16,239,191,189,18,126,18,239,191,189,4,84,5,239,191,189,33,29,23,14,239,191,189,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,66,70,101,239,191,189,65,5,239,191,189,70,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,127,21,55,56,33,48,239,191,189,36,239,191,189,95,19,36,239,191,189,239,191,189,34,194,137,37,1,239,191,189,56,239,191,189,9,0,239,191,189,79,123,105,107,126,114,92,61,120,239,191,189,100,230,177,186,239,191,189,29,239,191,189,6,206,154,118,34,239,191,189,35,239,191,189,22,126,239,191,189,239,191,189,71,103,45,56,95,239,191,189,82,239,191,189,53,239,191,189,199,141,106,9,239,191,189,239,191,189,239,191,189,107,70,239,191,189,239,191,189,239,191,189,59,101,76,44,125,69,120,104,239,191,189,239,191,189,48,27,55,239,191,189,82,239,191,189,105,98,111,37,45,239,191,189,239,191,189,239,191,189,101,22,62,19,105,3,239,191,189,239,191,189,239,191,189,239,191,189,18,239,191,189,239,191,189,117,239,191,189,119,239,191,189,27,6,58,239,191,189,47,239,191,189,239,191,189,239,191,189,80,36,239,191,189,13,239,191,189,100,117,239,191,189,239,191,189,98,42,239,191,189,66,239,191,189,124,90,68,239,191,189,63,36,239,191,189,236,177,173,239,191,189,239,191,189,239,191,189,125,5,239,191,189,231,184,128,239,191,189,239,191,189,239,191,189,62,239,191,189,63,239,191,189,62,74,239,191,189,90,77,239,191,189,216,131,239,191,189,239,191,189,65,84,69,110,72,99,114,211,141,220,131,239,191,189,239,191,189,1,123,113,96,239,191,189,239,191,189,239,191,189,28,96,239,191,189,239,191,189,239,191,189,74,87,87,96,239,191,189,239,191,189,93,239,191,189,114,239,191,189,239,191,189,114,18,67,78,29,106,87,99,42,69,198,148,239,191,189,239,191,189,107,33,239,191,189,239,191,189,119,225,184,179,239,191,189,239,191,189,12,27,115,239,191,189,239,191,189,37,56,17,100,239,191,189,239,191,189,77,115,239,191,189,207,177,8,56,103,239,191,189,239,191,189,239,191,189,119,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,191,239,191,189,68,66,2,239,191,189,127,101,5,13,239,191,189,48,239,191,189,239,191,189,30,239,191,189,48,1,239,191,189,216,128,76,239,191,189,122,73,239,191,189,239,191,189,64,121,73,21,239,191,189,14,63,239,191,189,47,63,204,186,239,191,189,239,191,189,97,239,191,189,207,146,239,191,189,239,191,189,42,15,123,239,191,189,53,239,191,189,89,114,239,191,189,239,191,189,239,191,189,94,7,239,191,189,36,239,191,189,195,159,239,191,189,239,191,189,91,126,239,191,189,52,11,79,239,191,189,239,191,189,84,239,191,189,239,191,189,35,72,100,49,239,191,189,91,239,191,189,198,181,239,191,189,32,100,70,110,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,47,11,239,191,189,9,207,144,239,191,189,239,191,189,42,239,191,189,239,191,189,239,191,189,77,31,66,59,239,191,189,239,191,189,239,191,189,103,239,191,189,239,191,189,50,239,191,189,58,25,239,191,189,239,191,189,88,239,191,189,239,191,189,22,239,191,189,123,239,191,189,239,191,189,62,239,191,189,239,191,189,115,239,191,189,239,191,189,50,9,70,239,191,189,69,3,51,239,191,189,14,239,191,189,71,104,111,74,101,57,239,191,189,118,239,191,189,239,191,189,239,191,189,221,171,112,200,163,239,191,189,239,191,189,239,191,189,239,191,189,82,25,239,191,189,10,239,191,189,40,239,191,189,103,212,166,239,191,189,101,239,191,189,68,239,191,189,28,11,95,36,4,0,42,239,191,189,239,191,189,239,191,189,84,93,239,191,189,10,239,191,189,107,239,191,189,114,24,105,45,239,191,189,101,239,191,189,61,239,191,189,44,239,191,189,57,96,107,54,103,239,191,189,239,191,189,239,191,189,56,239,191,189,124,239,191,189,40,239,191,189,21,38,57,202,179,93,51,59,16,239,191,189,219,161,121,239,191,189,239,191,189,239,191,189,84,211,136,90,78,120,30,239,191,189,52,94,9,51,239,191,189,239,191,189,34,65,239,191,189,239,191,189,62,239,191,189,114,239,191,189,239,191,189,110,239,191,189,80,120,239,191,189,239,191,189,239,191,189,50,239,191,189,39,33,239,191,189,43,198,174,26,239,191,189,127,239,191,189,42,8,25,239,191,189,108,239,191,189,239,191,189,239,191,189,103,31,117,87,4,26,92,239,191,189,0,118,105,52,43,23,239,191,189,83,239,191,189,0,239,191,189,123,198,144,104,239,191,189,125,239,191,189,67,239,191,189,54,123,59,239,191,189,5,70,239,191,189,117,46,239,191,189,28,239,191,189,239,191,189,200,173,239,191,189,106,75,239,191,189,19,106,239,191,189,46,107,239,191,189,126,37,214,182,239,191,189,239,191,189,53,239,191,189,103,199,132,59,119,47,239,191,189,40,36,239,191,189,239,191,189,27,239,191,189,239,191,189,239,191,189,239,191,189,51,50,239,191,189,47,239,191,189,112,76,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,87,239,191,189,239,191,189,103,0,41,104,239,191,189,28,239,191,189,66,239,191,189,48,239,191,189,239,191,189,239,191,189,38,239,191,189,239,191,189,58,239,191,189,239,191,189,86,56,108,126,239,191,189,239,191,189,239,191,189,105,239,191,189,8,239,191,189,109,70,239,191,189,239,191,189,92,64,22,12,239,191,189,72,239,191,189,27,72,28,239,191,189,239,191,189,239,191,189,205,179,76,239,191,189,7,239,191,189,239,191,189,239,191,189,239,191,189,116,115,42,239,191,189,239,191,189,239,191,189,39,239,191,189,111,239,191,189,39,58,239,191,189,98,239,191,189,45,239,191,189,239,191,189,239,191,189,29,36,98,239,191,189,239,191,189,26,239,191,189,25,239,191,189,79,101,239,191,189,85,239,191,189,95,204,162,239,191,189,239,191,189,111,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa582456b9a6b45988a7eb7997e6c078c",
                        blob: "Blob6f0573dfe7bf4f4882db979c7057bfe4",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        ifSequenceNumberLessThan: 1,
                        ifSequenceNumberEqualTo: 2,
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04208 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04208_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04208_s.txt", Encoding.UTF8);

    public Test04208() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{2,68,23,78,222,153,59,239,191,189,104,239,191,189,43,239,191,189,78,23,37,17,112,55,239,191,189,77,239,191,189,239,191,189,239,191,189,239,191,189,126,100,28,30,239,191,189,239,191,189,211,170,239,191,189,96,124,26,239,191,189,107,88,106,239,191,189,239,191,189,114,16,76,239,191,189,239,191,189,106,239,191,189,78,6,239,191,189,75,239,191,189,93,39,68,64,239,191,189,122,124,28,81,239,191,189,239,191,189,239,191,189,103,239,191,189,10,239,191,189,5,239,191,189,93,239,191,189,13,103,239,138,133,208,178,88,70,122,239,191,189,95,239,191,189,3,84,239,191,189,68,239,191,189,239,191,189,237,135,145,239,191,189,23,203,145,239,191,189,206,187,239,191,189,0,239,191,189,239,191,189,17,79,239,191,189,85,239,191,189,74,239,191,189,239,191,189,239,191,189,11,110,239,191,189,34,239,191,189,239,191,189,71,52,71,106,0,111,33,124,239,191,189,216,190,239,191,189,42,227,156,132,121,4,113,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,80,52,35,194,133,28,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,126,239,191,189,239,191,189,239,191,189,124,239,191,189,85,127,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,25,239,191,189,75,95,239,191,189,239,191,189,239,191,189,22,239,191,189,111,92,21,8,239,191,189,12,239,191,189,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,39,34,239,191,189,38,239,191,189,239,191,189,239,191,189,239,191,189,125,43,51,239,191,189,239,191,189,36,239,191,189,239,191,189,92,16,239,191,189,18,126,18,239,191,189,4,84,5,239,191,189,33,29,23,14,239,191,189,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,66,70,101,239,191,189,65,5,239,191,189,70,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,127,21,55,56,33,48,239,191,189,36,239,191,189,95,19,36,239,191,189,239,191,189,34,194,137,37,1,239,191,189,56,239,191,189,9,0,239,191,189,79,123,105,107,126,114,92,61,120,239,191,189,100,230,177,186,239,191,189,29,239,191,189,6,206,154,118,34,239,191,189,35,239,191,189,22,126,239,191,189,239,191,189,71,103,45,56,95,239,191,189,82,239,191,189,53,239,191,189,199,141,106,9,239,191,189,239,191,189,239,191,189,107,70,239,191,189,239,191,189,239,191,189,59,101,76,44,125,69,120,104,239,191,189,239,191,189,48,27,55,239,191,189,82,239,191,189,105,98,111,37,45,239,191,189,239,191,189,239,191,189,101,22,62,19,105,3,239,191,189,239,191,189,239,191,189,239,191,189,18,239,191,189,239,191,189,117,239,191,189,119,239,191,189,27,6,58,239,191,189,47,239,191,189,239,191,189,239,191,189,80,36,239,191,189,13,239,191,189,100,117,239,191,189,239,191,189,98,42,239,191,189,66,239,191,189,124,90,68,239,191,189,63,36,239,191,189,236,177,173,239,191,189,239,191,189,239,191,189,125,5,239,191,189,231,184,128,239,191,189,239,191,189,239,191,189,62,239,191,189,63,239,191,189,62,74,239,191,189,90,77,239,191,189,216,131,239,191,189,239,191,189,65,84,69,110,72,99,114,211,141,220,131,239,191,189,239,191,189,1,123,113,96,239,191,189,239,191,189,239,191,189,28,96,239,191,189,239,191,189,239,191,189,74,87,87,96,239,191,189,239,191,189,93,239,191,189,114,239,191,189,239,191,189,114,18,67,78,29,106,87,99,42,69,198,148,239,191,189,239,191,189,107,33,239,191,189,239,191,189,119,225,184,179,239,191,189,239,191,189,12,27,115,239,191,189,239,191,189,37,56,17,100,239,191,189,239,191,189,77,115,239,191,189,207,177,8,56,103,239,191,189,239,191,189,239,191,189,119,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,191,239,191,189,68,66,2,239,191,189,127,101,5,13,239,191,189,48,239,191,189,239,191,189,30,239,191,189,48,1,239,191,189,216,128,76,239,191,189,122,73,239,191,189,239,191,189,64,121,73,21,239,191,189,14,63,239,191,189,47,63,204,186,239,191,189,239,191,189,97,239,191,189,207,146,239,191,189,239,191,189,42,15,123,239,191,189,53,239,191,189,89,114,239,191,189,239,191,189,239,191,189,94,7,239,191,189,36,239,191,189,195,159,239,191,189,239,191,189,91,126,239,191,189,52,11,79,239,191,189,239,191,189,84,239,191,189,239,191,189,35,72,100,49,239,191,189,91,239,191,189,198,181,239,191,189,32,100,70,110,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,47,11,239,191,189,9,207,144,239,191,189,239,191,189,42,239,191,189,239,191,189,239,191,189,77,31,66,59,239,191,189,239,191,189,239,191,189,103,239,191,189,239,191,189,50,239,191,189,58,25,239,191,189,239,191,189,88,239,191,189,239,191,189,22,239,191,189,123,239,191,189,239,191,189,62,239,191,189,239,191,189,115,239,191,189,239,191,189,50,9,70,239,191,189,69,3,51,239,191,189,14,239,191,189,71,104,111,74,101,57,239,191,189,118,239,191,189,239,191,189,239,191,189,221,171,112,200,163,239,191,189,239,191,189,239,191,189,239,191,189,82,25,239,191,189,10,239,191,189,40,239,191,189,103,212,166,239,191,189,101,239,191,189,68,239,191,189,28,11,95,36,4,0,42,239,191,189,239,191,189,239,191,189,84,93,239,191,189,10,239,191,189,107,239,191,189,114,24,105,45,239,191,189,101,239,191,189,61,239,191,189,44,239,191,189,57,96,107,54,103,239,191,189,239,191,189,239,191,189,56,239,191,189,124,239,191,189,40,239,191,189,21,38,57,202,179,93,51,59,16,239,191,189,219,161,121,239,191,189,239,191,189,239,191,189,84,211,136,90,78,120,30,239,191,189,52,94,9,51,239,191,189,239,191,189,34,65,239,191,189,239,191,189,62,239,191,189,114,239,191,189,239,191,189,110,239,191,189,80,120,239,191,189,239,191,189,239,191,189,50,239,191,189,39,33,239,191,189,43,198,174,26,239,191,189,127,239,191,189,42,8,25,239,191,189,108,239,191,189,239,191,189,239,191,189,103,31,117,87,4,26,92,239,191,189,0,118,105,52,43,23,239,191,189,83,239,191,189,0,239,191,189,123,198,144,104,239,191,189,125,239,191,189,67,239,191,189,54,123,59,239,191,189,5,70,239,191,189,117,46,239,191,189,28,239,191,189,239,191,189,200,173,239,191,189,106,75,239,191,189,19,106,239,191,189,46,107,239,191,189,126,37,214,182,239,191,189,239,191,189,53,239,191,189,103,199,132,59,119,47,239,191,189,40,36,239,191,189,239,191,189,27,239,191,189,239,191,189,239,191,189,239,191,189,51,50,239,191,189,47,239,191,189,112,76,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,87,239,191,189,239,191,189,103,0,41,104,239,191,189,28,239,191,189,66,239,191,189,48,239,191,189,239,191,189,239,191,189,38,239,191,189,239,191,189,58,239,191,189,239,191,189,86,56,108,126,239,191,189,239,191,189,239,191,189,105,239,191,189,8,239,191,189,109,70,239,191,189,239,191,189,92,64,22,12,239,191,189,72,239,191,189,27,72,28,239,191,189,239,191,189,239,191,189,205,179,76,239,191,189,7,239,191,189,239,191,189,239,191,189,239,191,189,116,115,42,239,191,189,239,191,189,239,191,189,39,239,191,189,111,239,191,189,39,58,239,191,189,98,239,191,189,45,239,191,189,239,191,189,239,191,189,29,36,98,239,191,189,239,191,189,26,239,191,189,25,239,191,189,79,101,239,191,189,85,239,191,189,95,204,162,239,191,189,239,191,189,111,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa582456b9a6b45988a7eb7997e6c078c",
                        blob: "Blob6f0573dfe7bf4f4882db979c7057bfe4",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        ifSequenceNumberLessThanOrEqualTo: 1,
                        ifSequenceNumberEqualTo: 2,
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04177 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04177_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04177_s.txt", Encoding.UTF8);

    public Test04177() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlob860088e50ace490088a08e43ef91761b",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        leaseId: "99999999-9999-9999-9999-999999999999",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04210 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04210_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04210_s.txt", Encoding.UTF8);

    public Test04210() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersa582456b9a6b45988a7eb7997e6c078c",
                        blob: "Blob6f0573dfe7bf4f4882db979c7057bfe4",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        ifSequenceNumberLessThanOrEqualTo: 2,
                        ifSequenceNumberLessThan: 1,
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test04178 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04178_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\04178_s.txt", Encoding.UTF8);

    public Test04178() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containerse6c109f9343d4bbb9527c19e0e65dac4",
                        blob: "PageBlob860088e50ace490088a08e43ef91761b",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        leaseId: "99999999-9999-9999-9999-999999999999",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06188 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06188_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06188_s.txt", Encoding.UTF8);

    public Test06188() : base(recordedRequest, recordedResponse, "accounts8d439ff32a8d21a")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{33,73,239,191,189,64,239,191,189,94,239,191,189,212,174,50,71,112,1,239,191,189,125,125,239,191,189,89,121,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,199,131,75,239,191,189,52,54,239,191,189,7,239,191,189,56,239,191,189,121,239,191,189,211,140,239,191,189,47,127,239,191,189,203,173,239,191,189,69,239,191,189,239,191,189,239,191,189,71,107,58,34,239,191,189,239,191,189,43,239,191,189,71,239,191,189,239,191,189,239,191,189,16,239,191,189,239,191,189,239,191,189,68,239,191,189,63,239,191,189,239,191,189,51,82,239,191,189,54,65,239,191,189,239,191,189,239,191,189,62,239,191,189,239,191,189,106,239,191,189,121,205,173,239,191,189,239,191,189,239,191,189,239,191,189,61,68,26,101,239,191,189,239,191,189,63,239,191,189,239,191,189,0,11,239,191,189,55,239,191,189,55,239,191,189,82,92,239,191,189,239,191,189,72,239,191,189,9,239,191,189,203,147,33,18,45,44,239,191,189,239,191,189,69,239,191,189,104,239,191,189,56,106,239,191,189,239,191,189,239,191,189,48,239,191,189,62,239,191,189,86,51,76,65,239,191,189,91,73,41,109,83,239,191,189,59,33,239,191,189,239,191,189,96,44,239,191,189,239,191,189,97,52,97,63,58,73,239,191,189,239,191,189,239,191,189,239,191,189,23,239,191,189,239,191,189,117,117,95,239,191,189,239,191,189,71,239,191,189,85,239,191,189,216,164,209,178,22,239,191,189,239,191,189,95,239,191,189,239,191,189,32,239,191,189,79,239,191,189,239,191,189,17,239,191,189,53,114,239,191,189,57,239,191,189,59,239,191,189,112,239,191,189,37,239,191,189,239,191,189,91,62,0,11,239,191,189,239,191,189,239,191,189,105,239,191,189,239,191,189,24,239,191,189,79,110,239,191,189,239,191,189,38,239,191,189,107,239,191,189,239,191,189,18,94,239,191,189,115,67,104,239,191,189,66,107,239,191,189,55,239,191,189,44,107,31,239,191,189,239,191,189,107,88,239,191,189,98,239,191,189,90,239,191,189,239,191,189,70,239,191,189,79,239,191,189,239,191,189,239,191,189,35,199,130,43,239,191,189,87,19,69,51,123,84,45,109,239,191,189,239,191,189,34,2,115,29,95,21,19,26,118,118,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,6,19,12,239,191,189,63,125,121,239,191,189,37,37,45,14,110,239,191,189,23,239,191,189,35,239,191,189,239,191,189,101,37,239,191,189,16,239,191,189,12,239,191,189,239,191,189,101,71,72,239,191,189,220,148,71,103,239,191,189,239,191,189,120,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,103,8,24,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,90,239,191,189,119,3,95,239,191,189,239,191,189,239,191,189,19,108,220,140,81,121,39,239,191,189,239,191,189,58,239,191,189,6,239,191,189,239,191,189,121,239,191,189,34,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,101,111,239,191,189,26,57,239,191,189,239,191,189,81,239,191,189,57,21,239,191,189,63,18,97,239,191,189,239,191,189,239,191,189,88,239,191,189,46,239,191,189,219,153,71,239,191,189,239,191,189,239,191,189,239,191,189,90,239,191,189,6,109,239,191,189,54,64,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,48,58,239,191,189,239,191,189,36,239,191,189,239,191,189,239,191,189,51,239,191,189,65,239,191,189,62,239,191,189,62,23,239,191,189,239,191,189,239,191,189,91,239,191,189,7,57,239,191,189,239,191,189,101,239,191,189,63,239,191,189,103,239,191,189,94,239,191,189,10,104,13,75,32,122,66,17,104,85,72,44,239,191,189,239,191,189,239,191,189,99,125,63,54,239,191,189,113,22,40,0,239,191,189,36,239,191,189,8,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,1,51,55,49,203,143,55,239,191,189,73,82,239,191,189,239,191,189,120,239,191,189,108,13,220,129,40,239,191,189,114})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff32a8d21a",
                        container: "containers687c3d3e4f3c483bae02010694a614f9",
                        blob: "Blob277d472cecbe481b93168f69f7df24b2_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06268 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06268_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06268_s.txt", Encoding.UTF8);

    public Test06268() : base(recordedRequest, recordedResponse, "accounts8d439ff3a4e1e94")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,239,191,189,52,59,10,239,191,189,64,24,239,191,189,41,239,191,189,58,94,239,191,189,239,191,189,239,191,189,72,239,191,189,111,239,191,189,10,204,130,239,191,189,239,191,189,91,64,21,239,191,189,229,176,176,48,239,191,189,239,191,189,239,191,189,69,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,239,191,189,239,191,189,84,239,191,189,21,63,239,191,189,102,239,191,189,31,35,59,122,239,191,189,125,43,30,239,191,189,121,51,10,102,239,191,189,231,135,168,95,239,191,189,239,191,189,105,239,191,189,30,102,59,239,191,189,239,191,189,239,191,189,107,239,191,189,113,239,191,189,239,191,189,61,239,191,189,123,10,37,239,191,189,60,209,130,239,191,189,239,191,189,95,122,83,239,191,189,108,6,108,239,191,189,45,239,191,189,80,34,4,239,191,189,63,13,239,191,189,105,239,191,189,39,8,101,64,41,57,107,125,239,191,189,239,191,189,120,9,239,191,189,36,53,6,239,191,189,78,239,191,189,84,101,99,239,191,189,239,191,189,61,239,191,189,112,119,53,239,191,189,107,103,207,176,239,191,189,239,191,189,58,41,239,191,189,0,239,191,189,239,191,189,37,239,191,189,239,191,189,104,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,20,77,239,191,189,119,239,191,189,2,60,239,191,189,239,191,189,72,239,191,189,35,13,239,191,189,24,116,84,13,239,191,189,37,87,84,239,191,189,121,107,235,187,131,114,239,191,189,102,103,239,191,189,127,82,239,191,189,239,191,189,105,51,55,239,191,189,239,191,189,12,64,77,2,239,191,189,239,191,189,80,239,191,189,122,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,112,74,11,239,191,189,71,239,191,189,86,75,239,191,189,53,73,239,191,189,79,239,191,189,239,191,189,239,191,189,239,191,189,79,56,239,191,189,71,239,191,189,43,105,68,239,191,189,50,239,191,189,45,239,191,189,110,64,239,191,189,17,239,191,189,94,90,239,191,189,51,111,239,191,189,94,23,239,191,189,25,239,191,189,239,191,189,2,239,191,189,239,191,189,96,2,121,239,191,189,30,239,191,189,239,191,189,107,239,191,189,109,29,59,239,191,189,9,239,191,189,239,191,189,239,191,189,239,191,189,127,95,5,35,239,191,189,61,19,239,191,189,42,74,120,229,157,190,239,191,189,239,191,189,239,191,189,24,61,239,191,189,239,191,189,197,131,239,191,189,1,239,191,189,34,81,239,191,189,118,239,191,189,54,30,4,103,73,91,239,191,189,239,191,189,10,239,191,189,106,33,14,239,191,189,239,191,189,125,0,42,239,191,189,239,191,189,70,96,207,186,239,191,189,88,33,239,191,189,26,239,191,189,2,239,191,189,118,65,199,152,86,124,239,191,189,8,36,239,191,189,121,239,191,189,90,98,239,191,189,121,35,239,191,189,80,239,191,189,239,191,189,47,239,191,189,53,239,191,189,109,2,239,191,189,17,124,71,238,181,171,239,191,189,239,191,189,239,191,189,38,239,191,189,239,191,189,239,191,189,127,239,191,189,239,191,189,4,95,121,239,191,189,239,191,189,239,191,189,116,114,126,239,191,189,70,80,10,98,239,191,189,14,239,191,189,73,19,41,49,220,164,239,191,189,209,184,59,126,239,191,189,239,191,189,8,239,191,189,79,239,191,189,49,78,239,191,189,73,21,83,7,239,191,189,112,239,191,189,100,124,239,191,189,239,191,189,126,117,36,105,108,119,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,1,52,49,90,26,55,52,239,191,189,33,92,107,239,191,189,82,85,2,239,191,189,0,87,239,191,189,239,191,189,68,239,191,189,32,8,239,191,189,50,97,37,239,191,189,17,48,239,191,189,239,191,189,239,191,189,122,239,191,189,83,36})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff3a4e1e94",
                        container: "containersee9a5959e41549b6af014d1a7d61c369",
                        blob: "Blobccadabd2fb7f4059bf6e11342b7f8e5c_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06539 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06539_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06539_s.txt", Encoding.UTF8);

    public Test06539() : base(recordedRequest, recordedResponse, "accounts8d439ff4aa0daac")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff4aa0daac",
                        container: "containers0417c53c3e35489f8a743d1ed1b41d7c",
                        blob: "Blob911ca1d6255543e09a8c33cb1235b106_LinkBlob",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06279 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06279_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06279_s.txt", Encoding.UTF8);

    public Test06279() : base(recordedRequest, recordedResponse, "accounts8d439ff3a78d86e")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{5,95,41,13,239,191,189,100,41,239,191,189,107,239,191,189,239,191,189,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,34,239,191,189,88,239,191,189,239,191,189,78,112,239,191,189,239,191,189,239,191,189,63,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,87,93,99,44,239,191,189,26,239,191,189,99,239,191,189,239,191,189,65,122,89,59,19,100,32,111,239,191,189,7,17,239,191,189,124,194,160,239,191,189,59,42,36,239,191,189,37,239,191,189,37,109,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,107,234,131,154,239,191,189,73,239,191,189,96,45,62,239,191,189,103,239,191,189,92,123,239,191,189,224,160,139,239,191,189,239,191,189,103,63,38,209,180,84,239,191,189,116,239,191,189,124,239,191,189,70,239,191,189,38,53,239,191,189,66,87,3,239,191,189,239,191,189,239,191,189,233,189,170,239,191,189,239,191,189,239,191,189,239,191,189,30,24,239,191,189,239,191,189,4,239,191,189,92,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,239,191,189,84,105,239,191,189,94,51,239,191,189,4,106,88,61,19,10,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,36,239,191,189,239,191,189,123,239,191,189,23,118,99,9,31,67,78,239,191,189,50,14,9,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,223,189,239,191,189,83,31,239,191,189,239,191,189,105,0,12,3,16,239,191,189,102,24,42,217,144,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,38,9,239,191,189,239,191,189,239,191,189,239,191,189,91,31,239,191,189,239,191,189,127,69,239,191,189,239,191,189,39,239,191,189,97,239,191,189,239,191,189,8,18,63,61,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,20,15,239,191,189,115,73,106,239,191,189,239,191,189,239,191,189,239,191,189,14,72,125,33,82,45,239,191,189,215,133,49,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,40,22,6,239,191,189,239,191,189,34,28,239,191,189,106,53,239,191,189,239,191,189,79,239,191,189,239,191,189,18,100,37,49,239,191,189,14,239,191,189,239,191,189,239,191,189,19,38,83,239,191,189,62,73,4,239,191,189,125,65,239,191,189,239,191,189,68,13,239,191,189,239,191,189,89,19,239,191,189,99,239,191,189,210,136,239,191,189,64,239,191,189,97,239,191,189,239,191,189,239,191,189,25,108,99,239,191,189,239,191,189,239,191,189,72,43,239,191,189,239,191,189,239,191,189,97,13,239,191,189,51,239,191,189,87,90,64,239,191,189,239,191,189,239,191,189,63,11,64,239,191,189,91,102,123,239,191,189,85,215,166,40,81,90,81,239,191,189,239,191,189,40,17,239,191,189,239,191,189,121,239,191,189,113,123,41,13,239,191,189,10,84,117,59,30,239,191,189,36,239,191,189,67,93,109,239,191,189,4,239,191,189,37,239,191,189,239,191,189,125,239,191,189,124,206,139,23,239,191,189,19,239,191,189,239,191,189,98,239,191,189,35,50,89,239,191,189,239,191,189,1,97,106,9,239,191,189,54,107,70,113,239,191,189,48,55,239,191,189,228,131,182,239,191,189,239,191,189,52,119,59,239,191,189,93,239,191,189,10,239,191,189,94,239,191,189,116,57,59,239,191,189,41,39,239,191,189,239,191,189,80,239,191,189,217,162,17,239,191,189,25,93,89,239,191,189,239,191,189,239,191,189,239,191,189,24,239,191,189,239,191,189,36,14,239,191,189,56,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,56,127,239,191,189,14,239,191,189,81,239,191,189,101,239,191,189,210,145,102,239,191,189,239,191,189,0,88,46,43,125,239,191,189,91,239,191,189,239,191,189,99,26,239,191,189,90,239,191,189,239,191,189,239,191,189,37,239,191,189,42,239,191,189,239,191,189,221,177,239,191,189,239,191,189,30,239,191,189,210,180})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff3a78d86e",
                        container: "containersf473189346ef44f1b5ea1dd158aecb8a",
                        blob: "Blob02574c310a6448e9953561bd96f42710_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06559 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06559_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06559_s.txt", Encoding.UTF8);

    public Test06559() : base(recordedRequest, recordedResponse, "accounts8d439ff4b45a758")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{54,36,239,191,189,123,4,65,239,191,189,239,191,189,123,239,191,189,32,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,35,99,239,191,189,239,191,189,40,27,26,21,239,191,189,100,239,191,189,109,239,191,189,204,154,60,239,191,189,239,191,189,10,239,191,189,239,191,189,239,191,189,239,191,189,4,66,239,191,189,14,76,239,191,189,113,239,191,189,239,191,189,222,135,239,191,189,100,98,239,191,189,95,239,191,189,43,2,125,239,191,189,93,53,124,11,239,191,189,239,191,189,239,191,189,10,239,191,189,4,40,239,191,189,48,239,191,189,239,191,189,108,12,239,191,189,239,191,189,239,191,189,8,239,191,189,12,68,239,191,189,239,191,189,115,16,93,32,125,239,191,189,5,5,239,191,189,13,51,3,239,191,189,1,239,191,189,239,191,189,239,191,189,239,191,189,95,239,191,189,51,239,191,189,239,191,189,239,191,189,239,191,189,97,42,239,191,189,239,191,189,239,191,189,40,55,13,239,191,189,94,211,173,220,135,46,239,191,189,43,21,239,191,189,57,9,0,239,191,189,102,61,239,191,189,50,239,191,189,67,239,191,189,239,191,189,38,105,67,27,239,191,189,122,114,239,191,189,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,30,11,82,49,239,191,189,7,239,191,189,17,239,191,189,239,191,189,97,83,36,85,53,239,191,189,83,239,191,189,6,239,191,189,239,191,189,67,239,191,189,107,95,96,239,191,189,66,239,191,189,61,19,239,191,189,51,239,191,189,30,239,191,189,239,191,189,100,239,191,189,61,20,239,191,189,110,239,191,189,122,86,28,239,191,189,239,191,189,44,24,18,13,239,191,189,114,239,191,189,239,191,189,127,78,77,30,124,239,191,189,239,191,189,32,119,54,239,191,189,20,239,191,189,101,105,83,239,191,189,239,191,189,42,239,191,189,239,191,189,9,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,32,239,191,189,68,33,239,191,189,239,191,189,239,191,189,77,239,191,189,239,191,189,49,239,191,189,57,90,239,191,189,239,191,189,239,191,189,239,191,189,7,199,175,239,191,189,117,70,72,52,239,191,189,118,239,191,189,239,191,189,27,239,191,189,219,183,0,239,191,189,239,191,189,127,26,239,191,189,239,191,189,28,98,239,191,189,98,124,120,239,191,189,42,239,191,189,239,191,189,39,239,191,189,30,25,97,41,239,191,189,239,191,189,239,191,189,239,191,189,109,239,191,189,72,239,191,189,74,210,129,90,6,239,191,189,124,239,191,189,73,70,239,191,189,92,239,191,189,239,191,189,203,188,97,76,239,191,189,239,191,189,239,191,189,88,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,19,239,191,189,26,239,191,189,23,239,191,189,239,191,189,48,35,239,191,189,44,103,68,215,134,5,86,26,12,8,239,191,189,33,239,191,189,73,239,191,189,239,191,189,21,239,191,189,87,239,191,189,239,191,189,106,239,191,189,51,17,65,12,239,191,189,33,239,191,189,48,40,59,210,139,20,239,191,189,23,239,191,189,88,217,154,77,51,239,191,189,239,191,189,239,191,189,239,191,189,37,239,191,189,18,117,239,191,189,239,191,189,87,239,191,189,194,163,116,239,191,189,73,78,239,191,189,65,100,239,191,189,98,119,91,239,191,189,48,239,191,189,34,239,191,189,37,58,29,78,65,46,112,45,239,191,189,239,191,189,239,191,189,239,191,189,92,120,123,239,191,189,81,65,239,191,189,239,191,189,15,239,191,189,239,191,189,11,239,191,189,239,191,189,127,89,239,191,189,71,100,71,83,204,156,28,239,191,189,116,98,69,82,28,239,191,189,93,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,204,140,239,191,189,40,76,239,191,189,18,127,72,239,191,189,23,239,191,189,95,41,108,103,239,191,189,239,191,189,94,239,191,189,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,82,125,37,92,239,191,189,93,239,191,189,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff4b45a758",
                        container: "containerse8bdfe0ed9134d95ad272b602380241a",
                        blob: "Blobcb986a9e795d435492b53cd5e34f75e9_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06354 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06354_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06354_s.txt", Encoding.UTF8);

    public Test06354() : base(recordedRequest, recordedResponse, "accounts8d439ff3ebb1da6")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{60,239,191,189,53,239,191,189,239,191,189,239,191,189,64,239,191,189,98,51,218,156,239,191,189,38,239,191,189,52,239,191,189,239,191,189,52,239,191,189,86,239,191,189,56,239,191,189,239,191,189,45,103,82,239,191,189,239,191,189,72,26,239,191,189,108,239,191,189,239,191,189,239,191,189,1,239,191,189,92,239,191,189,239,191,189,239,191,189,239,191,189,92,98,239,191,189,239,191,189,84,231,188,148,239,191,189,239,191,189,126,239,191,189,239,191,189,120,45,239,191,189,125,239,191,189,239,191,189,101,239,191,189,239,191,189,239,191,189,239,191,189,105,55,239,191,189,127,33,239,191,189,98,239,191,189,239,191,189,71,96,72,239,191,189,239,191,189,239,191,189,239,191,189,64,239,191,189,54,10,239,191,189,0,239,191,189,43,239,191,189,19,222,172,239,191,189,60,5,239,191,189,239,191,189,239,191,189,77,28,86,61,114,11,239,191,189,239,191,189,239,191,189,104,24,239,191,189,239,191,189,239,191,189,239,191,189,17,37,55,239,191,189,239,191,189,239,191,189,104,78,100,239,191,189,14,239,191,189,239,191,189,207,161,65,196,132,239,191,189,98,239,191,189,120,2,65,43,122,18,35,239,191,189,19,239,191,189,37,16,239,191,189,239,191,189,23,239,191,189,17,47,99,239,191,189,239,191,189,239,191,189,100,17,239,191,189,12,60,38,83,95,61,107,13,239,191,189,34,239,191,189,94,26,239,191,189,69,239,191,189,81,239,191,189,239,191,189,239,191,189,239,191,189,14,239,191,189,115,239,191,189,85,77,125,19,239,191,189,112,239,191,189,25,239,191,189,6,239,191,189,89,239,191,189,239,191,189,232,165,175,39,239,191,189,215,178,20,221,158,0,239,191,189,239,191,189,123,41,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,239,191,189,239,191,189,20,239,191,189,25,68,121,126,95,116,239,191,189,42,0,67,73,231,149,156,0,64,111,239,191,189,18,239,191,189,96,239,191,189,9,51,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,19,66,239,191,189,110,239,191,189,95,63,239,191,189,16,239,191,189,123,239,191,189,21,29,22,239,191,189,200,128,15,239,191,189,47,26,239,191,189,83,239,191,189,117,43,239,191,189,113,239,191,189,8,239,191,189,239,191,189,239,191,189,82,222,146,239,191,189,15,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,10,40,239,191,189,22,239,191,189,239,191,189,239,191,189,119,239,191,189,239,191,189,239,191,189,40,4,26,239,191,189,239,191,189,20,239,191,189,239,191,189,10,115,90,1,64,239,191,189,55,13,34,113,112,97,91,47,239,191,189,73,239,191,189,239,191,189,20,60,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,42,239,191,189,119,239,191,189,37,239,191,189,239,191,189,53,239,191,189,113,239,191,189,39,239,191,189,76,89,114,239,191,189,6,55,106,239,191,189,239,191,189,47,239,191,189,79,105,239,191,189,239,191,189,239,191,189,37,239,191,189,119,55,79,239,191,189,92,239,191,189,93,75,239,191,189,38,79,99,239,191,189,105,239,191,189,239,191,189,239,191,189,126,73,239,191,189,239,191,189,94,105,49,239,191,189,239,191,189,117,239,191,189,239,191,189,69,239,191,189,239,191,189,239,191,189,56,239,191,189,100,239,191,189,239,191,189,239,191,189,61,239,191,189,82,239,191,189,96,239,191,189,239,191,189,55,239,191,189,55,239,191,189,46,239,191,189,87,239,191,189,239,191,189,239,191,189,109,239,191,189,239,191,189,239,191,189,90,84,239,191,189,239,191,189,239,191,189,96,121,105,27,239,191,189,11,239,191,189,89,239,191,189,8,239,191,189,239,191,189,111,239,191,189,31,84,239,191,189,89,239,191,189,55,109,23,126,62,76,239,191,189,86,42,239,191,189,124,239,191,189,19,239,191,189,239,191,189,108,51,27,239,191,189,239,191,189,207,135,114,74,239,191,189,239,191,189,239,191,189,127,88,112,5,239,191,189,69,239,191,189,239,191,189,239,191,189,97,239,191,189,221,153,239,191,189,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff3ebb1da6",
                        container: "containersaa7c17e131db4b9e9a1d86873b7d11c3",
                        blob: "Blob01b5d7e09ba94456812e990acfa9cf4d_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06643 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06643_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06643_s.txt", Encoding.UTF8);

    public Test06643() : base(recordedRequest, recordedResponse, "accounts8d439ff512db059")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,239,191,189,75,239,191,189,26,239,191,189,3,239,191,189,37,239,191,189,1,239,191,189,239,191,189,239,191,189,239,191,189,117,239,191,189,21,239,191,189,110,239,191,189,101,210,134,12,239,191,189,101,21,239,191,189,20,212,131,87,76,239,191,189,9,5,239,191,189,11,64,67,32,239,191,189,124,239,191,189,87,79,239,191,189,239,191,189,77,39,124,96,49,92,121,89,239,191,189,78,239,191,189,239,191,189,239,191,189,17,6,126,99,69,40,239,191,189,111,239,191,189,10,239,191,189,43,115,116,33,10,94,116,22,103,33,198,173,7,239,191,189,27,43,239,191,189,239,191,189,45,239,191,189,239,191,189,85,79,223,170,239,191,189,74,17,38,25,60,85,29,239,191,189,53,239,191,189,239,191,189,87,79,44,239,191,189,122,239,191,189,239,191,189,74,88,119,108,42,239,191,189,4,239,191,189,239,191,189,76,239,191,189,239,191,189,35,239,191,189,119,12,19,98,239,191,189,77,239,191,189,112,239,191,189,18,239,191,189,94,68,56,92,1,239,191,189,54,206,160,239,191,189,81,239,191,189,239,191,189,239,191,189,41,21,120,239,191,189,239,191,189,30,95,239,191,189,82,239,191,189,66,24,119,239,191,189,58,239,191,189,239,191,189,239,191,189,101,239,191,189,203,184,239,191,189,102,239,191,189,105,239,191,189,7,239,191,189,0,37,239,191,189,54,122,239,191,189,55,108,239,191,189,239,191,189,97,239,191,189,239,191,189,88,26,239,191,189,107,239,191,189,239,191,189,213,188,239,191,189,33,50,27,112,74,17,239,191,189,102,126,87,21,82,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,2,94,239,191,189,8,113,73,7,239,191,189,115,76,239,191,189,239,191,189,239,191,189,115,239,191,189,67,239,191,189,99,3,95,85,239,191,189,90,34,89,116,10,239,191,189,239,191,189,239,191,189,93,6,110,239,191,189,118,200,128,239,191,189,239,191,189,20,239,191,189,239,191,189,239,191,189,239,191,189,103,239,191,189,239,191,189,102,14,29,88,222,157,111,21,3,209,174,239,191,189,63,88,39,239,191,189,239,191,189,217,144,11,239,191,189,56,123,27,239,191,189,26,75,239,191,189,22,239,191,189,64,239,191,189,239,191,189,37,71,239,191,189,239,191,189,4,40,239,191,189,120,124,114,239,191,189,209,179,239,191,189,239,191,189,239,191,189,1,239,191,189,8,239,191,189,127,1,46,239,191,189,2,239,191,189,239,191,189,82,239,191,189,239,191,189,110,239,191,189,239,191,189,19,25,16,239,191,189,84,239,191,189,239,191,189,239,191,189,102,197,133,73,0,113,239,191,189,40,20,239,191,189,56,27,106,36,25,239,191,189,126,95,100,125,239,191,189,124,4,102,21,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,86,21,239,191,189,104,13,239,191,189,239,191,189,82,195,154,239,191,189,88,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,214,138,77,67,239,191,189,239,191,189,239,191,189,30,52,96,239,191,189,239,191,189,60,103,239,191,189,239,191,189,5,126,239,191,189,239,191,189,239,191,189,197,187,17,239,191,189,26,239,191,189,86,14,115,239,191,189,239,191,189,239,191,189,84,239,191,189,96,8,239,191,189,14,239,191,189,239,191,189,239,191,189,67,113,239,191,189,93,239,191,189,239,191,189,117,239,191,189,41,109,70,239,191,189,16,239,191,189,60,239,191,189,239,191,189,87,107,16,239,191,189,105,71,48,239,191,189,115,239,191,189,50,112,239,191,189,8,3,66,120,239,191,189,219,188,13,123,239,191,189,239,191,189,239,191,189,45,109,239,191,189,197,145,239,191,189,74,74,90,60,239,191,189,239,191,189,239,191,189,42,239,191,189,117,239,191,189,103,239,191,189,104,239,191,189,239,191,189,61,239,191,189,239,191,189,87})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff512db059",
                        container: "containersbabd163fbeec414581cead0132e67836",
                        blob: Encoding.UTF8.GetString(new byte[]{66,108,111,98,51,49,101,101,49,97,50,48,49,52,98,57,52,52,51,49,97,54,98,99,51,52,57,56,57,52,50,52,56,102,98,102,95,76,105,110,107,66,108,111,98,207,168}),
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06570 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06570_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06570_s.txt", Encoding.UTF8);

    public Test06570() : base(recordedRequest, recordedResponse, "accounts8d439ff4b952781")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{87,239,191,189,41,23,57,239,191,189,239,191,189,45,239,191,189,19,44,239,191,189,33,239,191,189,239,191,189,82,22,48,61,239,191,189,59,73,99,63,14,239,191,189,31,36,119,239,191,189,239,191,189,9,239,191,189,239,191,189,239,191,189,239,191,189,77,239,191,189,54,57,239,191,189,50,0,105,239,191,189,210,183,239,191,189,63,239,191,189,87,239,191,189,239,191,189,14,31,239,191,189,9,239,191,189,239,191,189,95,239,191,189,34,21,34,99,120,16,55,4,45,239,191,189,3,65,9,72,239,191,189,89,114,239,191,189,104,60,55,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,91,84,124,239,191,189,83,239,191,189,56,90,239,191,189,239,191,189,58,239,191,189,239,191,189,84,239,191,189,239,191,189,239,191,189,36,239,191,189,239,191,189,239,191,189,118,34,126,72,239,191,189,112,195,191,239,191,189,239,191,189,239,191,189,76,79,239,191,189,239,191,189,106,239,191,189,239,191,189,57,239,191,189,239,191,189,239,191,189,239,191,189,33,239,191,189,93,239,191,189,210,190,119,239,191,189,73,239,191,189,239,191,189,49,239,191,189,239,191,189,239,191,189,82,117,239,191,189,25,21,239,191,189,106,96,239,191,189,239,191,189,89,90,125,239,191,189,93,44,239,191,189,239,191,189,239,191,189,38,31,18,239,191,189,239,191,189,239,191,189,35,239,191,189,3,83,195,187,239,191,189,239,191,189,21,66,239,191,189,239,191,189,117,99,239,191,189,66,239,191,189,57,120,99,239,191,189,239,191,189,239,191,189,239,191,189,47,239,191,189,123,110,114,64,239,191,189,239,191,189,74,239,191,189,239,191,189,103,13,239,191,189,1,202,133,103,239,191,189,239,191,189,69,13,33,30,111,239,191,189,96,239,191,189,116,107,42,239,191,189,23,239,191,189,239,191,189,32,19,102,239,191,189,2,29,57,93,239,191,189,239,191,189,79,53,239,191,189,55,239,191,189,222,145,31,83,239,191,189,34,121,93,239,191,189,239,191,189,239,191,189,17,57,239,191,189,239,191,189,239,191,189,80,239,191,189,85,239,191,189,31,196,182,123,12,239,191,189,239,191,189,239,191,189,32,239,191,189,239,191,189,93,198,141,239,191,189,239,191,189,239,191,189,239,191,189,113,239,191,189,239,191,189,103,13,34,11,239,191,189,126,239,191,189,239,191,189,239,191,189,239,191,189,115,87,239,191,189,239,191,189,239,191,189,104,239,191,189,125,114,239,191,189,239,191,189,239,191,189,239,191,189,71,239,191,189,114,82,47,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,239,191,189,239,191,189,111,12,50,239,191,189,239,191,189,33,239,191,189,36,6,239,191,189,239,191,189,239,191,189,110,239,191,189,124,239,191,189,239,191,189,223,137,29,239,191,189,86,239,191,189,44,239,191,189,239,191,189,114,28,239,191,189,29,239,191,189,7,23,239,191,189,103,112,64,239,191,189,20,239,191,189,239,191,189,34,239,191,189,239,191,189,239,191,189,100,239,191,189,239,191,189,18,239,191,189,112,32,46,239,191,189,239,191,189,24,127,5,82,239,191,189,239,191,189,220,148,239,191,189,239,191,189,199,179,239,191,189,239,191,189,12,239,191,189,239,191,189,239,191,189,239,191,189,39,239,191,189,239,191,189,239,191,189,41,56,239,191,189,10,239,191,189,239,191,189,239,191,189,239,191,189,125,29,78,239,191,189,58,239,191,189,24,13,25,239,191,189,239,191,189,203,188,239,191,189,239,191,189,26,6,37,239,191,189,85,98,113,239,191,189,112,239,191,189,93,40,239,191,189,239,191,189,239,191,189,239,191,189,60,0,239,191,189,53,123,54,27,239,191,189,34,239,191,189,239,191,189,14,42,239,191,189,31,239,191,189,120,68,239,191,189,4,239,191,189,9,239,191,189,117,12,30,239,191,189,92,220,129,85,50,70,239,191,189,239,191,189,239,191,189,239,191,189,123,120,239,191,189,234,160,128,239,191,189,239,191,189,99,212,141,117,114,239,191,189,127,35,239,191,189,98,50,127,120,41,93,88})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff4b952781",
                        container: "containers2a9aec44e70c41b58f9fae6db255bff6",
                        blob: "Blobf2d8ac149a4d4a4eae779b354778c9d9_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06743 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06743_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06743_s.txt", Encoding.UTF8);

    public Test06743() : base(recordedRequest, recordedResponse, "accounts8d439ff5575e914")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{41,239,191,189,35,86,17,239,191,189,239,191,189,13,51,64,239,191,189,239,191,189,38,18,239,191,189,239,191,189,33,127,239,191,189,105,24,7,76,239,191,189,239,191,189,119,239,191,189,19,239,191,189,100,239,191,189,45,58,118,209,130,239,191,189,56,104,41,26,29,239,191,189,84,239,191,189,124,81,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,68,239,191,189,49,34,239,191,189,239,191,189,126,239,191,189,10,239,191,189,80,206,151,239,191,189,239,191,189,239,191,189,64,34,55,239,191,189,23,125,78,239,191,189,63,239,191,189,239,191,189,91,38,239,191,189,85,239,191,189,201,181,239,191,189,68,239,191,189,239,191,189,19,239,191,189,239,191,189,31,103,239,191,189,239,191,189,239,191,189,62,217,161,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,62,55,239,191,189,9,35,115,40,93,81,5,239,191,189,239,191,189,239,191,189,107,239,191,189,48,36,46,72,93,239,191,189,45,71,57,82,239,191,189,239,191,189,44,239,191,189,121,22,239,191,189,33,110,13,239,191,189,89,9,239,191,189,91,239,191,189,10,124,239,191,189,239,191,189,108,239,191,189,53,36,105,97,239,191,189,239,191,189,105,87,9,239,191,189,95,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,7,239,191,189,239,191,189,94,239,191,189,239,191,189,26,239,191,189,239,191,189,102,220,177,83,94,239,191,189,79,8,81,23,239,191,189,70,239,191,189,22,4,49,239,191,189,83,239,191,189,109,239,191,189,104,239,191,189,4,211,189,92,239,191,189,96,239,191,189,71,239,191,189,2,123,87,71,1,239,191,189,2,239,191,189,239,191,189,79,239,191,189,93,239,191,189,239,191,189,112,90,239,191,189,239,191,189,199,162,126,106,115,13,79,239,191,189,40,66,120,239,191,189,239,191,189,208,164,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,9,25,239,191,189,18,239,191,189,239,191,189,125,205,181,239,191,189,74,39,239,191,189,8,74,239,191,189,119,239,191,189,239,191,189,37,74,239,191,189,239,191,189,34,65,213,173,239,191,189,239,191,189,68,239,191,189,239,191,189,96,90,41,239,191,189,119,98,86,239,191,189,239,191,189,9,80,90,119,28,239,191,189,98,239,191,189,239,191,189,51,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,35,239,191,189,59,239,191,189,120,55,239,191,189,32,79,239,191,189,69,104,42,112,239,191,189,239,191,189,93,239,191,189,36,66,74,239,191,189,98,106,123,5,239,191,189,239,191,189,52,239,191,189,239,191,189,239,191,189,64,43,239,191,189,55,20,239,191,189,239,191,189,239,191,189,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,126,78,0,84,239,191,189,70,95,212,132,107,110,239,191,189,31,114,239,191,189,239,191,189,239,191,189,120,103,40,239,191,189,239,191,189,79,239,191,189,239,191,189,239,191,189,63,92,9,21,239,191,189,213,176,239,191,189,83,239,191,189,239,191,189,41,64,127,108,239,191,189,75,239,191,189,66,239,191,189,239,191,189,79,10,85,13,9,45,239,191,189,127,239,191,189,239,191,189,239,191,189,239,191,189,31,119,123,86,239,191,189,239,191,189,110,239,191,189,65,9,11,108,55,239,191,189,89,110,239,191,189,72,239,191,189,29,239,191,189,82,239,191,189,8,215,168,14,7,239,191,189,32,22,54,239,191,189,96,239,191,189,42,239,191,189,60,71,48,239,191,189,13,0,73,239,191,189,239,191,189,70,239,191,189,37,38,43,239,191,189,239,191,189,126,46,37,239,191,189,78,239,191,189,82,96,239,191,189,239,191,189,239,191,189,53,239,191,189,239,191,189,239,191,189,46,121,73,0,239,191,189,124,239,191,189,81,105,102,5,98,39,239,191,189,239,191,189,239,191,189,67,38,49,239,191,189,98,239,191,189,239,191,189,239,191,189,207,189,239,191,189,23,84,107,63,239,191,189,32,239,191,189,239,191,189,239,191,189,36,2,75,239,191,189,94,239,191,189,239,191,189,57,1,239,191,189,239,191,189,96,239,191,189,107,85,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,239,191,189,88,58,21,239,191,189,198,163,6,239,191,189,239,191,189,20,20,31,36,239,191,189,239,191,189,3,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,35,239,191,189,122,239,191,189,105,41,43,239,191,189,30,116,37,67,239,191,189,73,239,191,189,239,191,189,76,50,22,239,191,189,239,191,189,75,239,191,189,70,111,239,191,189,239,191,189,20,239,191,189,7,104,2,239,191,189,22,33,239,191,189,239,191,189,57,221,191,18,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,239,191,189,100,239,191,189,239,191,189,68,239,191,189,239,191,189,239,191,189,239,191,189,46,98,239,191,189,51,109,239,191,189,65,59,239,191,189,40,107,239,191,189,18,84,86,239,191,189,239,191,189,239,191,189,102,125,239,191,189,13,66,239,191,189,79,3,92,22,239,191,189,120,239,191,189,100,64,239,191,189,93,77,239,191,189,50,60,239,191,189,239,191,189,239,191,189,102,239,191,189,239,191,189,15,78,239,191,189,90,239,191,189,239,191,189,38,123,239,191,189,84,239,191,189,53,30,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,210,165,239,191,189,239,191,189,40,120,239,191,189,239,191,189,199,180,123,239,191,189,8,239,191,189,239,191,189,13,96,120,122,7,62,239,191,189,23,8,203,139,19,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,98,239,191,189,105,85,23,49,239,191,189,52,94,239,191,189,239,191,189,217,167,45,116,239,191,189,239,191,189,239,191,189,54,52,239,191,189,84,14,239,191,189,239,191,189,211,156,100,24,14,53,239,191,189,239,191,189,8,239,191,189,215,138,239,191,189,73,71,239,191,189,239,191,189,239,191,189,16,52,46,35,94,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,71,14,239,191,189,239,191,189,100,68,239,191,189,32,27,80,126,97,65,239,191,189,239,191,189,239,191,189,59,32,123,239,191,189,63,239,191,189,117,239,191,189,89,194,175,62,239,191,189,91,46,104,239,191,189,239,191,189,239,191,189,239,191,189,18,239,191,189,83,4,239,191,189,213,183,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,1,239,191,189,239,191,189,81,14,110,239,191,189,239,191,189,198,130,239,191,189,239,191,189,85,90,239,191,189,33,21,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,118,59,105,1,239,191,189,108,239,191,189,239,191,189,41,103,239,191,189,239,191,189,109,22,118,123,50,239,191,189,76,43,239,191,189,111,93,123,239,191,189,109,124,239,191,189,239,191,189,239,191,189,239,191,189,119,239,191,189,239,191,189,239,191,189,239,191,189,5,239,191,189,239,191,189,90,239,191,189,239,191,189,107,239,191,189,239,191,189,239,191,189,102,219,169,239,191,189,62,96,27,6,239,191,189,239,191,189,10,121,239,191,189,61,239,191,189,239,191,189,76,239,191,189,122,59,239,191,189,117,239,191,189,76,239,191,189,47,239,191,189,4,111,239,191,189,16,239,191,189,125,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,239,191,189,239,191,189,23,239,191,189,56,106,108,239,191,189,239,191,189,108,73,2,57,239,191,189,239,191,189,101,4,239,191,189,76,49,56,1,111,8,239,191,189,239,191,189,114,0,239,191,189,239,191,189,239,191,189,18,79,239,191,189,102,239,191,189,94,33,19,239,191,189,239,191,189,83,26,3,239,191,189,13,127,239,191,189,239,191,189,86,239,191,189,80,239,191,189,98,239,191,189,211,132,15,239,191,189,120,239,191,189,107,14,103,239,191,189,54,239,191,189,239,191,189,92,18,7,239,191,189,239,191,189,111,239,191,189,239,191,189,108,109,239,191,189,64,239,191,189,52,43,239,191,189,60,37,239,191,189,4,239,191,189,44,79,239,191,189,239,191,189,239,191,189,86,68,239,191,189,36,100,90,239,191,189,93,239,191,189,78,23,239,191,189,39,239,191,189,239,191,189,24,239,191,189,239,191,189,56,64,55,239,191,189,223,162,17,198,145,239,191,189,239,191,189,74,239,191,189,55,24,239,191,189,51,71,8,239,191,189,87,90,123,239,191,189,112,125,239,191,189,239,191,189,75,239,191,189,20,239,191,189,239,191,189,99,78,31,97,211,130,83,239,191,189,87,239,191,189,211,150,239,191,189,239,191,189,239,191,189,239,191,189,24,239,191,189,208,152,10,239,191,189,239,191,189,5,111,36,18,239,191,189,70,34,239,191,189,10,78,239,191,189,239,191,189,239,191,189,63,96,197,181,239,191,189,0,197,167,70,239,191,189,239,191,189,14,30,51,239,191,189,68,20,239,191,189,104,99,92,99,93,65,239,191,189,16,113,1,239,191,189,127,55,6,239,191,189,239,191,189,87,10,239,191,189,12,239,191,189,31,20,239,191,189,239,191,189,113,3,239,191,189,19,52,239,191,189,239,191,189,92,15,239,191,189,239,191,189,239,191,189,239,191,189,104,116,54,239,191,189,84,239,191,189,239,191,189,35,123,7,60,90,239,191,189,57,49,239,191,189,72,78,239,191,189,239,191,189,239,191,189,61,25,239,191,189,60,114,239,191,189,34,39,239,191,189,75,239,191,189,90,239,191,189,111,239,191,189,239,191,189,239,191,189,109,3,239,191,189,239,191,189,239,191,189,113,239,191,189,239,191,189,84,239,191,189,119,109,56,71,68,102,125,54,29,239,191,189,23,51,37,1,83,239,191,189,239,191,189,99,59,239,191,189,239,191,189,16,239,191,189,124,239,191,189,239,191,189,239,191,189,65,239,191,189,67,239,191,189,30,208,170,239,191,189,77,4,239,191,189,239,191,189,36,56,239,191,189,239,191,189,239,191,189,57,221,167,239,191,189,122,239,191,189,85,99,239,191,189,3,103,239,191,189,239,191,189,101,239,191,189,120,239,191,189,239,191,189,117,239,191,189,121,21,85,86,239,191,189,51,239,191,189,71,116,239,191,189,88,239,191,189,200,167,239,191,189,69,82,239,191,189,39,239,191,189,58,98,239,191,189,67,239,191,189,239,191,189,239,191,189,7,123,239,191,189,66,65,79,57,36,239,191,189,81,9,71,239,191,189,239,191,189,27,71,121,14,8,239,191,189,239,191,189,51,54,46,78,239,191,189,63,239,191,189,239,191,189,19,239,191,189,239,191,189,77,239,191,189,239,191,189,239,191,189,70,23,100,239,191,189,239,191,189,52,239,191,189,72,127,239,191,189,74,31,27,83,52,239,191,189,239,191,189,239,191,189,24,71,101,20,239,191,189,239,191,189,114,239,191,189,61,110,239,191,189,71,239,191,189,78,110,50,239,191,189,239,191,189,99,59,239,191,189,62,239,191,189,239,191,189,118,31,239,191,189,53,222,165,1,109,239,191,189,239,191,189,115,50,36,214,148,16,53,239,191,189,239,191,189,239,191,189,75,81,209,172,32,61,82,60,239,191,189,95,9,120,101,55,23,239,191,189,239,191,189,239,191,189,95,200,164,239,191,189,103,239,191,189,239,191,189,0,239,191,189,239,191,189,239,191,189,43,239,191,189,239,191,189,18,239,191,189,112,37,78,239,191,189,21,239,191,189,82,239,191,189,239,191,189,50,123,239,191,189,239,191,189,236,191,185,52,107,87,17,53,113,239,191,189,7,239,191,189,32,106,239,191,189,108,121,218,130,101,239,191,189,239,191,189,239,191,189,239,191,189,118,239,191,189,17,52,78,0,50,239,191,189,13,22,239,191,189,25,47,0,239,191,189,239,191,189,59,71,56,239,191,189,54,239,191,189,88,79,88,239,191,189,239,191,189,61,37,239,191,189,44,65,239,191,189,239,191,189,239,191,189,86,96,239,191,189,239,191,189,239,191,189,239,191,189,120,86,239,191,189,239,191,189,82,100,239,191,189,200,182,69,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,85,107,239,191,189,239,191,189,64,239,191,189,98,239,191,189,101,74,239,191,189,239,191,189,239,191,189,239,191,189,8,239,191,189,83,2,205,150,239,191,189,49,77,92,22,239,191,189,239,191,189,17,239,191,189,207,157,239,191,189,98,69,239,191,189,239,191,189,55,108,239,191,189,94,239,191,189,239,191,189,239,191,189,42,48,239,191,189,50,239,191,189,239,191,189,86,239,191,189,239,191,189,69,239,191,189,57,239,191,189,100,42,3,46,106,239,191,189,115,122,0,239,191,189,44,65,16,239,191,189,27,239,191,189,1,56,239,191,189,49,239,191,189,49,239,191,189,48,84,64,60,239,191,189,75,239,191,189,239,191,189,239,191,189,11,79,93,13,105,239,191,189,239,191,189,54,239,191,189,43,41,239,191,189,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,13,239,191,189,8,0,51,68,239,191,189,239,191,189,41,72,239,191,189,47,88,25,121,53,239,191,189,239,191,189,14,44,99,67,239,191,189,239,191,189,124,7,98,239,191,189,99,239,191,189,87,97,92,239,191,189,239,191,189,239,191,189,3,78,42,200,149,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,106,17,239,191,189,239,191,189,82,44,194,143,239,191,189,17,97,239,191,189,43,239,191,189,45,119,239,191,189,239,191,189,118,211,163,239,191,189,239,191,189,50,115,104,69,239,191,189,239,191,189,120,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,5,53,239,191,189,36,239,191,189,220,161,239,191,189,239,191,189,239,191,189,104,76,59,239,191,189,60,40,45,215,133,239,191,189,114,239,191,189,239,191,189,44,239,191,189,82,76,111,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,65,58,127,214,175,239,191,189,239,191,189,105,95,45,84,60,200,182,87,8,32,15,29,66,27,78,108,53,106,239,191,189,50,239,191,189,9,239,191,189,239,191,189,124,97,17,239,191,189,239,191,189,0,239,191,189,239,191,189,200,128,239,191,189,239,191,189,239,191,189,22,239,191,189,239,191,189,239,191,189,239,191,189,201,137,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,73,108,31,93,239,191,189,95,99,94,239,191,189,218,183,239,191,189,105,89,32,57,36,122,239,191,189,239,191,189,110,239,191,189,84,12,121,24,28,49,69,239,191,189,239,191,189,64,7,32,100,239,191,189,239,191,189,239,191,189,239,191,189,33,36,239,191,189,239,191,189,59,239,191,189,239,191,189,67,239,191,189,239,191,189,80,239,191,189,29,53,45,95,239,191,189,24,19,239,191,189,239,191,189,66,49,25,13,16,118,239,191,189,72,244,140,130,136,239,191,189,121,239,191,189,239,191,189,239,191,189,24,64,124,212,137,239,191,189,239,191,189,61,239,191,189,11,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,23,239,191,189,239,191,189,43,85,73,239,191,189,239,191,189,28,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,103,239,191,189,239,191,189,239,191,189,36,239,191,189,99,107,218,134,63,17,239,191,189,239,191,189,127,239,191,189,239,191,189,71,34,239,191,189,239,191,189,50,239,191,189,239,191,189,107,38,56,37,79,79,48,239,191,189,123,239,191,189,80,31,36,72,98,239,191,189,239,191,189,239,191,189,111,115,95,11,239,191,189,51,7,32,239,191,189,73,239,191,189,18,239,191,189,52,29,239,191,189,62,239,191,189,239,191,189,62,27,239,191,189,86,98,239,191,189,16,239,191,189,95,118,103,239,191,189,62,38,0,239,191,189,102,239,191,189,96,56,5,29,47,116,239,191,189,40,104,239,191,189,27,2,85,10,101,76,239,191,189,239,191,189,239,191,189,29,239,191,189,116,221,179,239,191,189,239,191,189,115,101,118,239,191,189,239,191,189,113,239,191,189,67,239,191,189,196,146,32,239,191,189,22,111,57,45,42,100,93,32,93,127,239,191,189,50,239,191,189,72,239,191,189,239,191,189,91,82,117,239,191,189,1,239,191,189,239,191,189,124,239,191,189,239,191,189,74,17,44,239,191,189,239,191,189,103,239,191,189,205,174,239,191,189,70,239,191,189,78,74,239,191,189,21,239,191,189,78,239,191,189,239,191,189,110,239,191,189,239,191,189,105,64,239,191,189,103,20,237,135,177,43,239,191,189,18,15,48,239,191,189,56,54,80,17,239,191,189,203,165,239,191,189,4,42,239,191,189,239,191,189,46,45,73,24,239,191,189,92,58,55,121,239,191,189,122,239,191,189,239,191,189,59,239,191,189,239,191,189,239,191,189,56,122,239,191,189,7,76,24,101,127,239,191,189,239,191,189,76,239,191,189,60,239,191,189,108,40,81,89,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,122,239,191,189,88,218,143,16,33,112,239,191,189,6,239,191,189,239,191,189,21,239,191,189,8,114,239,191,189,118,61,58,14,239,191,189,111,239,191,189,17,239,191,189,239,191,189,1,239,191,189,239,191,189,95,239,191,189,239,191,189,239,191,189,39,239,191,189,90,59,239,191,189,203,143,239,191,189,34,239,191,189,119,110,239,191,189,8,46,64,7,48,239,191,189,63,239,191,189,239,191,189,106,239,191,189,239,191,189,124,127,239,191,189,23,53,84,118,84,113,14,23,239,191,189,239,191,189,113,239,191,189,35,110,239,191,189,106,239,191,189,239,191,189,239,191,189,210,134,239,191,189,47,12,94,239,191,189,95,239,191,189,239,191,189,60,34,76,239,191,189,49,11,239,191,189,35,239,191,189,239,191,189,239,191,189,32,40,85,88,15,239,191,189,239,191,189,89,239,191,189,67,93,214,150,29,51,47,5,71,24,239,191,189,18,126,107,117,239,191,189,36,11,239,191,189,99,44,71,239,191,189,239,191,189,81,239,191,189,93,239,191,189,239,191,189,239,191,189,239,191,189,36,5,239,191,189,105,239,191,189,76,239,191,189,239,191,189,239,191,189,219,129,239,191,189,239,191,189,30,239,191,189,239,191,189,239,191,189,223,163,234,137,177,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,68,107,214,157,47,74,79,102,12,239,191,189,2,239,191,189,104,110,239,191,189,239,191,189,239,191,189,239,191,189,107,239,191,189,239,191,189,239,191,189,16,239,191,189,239,191,189,51,18,63,115,15,75,109,45,113,113,22,38,62,82,239,191,189,239,191,189,239,191,189,119,239,191,189,239,191,189,73,58,123,0,239,191,189,110,239,191,189,239,191,189,239,191,189,119,91,54,239,191,189,239,191,189,55,15,239,191,189,239,191,189,91,239,191,189,105,239,191,189,239,191,189,115,239,191,189,73,88,239,191,189,58,37,84,22,239,191,189,104,239,191,189,239,191,189,62,239,191,189,239,191,189,106,239,191,189,69,116,239,191,189,239,191,189,239,191,189,83,85,90,239,191,189,239,191,189,122,239,191,189,38,239,191,189,67,127,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,35,68,81,239,191,189,3,239,191,189,239,191,189,60,93,239,191,189,35,239,191,189,3,239,191,189,239,191,189,239,191,189,3,127,239,191,189,96,239,191,189,120,239,191,189,239,191,189,239,191,189,24,239,191,189,239,191,189,122,239,191,189,37,239,191,189,239,191,189,239,191,189,118,239,191,189,239,191,189,82,239,191,189,239,191,189,239,191,189,28,239,191,189,109,239,191,189,239,191,189,123,239,191,189,15,47,239,191,189,56,239,191,189,118,72,204,147,239,191,189,78,239,191,189,30,115,239,191,189,13,239,191,189,239,191,189,239,191,189,44,65,64,37,239,191,189,239,191,189,9,216,189,239,191,189,80,239,191,189,239,191,189,221,184,75,94,239,191,189,39,239,191,189,239,191,189,10,239,191,189,3,50,239,191,189,20,58,239,191,189,239,191,189,51,239,191,189,79,239,191,189,239,191,189,10,239,191,189,115,233,157,138,1,67,47,91,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,227,189,158,239,191,189,53,78,239,191,189,239,191,189,120,195,131,43,117,239,191,189,22,76,74,239,191,189,65,239,191,189,121,239,191,189,239,191,189,3,239,191,189,199,166,239,191,189,70,79,89,239,191,189,239,191,189,52,79,31,239,191,189,239,191,189,239,191,189,239,191,189,38,239,191,189,112,239,191,189,7,239,191,189,205,152,68,239,191,189,239,191,189,239,191,189,86,36,44,38,52,239,191,189,239,191,189,109,239,191,189,5,75,40,105,239,191,189,59,65,71,239,191,189,239,191,189,79,79,239,191,189,100,239,191,189,76,239,191,189,239,191,189,239,191,189,239,191,189,13,98,239,191,189,89,239,191,189,75,239,191,189,8,41,239,191,189,22,12,44,18,32,239,191,189,71,111,37,239,191,189,239,191,189,81,77,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,132,239,191,189,27,115,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,111,56,29,11,239,191,189,66,35,115,68,2,4,63,239,191,189,57,110,239,191,189,21,239,191,189,239,191,189,6,123,11,115,79,102,119,239,191,189,120,125,239,191,189,120,239,191,189,239,191,189,42,83,51,65,127,100,95,93,123,239,191,189,239,191,189,69,239,191,189,239,191,189,5,221,141,1,29,239,191,189,26,100,239,191,189,206,165,13,81,106,239,191,189,239,191,189,17,239,191,189,239,191,189,69,15,26,239,191,189,239,191,189,35,77,239,191,189,29,239,191,189,239,191,189,122,33,239,191,189,14,239,191,189,239,191,189,239,191,189,239,191,189,90,239,191,189,118,197,141,101,239,191,189,113,18,239,191,189,98,239,191,189,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,239,191,189,84,239,191,189,94,67,239,191,189,95,239,191,189,34,50,239,191,189,239,191,189,73,239,191,189,34,55,239,191,189,58,239,191,189,239,191,189,239,191,189,97,49,239,191,189,44,59,239,191,189,69,52,16,239,191,189,239,191,189,121,239,191,189,17,25,19,239,191,189,60,3,239,191,189,93,22,239,191,189,239,191,189,239,191,189,94,50,239,191,189,44,239,191,189,127,65,239,191,189,239,191,189,34,239,191,189,49,7,239,191,189,26,239,191,189,18,239,191,189,124,86,88,239,191,189,17,29,239,191,189,107,118,239,191,189,239,191,189,3,27,239,191,189,121,239,191,189,105,18,239,191,189,239,191,189,239,191,189,0,56,239,191,189,39,239,191,189,35,239,191,189,239,191,189,76,239,191,189,57,75,109,27,92,48,123,33,101,239,191,189,43,9,239,191,189,239,191,189,127,7,239,191,189,239,191,189,85,239,191,189,7,239,191,189,46,239,191,189,123,29,97,239,191,189,34,239,191,189,239,191,189,239,191,189,42,239,191,189,196,184,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,76,85,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,35,42,113,239,191,189,239,191,189,72,28,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,106,210,136,223,185,55,239,191,189,89,36,239,191,189,212,152,22,239,191,189,239,191,189,239,191,189,110,101,19,58,214,145,49,99,239,191,189,123,239,191,189,239,191,189,59,222,177,46,239,191,189,239,191,189,63,24,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,46,202,163,68,239,191,189,27,239,191,189,106,239,191,189,196,148,64,86,123,203,187,43,99,239,191,189,34,106,36,239,191,189,85,239,191,189,107,121,239,191,189,49,239,191,189,239,191,189,1,239,191,189,53,35,239,191,189,86,45,32,15,71,239,191,189,45,77,66,239,191,189,41,8,239,191,189,41,22,239,191,189,123,196,166,239,191,189,239,191,189,25,239,191,189,86,239,191,189,123,23,239,191,189,63,239,191,189,69,239,191,189,239,191,189,239,191,189,54,200,172,239,191,189,239,191,189,239,191,189,118,19,239,191,189,239,191,189,79,239,191,189,124,239,191,189,239,191,189,44,24,113,125,239,191,189,104,19,112,239,191,189,124,5,22,239,191,189,2,38,87,239,191,189,36,239,191,189,239,191,189,77,40,239,191,189,218,175,106,239,191,189,82,239,191,189,6,51,239,191,189,239,191,189,239,191,189,19,239,191,189,239,191,189,41,239,191,189,108,34,88,239,191,189,94,239,191,189,239,191,189,239,191,189,16,239,191,189,118,239,191,189,114,239,191,189,239,191,189,115,3,120,239,191,189,206,140,239,191,189,239,191,189,239,191,189,239,191,189,73,6,239,191,189,239,191,189,239,191,189,124,239,191,189,88,55,116,239,191,189,239,191,189,53,65,239,191,189,207,132,202,177,106,57,239,191,189,98,4,239,191,189,15,49,60,91,96,239,191,189,97,239,191,189,64,21,239,191,189,94,79,33,36,239,191,189,116,59,39,239,191,189,126,239,191,189,55,239,191,189,239,191,189,7,239,191,189,15,36,120,239,191,189,239,191,189,125,13,239,191,189,74,71,239,191,189,214,147,111,43,239,191,189,44,26,113,53,239,191,189,239,191,189,119,197,132,59,68,9,65,239,191,189,239,191,189,92,89,30,81,239,191,189,200,140,56,239,191,189,66,64,218,171,119,101,239,191,189,80,82,239,191,189,11,239,191,189,239,191,189,239,191,189,24,239,191,189,239,191,189,239,191,189,4,104,56,3,239,191,189,80,239,191,189,239,191,189,125,117,29,239,191,189,44,239,191,189,239,191,189,239,191,189,104,239,191,189,239,191,189,78,31,239,191,189,239,191,189,103,239,191,189,24,207,134,6,239,191,189,239,191,189,20,239,191,189,207,168,62,239,191,189,239,191,189,0,239,191,189,239,191,189,30,50,202,172,107,239,191,189,239,191,189,223,175,239,191,189,239,191,189,101,239,191,189,239,191,189,67,76,55,97,239,191,189,239,191,189,239,191,189,111,77,239,191,189,24,24,18,239,191,189,239,191,189,41,239,191,189,119,54,239,191,189,239,191,189,236,187,131,117,210,166,86,1,22,239,191,189,239,191,189,14,100,239,191,189,106,40,110,5,239,191,189,239,191,189,58,239,191,189,82,239,191,189,21,43,239,191,189,21,239,191,189,56,239,191,189,95,124,239,191,189,28,239,191,189,80,25,76,121,105,118,4,239,191,189,239,191,189,92,0,93,113,69,239,191,189,220,178,39,48,239,191,189,123,109,92,1,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,75,81,6,239,191,189,239,191,189,239,191,189,239,191,189,42,220,139,239,191,189,105,239,191,189,239,191,189,239,191,189,124,104,93,239,191,189,239,191,189,84,239,191,189,54,65,213,171,239,191,189,120,239,191,189,239,191,189,45,239,191,189,46,110,239,191,189,11,106,239,191,189,69,67,239,191,189,239,191,189,84,90,43,17,239,191,189,73,67,239,191,189,120,60,230,153,158,27,239,191,189,239,191,189,239,191,189,72,239,191,189,90,93,239,191,189,58,29,239,191,189,18,239,191,189,24,98,239,191,189,87,88,239,191,189,22,239,191,189,239,191,189,55,46,101,239,191,189,239,191,189,100,72,239,191,189,23,239,191,189,239,191,189,91,239,191,189,239,191,189,123,239,191,189,239,191,189,58,239,191,189,239,191,189,202,157,49,239,191,189,96,239,191,189,42,65,69,62,239,191,189,8,30,114,26,27,98,239,191,189,239,191,189,239,191,189,71,214,187,108,239,191,189,239,191,189,19,239,191,189,94,239,191,189,239,191,189,239,191,189,6,108,239,191,189,52,49,84,239,191,189,29,239,191,189,209,177,239,191,189,239,191,189,61,38,239,191,189,95,239,191,189,83,239,191,189,239,191,189,124,239,191,189,239,191,189,239,191,189,218,164,16,23,101,239,191,189,94,239,191,189,28,24,5,239,191,189,239,191,189,49,83,0,212,179,5,10,117,28,127,239,191,189,239,191,189,124,199,140,45,7,239,191,189,120,239,191,189,111,86,239,191,189,122,5,46,239,191,189,83,37,239,191,189,36,32,5,120,101,239,191,189,239,191,189,15,239,191,189,239,191,189,239,191,189,79,239,191,189,36,109,239,191,189,239,191,189,30,209,164,20,239,191,189,239,191,189,239,191,189,120,218,163,239,191,189,207,132,26,239,191,189,79,105,90,239,191,189,127,4,98,239,191,189,127,239,191,189,239,191,189,239,191,189,239,191,189,32,239,191,189,239,191,189,13,115,69,203,130,239,191,189,239,191,189,239,191,189,239,191,189,44,239,191,189,239,191,189,92,40,64,69,239,191,189,32,239,191,189,83,239,191,189,239,191,189,19,239,191,189,67,37,28,239,191,189,2,0,87,65,23,120,91,62,78,52,239,191,189,239,191,189,239,191,189,239,191,189,82,4,239,191,189,48,86,239,191,189,121,239,191,189,239,191,189,32,70,239,191,189,32,95,96,15,62,91,239,191,189,196,145,44,239,191,189,73,68,239,191,189,239,191,189,7,239,191,189,239,191,189,48,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,18,239,191,189,101,86,76,71,55,239,191,189,85,88,239,191,189,239,191,189,62,239,191,189,115,74,1,91,38,92,239,191,189,239,191,189,239,191,189,114,47,239,191,189,239,191,189,33,239,191,189,127,43,43,239,191,189,28,109,68,239,191,189,112,78,239,191,189,87,239,191,189,41,71,239,191,189,239,191,189,61,2,239,191,189,239,191,189,239,191,189,85,38,39,239,191,189,239,191,189,28,123,71,59,239,191,189,54,93,94,19,239,191,189,239,191,189,45,239,191,189,22,65,239,191,189,64,239,191,189,79,239,191,189,72,239,191,189,239,191,189,50,239,191,189,239,191,189,126,4,239,191,189,239,191,189,5,101,239,191,189,239,191,189,40,104,41,19,87,33,239,191,189,239,191,189,52,44,239,191,189,15,111,239,191,189,89,239,191,189,21,41,215,167,239,191,189,53,239,191,189,21,239,191,189,221,183,88,99,61,196,128,239,191,189,10,239,191,189,239,191,189,239,191,189,45,239,191,189,46,95,125,239,191,189,239,191,189,90,114,75,239,191,189,97,239,191,189,219,142,239,191,189,239,191,189,239,191,189,239,191,189,19,89,122,105,50,104,239,191,189,104,86,107,101,239,191,189,239,191,189,239,191,189,232,132,168,72,31,239,191,189,239,191,189,239,191,189,70,239,191,189,196,173,1,125,239,191,189,239,191,189,239,191,189,29,239,191,189,22,239,191,189,239,191,189,43,239,191,189,45,20,239,191,189,64,4,7,239,191,189,85,42,239,191,189,239,191,189,86,239,191,189,239,191,189,113,239,191,189,88,19,232,165,132,102,120,126,100,239,191,189,71,239,191,189,105,40,20,88,239,191,189,27,10,196,190,239,191,189,63,239,191,189,111,239,191,189,119,239,191,189,239,191,189,11,38,79,239,191,189,83,85,239,191,189,66,31,239,191,189,239,191,189,68,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,97,239,191,189,239,191,189,2,127,195,173,5,239,191,189,239,191,189,61,53,1,239,191,189,239,191,189,239,191,189,89,239,191,189,239,191,189,23,22,239,191,189,84,22,239,191,189,114,92,127,239,191,189,22,239,191,189,12,239,191,189,239,191,189,21,239,191,189,8,239,191,189,239,191,189,239,191,189,77,239,191,189,239,191,189,5,234,167,189,113,239,191,189,69,216,166,239,191,189,239,191,189,239,191,189,110,239,191,189,62,13,102,45,8,239,191,189,239,191,189,48,122,63,239,191,189,239,191,189,87,80,239,191,189,108,58,239,191,189,32,104,17,239,191,189,202,159,14,39,239,191,189,10,102,30,22,239,191,189,116,239,191,189,202,154,37,239,191,189,69,39,239,191,189,239,191,189,111,103,239,191,189,125,239,191,189,239,191,189,57,98,239,191,189,110,6,239,191,189,100,66,239,191,189,31,239,191,189,239,191,189,239,191,189,91,41,84,124,239,191,189,239,191,189,65,70,239,191,189,239,191,189,239,191,189,108,60,106,98,239,191,189,239,191,189,239,191,189,239,191,189,13,44,239,191,189,52,23,109,239,191,189,101,88,94,239,191,189,100,108,21,10,20,62,239,191,189,4,239,191,189,110,239,191,189,239,191,189,239,191,189,94,117,239,191,189,239,191,189,239,191,189,239,191,189,10,239,191,189,53,239,191,189,216,157,239,191,189,239,191,189,60,14,239,191,189,33,239,191,189,239,191,189,239,191,189,31,239,191,189,86,50,85,36,45,239,191,189,239,191,189,109,82,57,239,191,189,214,162,239,191,189,59,106,120,83,239,191,189,46,239,191,189,61,109,118,74,82,239,191,189,239,191,189,76,239,191,189,12,239,191,189,63,239,191,189,67,103,239,191,189,239,191,189,239,191,189,7,92,113,239,191,189,100,239,191,189,30,239,191,189,59,239,191,189,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,24,239,191,189,239,191,189,239,191,189,218,148,239,191,189,33,239,191,189,44,8,239,191,189,239,191,189,239,191,189,239,191,189,197,188,118,239,191,189,239,191,189,27,239,191,189,9,239,191,189,43,239,191,189,239,191,189,97,239,191,189,97,120,239,191,189,78,239,191,189,43,239,191,189,239,191,189,239,191,189,2,115,239,191,189,80,4,55,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,29,5,30,239,191,189,97,239,191,189,34,239,191,189,34,239,191,189,122,239,191,189,31,239,191,189,40,72,239,191,189,100,48,239,191,189,239,191,189,115,239,191,189,81,203,178,239,191,189,12,239,191,189,239,191,189,14,239,191,189,239,191,189,239,191,189,91,239,191,189,48,4,239,191,189,239,191,189,51,223,152,5,239,191,189,229,131,136,63,15,71,239,191,189,239,191,189,217,169,239,191,189,239,191,189,25,239,191,189,239,191,189,22,10,74,239,191,189,239,191,189,239,191,189,114,89,78,23,204,154,74,90,239,191,189,239,191,189,239,191,189,76,6,239,191,189,78,239,191,189,100,239,191,189,239,191,189,5,239,191,189,212,177,88,99,239,191,189,27,239,191,189,239,191,189,41,239,191,189,239,191,189,37,239,191,189,114,42,58,39,67,239,191,189,75,239,191,189,49,22,239,191,189,239,191,189,18,225,155,146,239,191,189,239,191,189,5,239,191,189,53,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,127,77,239,191,189,126,239,191,189,30,38,40,90,36,73,60,239,191,189,25,239,191,189,25,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,97,239,191,189,239,191,189,17,239,191,189,75,239,191,189,211,130,67,114,98,45,239,191,189,203,179,23,121,90,239,191,189,118,72,105,239,191,189,239,191,189,32,28,239,191,189,12,53,239,191,189,8,69,239,191,189,239,191,189,239,191,189,239,191,189,87,239,191,189,127,239,191,189,239,191,189,5,239,191,189,34,239,191,189,77,239,191,189,70,239,191,189,239,191,189,239,191,189,25,19,239,191,189,43,239,191,189,239,191,189,117,13,239,191,189,89,239,191,189,17,239,191,189,239,191,189,42,34,127,106,239,191,189,239,191,189,66,239,191,189,239,191,189,239,191,189,101,239,191,189,12,239,191,189,239,191,189,74,26,239,191,189,2,28,239,191,189,239,191,189,125,239,191,189,239,191,189,44,239,191,189,41,239,191,189,5,239,191,189,81,55,88,36,7,239,191,189,239,191,189,22,113,120,54,239,191,189,198,188,239,191,189,239,191,189,30,85,62,85,15,239,191,189,239,191,189,80,239,191,189,239,191,189,119,80,239,191,189,74,119,20,239,191,189,239,191,189,125,239,191,189,48,239,191,189,66,239,191,189,239,191,189,239,191,189,105,239,191,189,239,191,189,239,191,189,55,239,191,189,64,239,191,189,211,137,239,191,189,239,191,189,115,98,7,127,54,11,98,110,38,1,33,239,191,189,10,63,239,191,189,239,191,189,82,18,239,191,189,118,35,50,107,239,191,189,2,239,191,189,63,108,102,112,239,191,189,239,191,189,73,33,10,114,40,76,11,239,191,189,123,124,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,237,132,135,239,191,189,239,191,189,57,117,64,239,191,189,90,124,78,239,191,189,239,191,189,8,239,191,189,94,239,191,189,239,191,189,239,191,189,52,239,191,189,239,191,189,6,6,26,239,191,189,239,191,189,239,191,189,3,44,66,10,71,127,239,191,189,239,191,189,239,191,189,15,239,191,189,239,191,189,123,239,191,189,207,189,239,191,189,239,191,189,116,239,191,189,9,239,191,189,40,239,191,189,239,191,189,105,239,191,189,239,191,189,239,191,189,62,206,146,239,191,189,45,58,67,239,191,189,118,37,239,191,189,124,239,191,189,61,106,8,239,191,189,54,72,91,117,50,239,191,189,239,191,189,65,25,22,239,191,189,21,239,191,189,104,39,239,191,189,239,191,189,239,191,189,55,239,191,189,239,191,189,239,191,189,121,58,15,79,2,239,191,189,239,191,189,239,191,189,239,191,189,88,96,42,74,113,108,201,156,239,191,189,239,191,189,239,191,189,33,45,1,96,50,99,85,12,239,191,189,96,50,239,191,189,37,239,191,189,239,191,189,32,101,239,191,189,239,191,189,109,69,120,95,43,239,191,189,239,191,189,29,239,191,189,117,6,64,239,191,189,239,191,189,239,191,189,116,76,57,239,191,189,29,239,191,189,54,239,191,189,239,191,189,86,37,239,191,189,4,239,191,189,239,191,189,76,99,239,191,189,214,139,239,191,189,239,191,189,239,191,189,214,171,105,70,239,191,189,239,191,189,239,191,189,32,239,191,189,239,191,189,113,44,239,191,189,239,191,189,239,191,189,61,55,86,239,191,189,8,5,239,191,189,239,191,189,115,18,41,239,191,189,239,191,189,239,191,189,2,13,239,191,189,126,99,2,239,191,189,88,239,191,189,87,56,54,119,239,191,189,124,32,101,239,191,189,239,191,189,239,191,189,84,80,25,239,191,189,239,191,189,213,164,210,141,110,13,239,191,189,239,191,189,239,191,189,100,97,4,239,191,189,239,191,189,16,239,191,189,239,191,189,86,209,141,239,191,189,50,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,21,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,45,15,239,191,189,8,239,191,189,43,239,191,189,120,239,191,189,45,27,27,239,191,189,239,191,189,228,179,179,82,239,191,189,239,191,189,67,239,191,189,114,219,155,239,191,189,22,9,239,191,189,66,239,191,189,239,191,189,76,239,191,189,1,95,239,191,189,20,42,53,21,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,106,239,191,189,239,191,189,79,65,239,191,189,239,191,189,108,62,21,239,191,189,239,191,189,239,191,189,239,191,189,107,239,191,189,239,191,189,111,239,191,189,83,26,62,239,191,189,239,191,189,46,239,191,189,109,0,239,191,189,239,191,189,23,92,239,191,189,71,61,239,191,189,239,191,189,239,191,189,70,100,239,191,189,43,239,191,189,21,239,191,189,239,191,189,53,126,111,7,239,191,189,239,191,189,15,239,191,189,44,86,5,33,68,47,239,191,189,239,191,189,115,239,191,189,54,6,113,72,239,191,189,71,84,41,126,239,191,189,239,191,189,104,239,191,189,28,239,191,189,239,191,189,238,144,188,223,135,239,191,189,120,102,16,105,239,191,189,126,1,52,10,239,191,189,98,22,107,239,191,189,239,191,189,53,239,191,189,239,191,189,239,191,189,102,75,112,239,191,189,239,191,189,239,191,189,239,191,189,122,125,65,25,239,191,189,118,239,191,189,239,191,189,11,56,66,239,191,189,239,191,189,39,73,239,191,189,106,6,108,239,191,189,38,3,239,191,189,239,191,189,239,191,189,71,33,70,7,116,76,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,205,159,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,62,1,220,135,239,191,189,102,54,83,121,239,191,189,77,239,191,189,77,85,93,239,191,189,239,191,189,239,191,189,42,209,162,86,239,191,189,239,191,189,56,239,191,189,239,191,189,53,75,239,191,189,74,0,239,191,189,239,191,189,69,43,239,191,189,47,99,239,191,189,10,106,239,191,189,239,191,189,239,191,189,74,105,105,33,18,239,191,189,239,191,189,239,191,189,56,239,191,189,239,191,189,239,191,189,76,29,46,239,191,189,2,239,191,189,239,191,189,114,24,92,239,191,189,93,125,239,191,189,31,239,191,189,239,191,189,239,191,189,41,239,191,189,239,191,189,239,191,189,239,191,189,42,239,191,189,117,47,239,191,189,71,239,191,189,239,191,189,56,8,239,191,189,22,239,191,189,220,158,239,191,189,239,191,189,239,191,189,239,191,189,81,13,119,239,191,189,88,10,239,191,189,4,239,191,189,56,239,191,189,239,191,189,24,239,191,189,81,4,35,239,191,189,239,191,189,51,43,126,105,112,84,232,176,139,239,191,189,77,94,109,239,191,189,239,191,189,47,239,191,189,239,191,189,239,191,189,28,36,239,191,189,66,218,185,239,191,189,58,124,75,66,239,191,189,122,20,239,191,189,239,191,189,239,191,189,211,164,6,96,112,90,69,72,113,239,191,189,30,239,191,189,110,239,191,189,239,191,189,81,47,112,239,191,189,111,232,163,176,239,191,189,25,107,100,73,239,191,189,239,191,189,74,112,121,239,191,189,92,25,239,191,189,239,191,189,239,191,189,239,191,189,126,239,191,189,104,223,143,108,13,239,191,189,239,191,189,239,191,189,75,239,191,189,99,22,239,191,189,47,239,191,189,67,71,4,239,191,189,239,191,189,101,239,191,189,239,191,189,239,191,189,85,114,63,121,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,58,239,191,189,51,239,191,189,94,239,191,189,239,191,189,93,239,191,189,239,191,189,12,99,55,44,37,104,76,239,191,189,213,130,239,191,189,239,191,189,78,239,191,189,23,239,191,189,113,52,223,175,239,191,189,36,239,191,189,239,191,189,35,15,239,191,189,239,191,189,64,97,7,22,239,191,189,239,191,189,58,18,84,61,78,27,239,191,189,111,90,112,239,191,189,81,239,191,189,239,191,189,67,101,126,239,191,189,239,191,189,120,62,98,55,2,88,239,191,189,2,239,191,189,32,239,191,189,239,191,189,100,64,37,97,94,239,191,189,97,197,155,239,191,189,123,239,191,189,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,62,36,40,239,191,189,239,191,189,239,191,189,82,239,191,189,25,100,78,205,188,29,17,111,97,239,191,189,239,191,189,118,239,191,189,221,137,239,191,189,96,239,191,189,239,191,189,30,239,191,189,36,3,117,64,24,114,239,191,189,239,191,189,239,191,189,239,191,189,197,172,54,102,239,191,189,200,132,239,191,189,239,191,189,239,191,189,24,118,239,191,189,239,191,189,37,75,41,239,191,189,40,239,191,189,75,239,191,189,239,191,189,239,191,189,42,239,191,189,71,239,191,189,239,191,189,239,191,189,239,191,189,97,239,191,189,31,239,191,189,83,239,191,189,34,55,239,191,189,239,191,189,239,191,189,25,239,191,189,126,239,191,189,86,239,191,189,26,239,191,189,72,239,191,189,90,239,191,189,113,216,177,104,60,229,128,167,239,191,189,239,191,189,239,191,189,239,191,189,127,239,191,189,23,210,164,7,239,191,189,62,20,93,239,191,189,94,79,124,115,239,191,189,239,191,189,44,239,191,189,65,7,90,239,191,189,216,161,62,239,191,189,82,105,53,57,239,191,189,239,191,189,239,191,189,45,200,150,72,40,65,239,191,189,28,239,191,189,19,4,83,24,239,191,189,113,239,191,189,239,191,189,239,191,189,104,239,191,189,37,239,191,189,62,48,102,32,104,239,191,189,239,191,189,36,82,108,239,191,189,78,239,191,189,2,121,4,114,101,239,191,189,210,155,239,191,189,78,37,38,239,191,189,80,239,191,189,239,191,189,239,191,189,24,8,239,191,189,88,23,239,191,189,32,116,71,239,191,189,239,191,189,239,191,189,112,239,191,189,239,191,189,107,239,191,189,112,2,239,191,189,83,67,106,239,191,189,64,239,191,189,239,191,189,82,239,191,189,114,239,191,189,239,191,189,111,70,239,191,189,239,191,189,97,66,81,239,191,189,41,239,191,189,34,103,239,191,189,239,191,189,24,239,191,189,239,191,189,46,46,239,191,189,83,239,191,189,239,191,189,239,191,189,53,239,191,189,39,239,191,189,239,191,189,25,123,239,191,189,4,32,42,7,57,9,65,30,17,32,41,239,191,189,71,122,239,191,189,67,110,239,191,189,239,191,189,68,239,191,189,90,28,239,191,189,25,239,191,189,44,239,191,189,42,4,239,191,189,15,49,35,99,116,239,191,189,17,100,239,191,189,239,191,189,16,117,51,239,191,189,16,239,191,189,239,191,189,239,191,189,239,191,189,125,63,112,54,121,239,191,189,4,239,191,189,239,191,189,124,220,128,239,191,189,13,113,25,100,35,23,54,239,191,189,92,81,239,191,189,88,116,239,191,189,239,191,189,7,9,23,114,239,191,189,71,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,111,239,191,189,36,239,191,189,239,191,189,107,29,104,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,42,33,239,191,189,239,191,189,5,239,191,189,27,239,191,189,239,191,189,101,106,239,191,189,239,191,189,239,191,189,0,122,106,121,93,239,191,189,239,191,189,55,105,239,191,189,239,191,189,86,124,38,239,191,189,94,239,191,189,239,191,189,74,28,101,239,191,189,239,191,189,28,239,191,189,239,191,189,84,98,65,239,191,189,239,191,189,239,191,189,113,239,191,189,239,191,189,239,191,189,65,8,68,239,191,189,101,239,191,189,239,191,189,239,191,189,71,239,191,189,239,191,189,239,191,189,207,154,75,239,191,189,33,126,127,77,239,191,189,104,114,99,239,191,189,239,191,189,57,22,239,191,189,100,239,191,189,29,239,191,189,239,191,189,114,239,191,189,123,239,191,189,38,42,239,191,189,239,191,189,95,103,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,67,118,239,191,189,50,239,191,189,101,2,239,191,189,239,191,189,201,171,239,191,189,90,104,66,15,239,191,189,215,165,239,191,189,89,35,223,185,19,239,191,189,58,52,63,239,191,189,2,239,191,189,33,41,41,90,239,191,189,13,239,191,189,239,191,189,96,239,191,189,78,44,2,239,191,189,12,83,111,239,191,189,10,26,239,191,189,29,239,191,189,83,34,81,6,239,191,189,105,92,78,239,191,189,239,191,189,110,48,62,239,191,189,96,239,191,189,34,28,32,239,191,189,213,178,239,191,189,68,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,239,191,189,94,12,90,6,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,45,0,102,50,96,239,191,189,21,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,107,12,22,208,165,7,114,239,191,189,15,16,36,239,191,189,239,191,189,239,191,189,16,115,75,41,239,191,189,239,191,189,76,239,191,189,239,191,189,19,239,191,189,60,239,191,189,239,191,189,15,195,187,239,191,189,96,101,32,239,191,189,239,191,189,239,191,189,80,37,239,191,189,239,191,189,34,80,239,191,189,49,239,191,189,239,191,189,239,191,189,116,239,191,189,120,239,191,189,36,84,239,191,189,40,2,239,191,189,104,61,123,239,191,189,75,84,102,239,191,189,124,239,191,189,98,239,191,189,75,239,191,189,123,71,239,191,189,98,239,191,189,92,239,191,189,239,191,189,21,35,239,191,189,18,66,16,59,16,57,239,191,189,239,191,189,0,239,191,189,239,191,189,18,239,191,189,239,191,189,239,191,189,80,239,191,189,40,0,113,239,191,189,101,239,191,189,49,221,160,239,191,189,239,191,189,239,191,189,95,239,191,189,39,87,36,56,17,86,71,107,123,239,191,189,70,75,239,191,189,53,219,138,239,191,189,12,239,191,189,110,21,239,191,189,0,239,191,189,239,191,189,239,191,189,94,111,239,191,189,239,191,189,239,191,189,23,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,102,239,191,189,239,191,189,239,191,189,83,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,109,97,17,239,191,189,35,239,191,189,110,118,239,191,189,239,191,189,239,191,189,239,191,189,87,239,191,189,239,191,189,239,191,189,122,38,239,191,189,18,239,191,189,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,85,52,239,191,189,239,191,189,20,239,191,189,18,123,239,191,189,124,239,191,189,239,191,189,239,191,189,239,191,189,112,239,191,189,239,191,189,45,239,191,189,14,77,239,191,189,225,176,129,239,191,189,118,239,191,189,122,52,51,81,11,239,191,189,1,117,35,34,101,239,191,189,239,191,189,50,239,191,189,14,239,191,189,239,191,189,116,239,191,189,34,30,118,239,191,189,11,239,191,189,239,191,189,239,191,189,83,5,46,239,191,189,26,25,1,79,73,111,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,9,53,27,239,191,189,239,191,189,239,191,189,239,191,189,20,239,191,189,239,191,189,91,239,191,189,239,191,189,70,95,77,52,33,30,239,191,189,239,191,189,123,239,191,189,48,63,197,128,30,239,191,189,239,191,189,38,107,239,191,189,239,191,189,1,119,239,191,189,211,128,69,127,119,85,66,239,191,189,239,191,189,239,191,189,41,83,101,239,191,189,217,148,239,191,189,239,191,189,117,239,191,189,13,63,239,191,189,83,14,239,191,189,239,191,189,239,191,189,239,191,189,68,239,191,189,239,191,189,97,239,191,189,239,191,189,116,98,37,125,239,191,189,239,191,189,39,87,239,191,189,91,239,191,189,76,239,191,189,22,239,191,189,115,1,239,191,189,24,115,5,239,191,189,36,70,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,107,239,191,189,100,56,239,191,189,65,239,191,189,104,239,191,189,96,12,239,191,189,239,191,189,239,191,189,239,191,189,30,99,25,239,191,189,24,239,191,189,239,191,189,31,72,46,211,133,61,239,191,189,239,191,189,239,191,189,15,117,114,96,239,191,189,239,191,189,20,26,239,191,189,70,11,9,65,12,239,191,189,29,41,45,40,46,239,191,189,195,153,19,239,191,189,239,191,189,27,9,239,191,189,78,239,191,189,13,239,191,189,239,191,189,112,117,100,63,239,191,189,78,239,191,189,6,239,191,189,239,191,189,239,191,189,239,191,189,59,239,191,189,239,191,189,91,16,239,191,189,239,191,189,57,76,239,191,189,95,239,191,189,50,112,11,50,25,239,191,189,239,191,189,239,191,189,239,191,189,16,29,239,191,189,239,191,189,239,191,189,223,156,239,191,189,239,191,189,78,239,191,189,239,191,189,239,191,189,104,50,96,61,239,191,189,80,82,239,191,189,239,191,189,22,239,191,189,12,33,67,239,191,189,239,191,189,239,191,189,66,239,191,189,40,43,239,191,189,14,239,191,189,35,32,221,156,239,191,189,20,16,52,239,191,189,239,191,189,239,191,189,0,239,191,189,239,191,189,239,191,189,239,191,189,99,96,239,191,189,239,191,189,61,239,191,189,116,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,126,239,191,189,239,191,189,36,239,191,189,26,239,191,189,114,239,191,189,32,239,191,189,5,83,239,191,189,239,191,189,239,191,189,239,191,189,52,31,239,191,189,52,239,191,189,239,191,189,239,191,189,124,88,66,239,191,189,65,204,190,39,4,109,12,219,189,239,191,189,239,191,189,239,191,189,57,239,191,189,63,6,239,191,189,239,191,189,95,239,191,189,239,191,189,3,239,191,189,239,191,189,121,239,191,189,239,191,189,239,191,189,239,191,189,113,239,191,189,4,49,239,191,189,97,89,0,239,191,189,115,239,191,189,239,191,189,239,191,189,70,127,239,191,189,239,191,189,22,239,191,189,239,191,189,239,191,189,111,239,191,189,239,191,189,69,239,191,189,34,90,239,191,189,239,191,189,82,239,191,189,239,191,189,51,124,239,191,189,239,191,189,7,239,191,189,221,173,239,191,189,3,239,191,189,46,23,19,85,77,229,151,163,94,239,191,189,2,239,191,189,59,239,191,189,33,62,239,191,189,117,10,33,239,191,189,15,239,191,189,201,182,239,191,189,239,191,189,82,239,191,189,71,100,107,239,191,189,239,191,189,46,239,191,189,239,191,189,12,239,191,189,67,239,191,189,239,191,189,239,191,189,123,122,211,190,27,239,191,189,239,191,189,239,191,189,22,239,191,189,239,191,189,107,8,86,239,191,189,239,191,189,77,239,191,189,81,239,191,189,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,108,113,239,191,189,239,191,189,239,191,189,114,46,47,64,79,239,191,189,239,191,189,216,175,14,239,191,189,78,114,44,47,37,94,64,117,88,239,191,189,93,239,191,189,51,40,239,191,189,239,191,189,29,93,54,45,239,191,189,71,50,87,60,239,191,189,21,61,239,191,189,115,204,162,239,191,189,19,5,36,239,191,189,114,239,191,189,14,49,125,118,39,21,75,239,191,189,24,107,13,239,191,189,122,120,239,191,189,239,191,189,6,63,239,191,189,239,191,189,77,72,3,239,191,189,239,191,189,210,187,65,32,35,239,191,189,2,239,191,189,239,191,189,40,239,191,189,62,239,191,189,10,66,239,191,189,239,191,189,239,191,189,209,166,239,191,189,81,41,239,191,189,53,239,191,189,239,191,189,239,191,189,127,75,239,191,189,46,239,191,189,239,191,189,84,90,10,239,191,189,239,191,189,239,191,189,11,17,239,191,189,79,239,191,189,54,53,239,191,189,0,112,75,49,25,45,239,191,189,239,191,189,127,239,191,189,36,239,191,189,5,43,121,98,205,129,62,239,191,189,239,191,189,239,191,189,239,191,189,7,37,239,191,189,239,191,189,239,191,189,239,191,189,219,149,199,175,107,126,239,191,189,122,239,191,189,239,191,189,100,239,191,189,200,138,239,191,189,239,191,189,239,191,189,5,239,191,189,60,239,191,189,24,29,239,191,189,127,239,191,189,25,112,67,12,126,239,191,189,229,183,163,85,92,43,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,31,93,14,54,82,239,191,189,239,191,189,95,239,191,189,239,191,189,120,239,191,189,47,239,191,189,101,105,54,239,191,189,36,239,191,189,239,191,189,16,239,191,189,116,239,191,189,107,56,239,191,189,5,71,62,30,239,191,189,239,191,189,239,191,189,98,13,239,191,189,239,191,189,199,134,239,191,189,239,191,189,220,141,239,191,189,239,191,189,72,54,239,191,189,239,191,189,239,191,189,239,191,189,14,118,114,194,171,42,239,191,189,239,191,189,239,191,189,124,57,239,191,189,239,191,189,53,239,191,189,7,41,54,60,20,103,69,6,239,191,189,230,171,146,239,191,189,102,84,102,239,191,189,32,239,191,189,124,69,239,191,189,75,14,239,191,189,62,239,191,189,239,191,189,100,239,191,189,239,191,189,105,239,191,189,239,191,189,46,239,191,189,239,191,189,125,239,191,189,239,191,189,112,239,191,189,239,191,189,0,239,191,189,239,191,189,92,239,191,189,21,239,191,189,239,191,189,239,191,189,99,23,239,191,189,39,126,213,163,97,239,191,189,27,10,65,239,191,189,80,55,204,187,6,54,27,239,191,189,239,191,189,61,111,14,38,239,191,189,102,81,78,239,191,189,76,239,191,189,239,191,189,59,23,239,191,189,239,191,189,239,191,189,19,239,191,189,103,206,151,209,190,239,191,189,71,36,239,191,189,89,239,191,189,89,239,191,189,5,239,191,189,239,191,189,110,25,88,47,60,15,83,45,239,191,189,239,191,189,5,21,31,35,56,7,35,49,76,6,239,191,189,239,191,189,80,125,94,66,239,191,189,239,191,189,63,239,191,189,239,191,189,61,58,104,239,191,189,239,191,189,87,123,105,19,239,191,189,239,191,189,50,5,239,191,189,32,239,191,189,54,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,95,239,191,189,239,191,189,12,33,103,239,191,189,239,191,189,239,191,189,96,62,239,191,189,239,191,189,60,239,191,189,82,239,191,189,43,60,239,191,189,211,152,239,191,189,24,41,36,10,105,239,191,189,239,191,189,20,239,191,189,239,191,189,27,124,72,239,191,189,239,191,189,35,239,191,189,80,70,239,191,189,23,239,191,189,239,191,189,239,191,189,70,119,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,84,14,239,191,189,239,191,189,67,239,191,189,126,48,239,191,189,42,239,191,189,32,111,239,191,189,65,98,89,97,25,46,239,191,189,81,239,191,189,1,100,39,18,35,40,239,191,189,111,239,191,189,56,239,191,189,39,58,239,191,189,239,191,189,239,191,189,75,59,32,239,191,189,239,191,189,69,239,191,189,239,191,189,55,4,20,239,191,189,67,239,191,189,108,9,2,73,239,191,189,27,239,191,189,91,8,196,186,239,191,189,239,191,189,223,152,7,101,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,30,19,40,43,81,203,134,37,239,191,189,10,239,191,189,108,239,191,189,239,191,189,23,239,191,189,19,106,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,106,239,191,189,121,239,191,189,100,83,54,212,129,239,191,189,60,239,191,189,239,191,189,239,191,189,239,191,189,29,88,115,22,90,239,191,189,109,71,19,74,239,191,189,239,191,189,81,2,239,191,189,60,33,99,81,239,191,189,123,81,239,191,189,239,191,189,239,191,189,239,191,189,34,234,157,163,33,82,239,191,189,239,191,189,85,43,239,191,189,85,239,191,189,239,191,189,239,191,189,101,92,239,191,189,112,239,191,189,209,150,239,191,189,27,239,191,189,75,239,191,189,14,239,191,189,121,239,191,189,121,239,191,189,239,191,189,239,191,189,239,191,189,112,41,92,94,113,99,239,191,189,16,57,14,83,239,191,189,239,191,189,239,191,189,10,45,239,191,189,81,84,239,191,189,7,239,191,189,239,191,189,239,191,189,239,191,189,121,110,239,191,189,71,122,239,191,189,239,191,189,50,89,17,115,109,0,239,191,189,239,191,189,239,191,189,7,33,239,191,189,239,191,189,239,191,189,75,239,191,189,100,45,239,191,189,239,191,189,85,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,63,11,74,7,239,191,189,80,239,191,189,27,124,239,191,189,84,85,239,191,189,11,15,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,34,56,239,191,189,77,45,12,239,191,189,4,107,239,191,189,239,191,189,71,4,22,68,239,191,189,25,239,191,189,239,191,189,48,26,239,191,189,239,191,189,98,67,239,191,189,69,239,191,189,239,191,189,239,191,189,197,169,6,40,239,191,189,239,191,189,233,183,172,239,191,189,239,191,189,7,12,81,239,191,189,239,191,189,36,239,191,189,9,66,239,191,189,239,191,189,30,99,116,239,191,189,239,191,189,11,239,191,189,116,239,191,189,63,118,62,109,61,239,191,189,239,191,189,62,239,191,189,239,191,189,75,239,191,189,114,120,239,191,189,17,239,191,189,239,191,189,33,4,87,239,191,189,239,191,189,239,191,189,239,191,189,197,136,15,32,239,191,189,239,191,189,59,239,191,189,199,149,18,33,239,191,189,97,49,88,9,84,239,191,189,112,239,191,189,234,167,185,20,69,239,191,189,112,239,191,189,239,191,189,239,191,189,82,239,191,189,85,239,191,189,56,47,239,191,189,65,94,69,239,191,189,239,191,189,54,239,191,189,239,191,189,59,239,191,189,239,191,189,239,191,189,239,191,189,58,92,70,59,239,191,189,239,191,189,86,12,102,79,239,191,189,51,27,239,191,189,239,191,189,107,52,100,239,191,189,41,42,18,48,43,239,191,189,57,113,239,191,189,239,191,189,10,222,158,239,191,189,34,239,191,189,239,191,189,111,25,34,88,239,191,189,239,191,189,239,191,189,15,122,124,239,191,189,239,191,189,63,38,6,91,239,191,189,239,191,189,95,39,44,26,63,239,191,189,111,239,191,189,239,191,189,91,112,44,239,191,189,239,191,189,1,239,191,189,239,191,189,27,65,239,191,189,80,87,55,33,239,191,189,127,239,191,189,239,191,189,122,91,3,239,191,189,197,185,195,133,239,191,189,84,217,129,239,191,189,59,72,127,239,191,189,77,216,156,239,191,189,117,41,239,191,189,26,55,239,191,189,7,239,191,189,10,104,239,191,189,239,191,189,239,191,189,34,46,88,239,191,189,103,239,191,189,53,124,0,239,191,189,65,239,191,189,239,191,189,20,14,239,191,189,239,191,189,100,239,191,189,8,97,4,49,24,104,239,191,189,52,239,191,189,239,191,189,239,191,189,239,191,189,25,239,191,189,97,25,26,39,239,191,189,239,191,189,239,191,189,102,10,117,239,191,189,239,191,189,89,126,112,239,191,189,56,239,191,189,4,25,239,191,189,37,29,239,191,189,64,239,191,189,217,182,121,239,191,189,65,239,191,189,40,59,86,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,86,239,191,189,239,191,189,110,14,15,239,191,189,239,191,189,92,55,239,191,189,0,239,191,189,60,239,191,189,28,239,191,189,41,12,55,239,191,189,35,52,197,128,30,40,116,4,239,191,189,239,191,189,239,191,189,95,81,206,142,77,239,191,189,119,239,191,189,239,191,189,10,239,191,189,40,239,191,189,26,239,191,189,215,169,239,191,189,113,239,191,189,239,191,189,51,90,239,191,189,239,191,189,239,191,189,239,191,189,79,239,191,189,239,191,189,239,191,189,97,239,191,189,64,110,109,239,191,189,21,239,191,189,66,68,56,239,191,189,42,239,191,189,88,116,13,117,44,239,191,189,10,20,221,156,239,191,189,51,99,239,191,189,239,191,189,239,191,189,215,135,115,239,191,189,105,239,191,189,239,191,189,8,239,191,189,239,191,189,47,61,124,239,191,189,48,239,191,189,239,191,189,124,239,191,189,217,147,239,191,189,120,77,195,163,239,191,189,57,107,50,44,94,239,191,189,66,239,191,189,239,191,189,125,239,191,189,10,98,239,191,189,35,106,20,239,191,189,32,239,191,189,3,107,77,9,10,239,191,189,98,34,15,38,239,191,189,239,191,189,239,191,189,87,239,191,189,97,239,191,189,208,155,58,217,141,123,239,191,189,113,118,239,191,189,111,74,99,104,35,239,191,189,239,191,189,54,0,239,191,189,34,84,239,191,189,223,159,239,191,189,86,11,69,239,191,189,239,191,189,239,191,189,8,74,19,3,239,191,189,38,118,239,136,151,239,191,189,239,191,189,239,191,189,215,171,239,191,189,239,191,189,65,4,33,239,191,189,125,239,191,189,124,239,191,189,90,58,239,191,189,36,239,191,189,44,239,191,189,104,239,191,189,65,25,84,31,239,191,189,239,191,189,239,191,189,16,92,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,106,3,239,191,189,107,233,139,163,239,191,189,63,239,191,189,239,191,189,125,239,191,189,239,191,189,107,239,191,189,107,10,239,191,189,239,191,189,105,239,191,189,239,191,189,86,97,239,191,189,32,27,239,191,189,239,191,189,110,114,16,239,191,189,79,40,103,239,191,189,239,191,189,239,191,189,118,239,191,189,239,191,189,18,239,191,189,66,69,239,191,189,31,26,239,191,189,239,191,189,48,87,47,239,191,189,95,46,10,93,106,239,191,189,239,191,189,127,28,121,109,63,126,67,62,110,11,239,191,189,26,239,191,189,239,191,189,239,191,189,239,191,189,30,70,239,191,189,239,191,189,239,191,189,39,239,191,189,66,239,191,189,92,103,239,191,189,56,239,191,189,75,239,191,189,239,191,189,96,239,191,189,72,239,191,189,6,16,239,191,189,239,191,189,42,239,191,189,79,60,239,191,189,71,205,153,239,191,189,23,216,138,58,88,239,191,189,55,239,191,189,239,191,189,22,122,6,123,105,239,191,189,43,239,191,189,65,239,191,189,76,73,64,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,124,239,191,189,32,239,191,189,239,191,189,7,239,191,189,115,100,239,191,189,8,101,17,32,34,239,191,189,98,213,175,109,239,191,189,17,239,191,189,5,49,76,239,191,189,239,191,189,86,106,117,90,239,191,189,68,56,11,239,191,189,126,102,115,239,191,189,34,239,191,189,32,56,55,59,41,29,239,191,189,239,191,189,239,191,189,77,71,55,107,28,26,239,191,189,82,101,239,191,189,29,239,191,189,50,239,191,189,239,191,189,239,191,189,239,191,189,23,2,239,191,189,110,59,239,191,189,239,191,189,74,239,191,189,239,191,189,239,191,189,16,120,239,191,189,205,173,239,191,189,12,239,191,189,13,239,191,189,239,191,189,220,181,20,14,43,5,239,191,189,238,139,173,111,65,6,239,191,189,217,128,18,239,191,189,239,191,189,32,239,191,189,77,239,191,189,65,239,191,189,239,191,189,79,76,239,191,189,239,191,189,239,191,189,239,191,189,26,39,38,45,90,45,99,239,191,189,126,239,191,189,65,77,239,191,189,55,239,191,189,72,239,191,189,4,239,191,189,239,191,189,109,239,191,189,109,239,191,189,239,191,189,239,191,189,34,49,239,191,189,127,65,234,182,176,39,239,191,189,94,239,191,189,38,239,191,189,85,12,239,191,189,239,191,189,12,239,191,189,239,191,189,239,191,189,70,7,121,239,191,189,239,191,189,28,81,108,239,191,189,239,191,189,70,239,191,189,11,50,239,191,189,239,191,189,107,86,239,191,189,239,191,189,15,239,191,189,239,191,189,39,239,191,189,22,239,191,189,96,10,239,191,189,239,191,189,101,50,108,239,191,189,6,239,191,189,69,239,191,189,94,239,191,189,35,239,191,189,101,239,191,189,239,191,189,35,47,239,191,189,106,239,191,189,234,174,165,113,30,82,201,143,239,191,189,239,191,189,98,34,21,239,191,189,85,239,191,189,71,47,239,191,189,239,191,189,17,239,191,189,239,191,189,84,239,191,189,34,239,191,189,63,60,96,48,102,45,239,191,189,122,239,191,189,239,191,189,120,239,191,189,239,191,189,207,181,2,108,88,1,239,191,189,239,191,189,73,58,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,27,80,239,191,189,239,191,189,239,191,189,239,191,189,82,55,239,191,189,239,191,189,239,191,189,72,102,239,191,189,239,191,189,206,159,68,2,91,239,191,189,38,239,191,189,239,191,189,113,62,239,191,189,1,239,191,189,49,239,191,189,239,191,189,40,239,191,189,104,118,239,191,189,239,191,189,36,69,99,203,171,92,12,103,29,120,99,13,96,103,239,191,189,72,239,191,189,239,191,189,83,15,239,191,189,81,239,191,189,80,239,191,189,239,191,189,64,94,32,239,191,189,104,96,21,11,31,239,191,189,239,191,189,44,122,239,191,189,239,191,189,10,33,125,239,191,189,118,239,191,189,83,0,223,148,115,35,239,191,189,10,211,178,18,24,28,28,239,191,189,71,65,15,3,239,191,189,84,71,239,191,189,80,239,191,189,122,239,191,189,107,127,47,22,239,191,189,60,239,191,189,239,191,189,93,64,70,239,191,189,60,107,0,76,10,239,191,189,20,94,239,191,189,239,191,189,239,191,189,239,191,189,109,239,191,189,126,124,12,40,239,191,189,239,191,189,239,191,189,111,63,239,191,189,239,191,189,239,191,189,95,239,191,189,93,47,80,6,239,191,189,26,198,140,83,239,191,189,239,191,189,106,239,191,189,28,48,117,239,191,189,80,239,191,189,24,239,191,189,66,239,191,189,53,239,191,189,124,239,191,189,239,191,189,44,117,239,191,189,110,239,191,189,56,0,83,239,191,189,239,191,189,239,191,189,83,239,191,189,239,191,189,40,17,90,37,21,239,191,189,62,239,191,189,239,191,189,82,239,191,189,71,30,27,80,27,85,126,29,239,191,189,96,239,191,189,81,95,239,191,189,125,27,239,191,189,239,191,189,0,108,85,69,239,191,189,25,239,191,189,219,139,103,32,239,191,189,98,239,191,189,86,124,62,25,239,191,189,3,239,191,189,101,101,53,217,146,74,239,191,189,239,191,189,64,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,2,84,2,239,191,189,64,239,191,189,23,239,191,189,106,239,191,189,56,239,191,189,239,191,189,99,53,239,191,189,70,239,191,189,7,32,107,56,239,191,189,14,239,191,189,74,239,191,189,94,44,104,239,191,189,111,239,191,189,60,239,191,189,239,191,189,73,239,191,189,77,56,111,239,191,189,17,239,191,189,24,239,191,189,52,239,191,189,239,191,189,239,191,189,51,239,191,189,124,239,191,189,27,50,114,95,127,72,239,191,189,61,239,191,189,96,239,191,189,3,105,239,191,189,82,87,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,74,200,175,239,191,189,211,164,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,239,191,189,15,239,191,189,28,4,239,191,189,49,239,191,189,239,191,189,55,21,49,239,191,189,56,49,239,191,189,53,37,239,191,189,239,191,189,120,117,40,239,191,189,207,174,202,153,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,72,19,239,191,189,76,201,164,11,18,239,191,189,126,5,239,191,189,114,239,191,189,110,106,239,191,189,10,49,58,239,191,189,82,76,86,207,152,31,239,191,189,60,117,109,239,191,189,239,191,189,239,191,189,82,112,72,239,191,189,239,191,189,105,21,239,191,189,81,239,191,189,48,39,239,191,189,78,239,191,189,209,185,239,191,189,104,97,239,191,189,239,191,189,95,125,49,239,191,189,23,239,191,189,61,16,101,4,239,191,189,90,28,239,191,189,239,191,189,56,93,239,191,189,239,191,189,109,239,191,189,239,191,189,239,191,189,112,61,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,46,239,191,189,239,191,189,17,202,159,79,82,62,239,191,189,64,67,43,239,191,189,239,191,189,49,239,191,189,76,239,191,189,103,239,191,189,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,71,113,44,239,191,189,92,239,191,189,239,191,189,1,119,96,232,186,153,13,126,239,191,189,198,185,105,115,211,182,116,19,86,50,116,239,191,189,239,191,189,239,191,189,32,95,239,191,189,239,191,189,8,239,191,189,17,12,239,191,189,85,239,191,189,15,209,174,239,191,189,239,191,189,89,25,239,191,189,239,191,189,239,191,189,72,106,239,191,189,239,191,189,25,67,42,21,63,8,239,191,189,63,239,191,189,206,186,5,239,191,189,239,191,189,239,191,189,213,175,30,54,239,191,189,239,191,189,100,239,191,189,74,26,125,239,191,189,1,63,22,239,191,189,239,191,189,119,239,191,189,239,191,189,200,185,239,191,189,21,239,191,189,39,239,191,189,37,239,191,189,45,83,123,121,239,191,189,11,239,191,189,76,239,191,189,239,191,189,89,239,191,189,126,239,191,189,239,191,189,239,191,189,10,239,191,189,0,114,76,202,142,239,191,189,239,191,189,239,191,189,28,10,8,239,191,189,127,17,63,1,29,239,191,189,1,239,191,189,47,51,125,53,57,239,191,189,239,191,189,67,74,217,170,83,239,191,189,64,239,191,189,239,191,189,119,99,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,67,19,107,72,117,124,239,191,189,51,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,1,45,69,239,191,189,66,96,239,191,189,26,62,239,191,189,239,191,189,239,191,189,239,191,189,1,62,239,191,189,77,68,239,191,189,239,191,189,37,33,66,239,191,189,239,191,189,22,119,239,191,189,2,239,191,189,195,188,97,239,191,189,195,149,239,191,189,58,239,191,189,46,239,191,189,239,191,189,44,239,191,189,239,191,189,239,191,189,8,49,239,191,189,239,191,189,105,239,191,189,7,36,106,239,191,189,239,191,189,119,239,191,189,43,239,191,189,32,23,239,191,189,239,191,189,239,191,189,41,239,191,189,61,239,191,189,239,191,189,18,239,191,189,239,191,189,98,44,239,191,189,121,239,191,189,239,191,189,14,70,18,16,31,58,239,191,189,60,103,239,191,189,51,97,239,191,189,70,110,239,191,189,119,11,25,239,191,189,32,239,191,189,239,191,189,7,86,239,191,189,71,239,191,189,62,239,191,189,113,239,191,189,239,191,189,29,239,191,189,14,7,239,191,189,239,191,189,26,239,191,189,127,89,239,191,189,239,191,189,239,191,189,22,121,239,191,189,74,126,110,239,191,189,20,239,191,189,82,57,8,239,191,189,72,109,122,41,239,191,189,56,239,191,189,101,99,239,191,189,96,239,191,189,239,191,189,239,191,189,219,160,239,191,189,239,191,189,80,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,108,3,239,191,189,239,191,189,47,80,239,191,189,239,191,189,239,191,189,58,239,191,189,114,86,96,239,191,189,22,75,239,191,189,213,147,112,239,191,189,239,191,189,239,191,189,57,76,239,191,189,94,239,191,189,34,108,239,191,189,239,191,189,53,239,191,189,52,239,191,189,125,52,83,239,191,189,239,191,189,18,77,81,105,73,57,20,58,90,41,239,191,189,58,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,118,72,239,191,189,239,191,189,14,239,191,189,33,211,145,61,239,191,189,126,239,191,189,7,239,191,189,239,191,189,239,191,189,123,239,191,189,2,126,74,124,239,191,189,67,239,191,189,114,239,191,189,239,191,189,23,239,191,189,239,191,189,81,239,191,189,21,239,191,189,102,127,67,239,191,189,40,102,239,191,189,239,191,189,239,191,189,239,191,189,118,50,239,191,189,67,239,191,189,126,239,191,189,239,191,189,24,44,239,191,189,239,191,189,104,82,112,21,122,93,239,191,189,45,239,191,189,239,191,189,3,37,25,55,43,239,191,189,24,239,191,189,127,59,239,191,189,47,64,239,191,189,121,239,191,189,96,239,191,189,113,239,191,189,239,191,189,199,129,239,191,189,239,191,189,81,239,191,189,81,8,239,191,189,239,191,189,125,239,191,189,63,239,191,189,30,107,70,239,191,189,5,0,100,75,239,191,189,239,191,189,57,17,239,191,189,239,191,189,239,191,189,239,191,189,14,239,191,189,34,9,60,239,191,189,37,93,239,191,189,34,199,190,223,173,26,126,1,239,191,189,91,38,25,60,107,239,191,189,239,191,189,123,239,191,189,1,239,191,189,64,12,239,191,189,32,239,191,189,127,239,191,189,239,191,189,54,239,191,189,123,70,239,191,189,239,191,189,239,191,189,57,239,191,189,107,239,191,189,216,187,16,239,191,189,64,239,191,189,239,191,189,239,191,189,80,127,239,191,189,239,191,189,239,191,189,36,239,191,189,239,191,189,22,17,239,191,189,60,45,88,239,191,189,239,191,189,44,239,191,189,239,191,189,48,99,239,191,189,106,239,191,189,16,239,191,189,40,239,191,189,48,58,117,93,239,191,189,239,191,189,113,14,239,191,189,239,191,189,34,45,63,239,191,189,39,7,46,239,191,189,127,239,191,189,69,239,191,189,96,239,191,189,110,239,191,189,21,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,105,219,155,65,125,239,191,189,239,191,189,239,191,189,24,62,45,239,191,189,2,36,239,191,189,66,239,191,189,239,191,189,14,239,191,189,27,239,191,189,20,122,12,62,239,191,189,239,191,189,12,62,239,191,189,39,88,239,191,189,239,191,189,197,177,77,239,191,189,239,191,189,45,103,51,38,239,191,189,74,12,239,191,189,239,191,189,239,191,189,239,191,189,82,239,191,189,126,70,239,191,189,239,191,189,112,65,60,239,191,189,11,0,105,239,191,189,239,191,189,77,201,181,17,47,239,191,189,16,51,239,191,189,45,239,191,189,84,91,239,191,189,37,62,111,239,191,189,212,158,87,239,191,189,5,239,191,189,65,11,91,239,191,189,34,103,201,144,6,239,191,189,66,29,239,191,189,239,191,189,28,66,239,191,189,239,191,189,25,239,191,189,114,20,77,239,191,189,239,191,189,204,144,239,191,189,239,191,189,11,239,191,189,31,239,191,189,18,238,182,180,53,239,191,189,239,191,189,23,239,191,189,84,239,191,189,91,7,239,191,189,239,191,189,201,146,24,239,191,189,239,191,189,96,239,191,189,44,239,191,189,239,191,189,57,85,239,191,189,70,239,191,189,239,191,189,6,35,109,239,191,189,239,191,189,102,239,191,189,80,40,83,239,191,189,239,191,189,239,191,189,85,68,239,191,189,74,239,191,189,239,191,189,46,239,191,189,97,239,191,189,78,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,68,239,191,189,239,191,189,239,191,189,89,239,191,189,55,239,191,189,239,191,189,32,98,4,239,191,189,108,61,239,191,189,239,191,189,108,104,120,124,11,23,239,191,189,239,191,189,7,239,191,189,239,191,189,31,36,239,191,189,110,239,191,189,84,239,191,189,100,239,191,189,239,191,189,101,99,12,35,113,239,191,189,87,41,43,239,191,189,80,123,239,191,189,85,239,191,189,127,127,57,239,191,189,68,83,82,76,239,191,189,122,239,191,189,50,239,191,189,110,115,239,191,189,239,191,189,22,36,7,5,107,88,239,191,189,119,53,119,220,176,69,239,191,189,124,239,191,189,239,191,189,22,212,170,239,191,189,120,102,19,22,106,239,191,189,239,191,189,108,98,239,191,189,239,191,189,108,118,100,239,191,189,77,239,191,189,19,38,239,191,189,96,14,239,191,189,118,239,191,189,92,239,191,189,55,239,191,189,22,88,239,191,189,239,191,189,76,239,191,189,239,191,189,239,191,189,239,191,189,1,239,191,189,239,191,189,11,211,188,36,67,239,191,189,62,239,191,189,75,84,2,239,191,189,11,44,105,239,191,189,239,191,189,121,14,210,133,239,191,189,75,97,24,239,191,189,41,239,191,189,239,191,189,89,239,191,189,18,118,239,191,189,85,58,31,81,89,239,191,189,239,191,189,62,77,239,191,189,86,239,191,189,239,191,189,32,52,51,87,117,239,191,189,239,191,189,87,55,239,191,189,90,12,239,191,189,239,191,189,121,52,239,191,189,239,191,189,54,72,239,191,189,47,106,75,32,239,191,189,58,70,239,191,189,239,191,189,11,38,239,191,189,9,239,191,189,239,191,189,2,38,31,239,191,189,108,29,239,191,189,239,191,189,69,239,191,189,239,191,189,30,10,92,9,102,239,191,189,239,191,189,73,5,239,191,189,11,84,114,239,191,189,16,239,191,189,239,191,189,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,207,157,219,185,124,239,191,189,5,123,239,191,189,27,60,41,239,191,189,239,191,189,108,50,239,191,189,239,191,189,239,191,189,239,191,189,209,173,239,191,189,92,108,239,191,189,118,96,239,191,189,77,55,103,109,118,239,191,189,29,239,191,189,239,191,189,239,191,189,36,6,239,191,189,219,135,211,135,125,239,191,189,120,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,34,239,191,189,127,77,239,191,189,47,239,191,189,239,191,189,73,239,191,189,213,188,10,13,79,239,191,189,47,2,239,191,189,239,191,189,239,191,189,239,191,189,110,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,113,218,139,117,239,191,189,116,117,46,66,239,191,189,239,191,189,97,9,239,191,189,239,191,189,239,191,189,239,191,189,115,239,191,189,41,64,239,191,189,89,56,7,239,191,189,81,56,239,191,189,104,239,191,189,99,239,191,189,239,191,189,239,191,189,9,73,70,85,239,191,189,239,191,189,85,239,191,189,64,239,191,189,239,191,189,239,191,189,64,202,137,25,239,191,189,47,239,191,189,239,191,189,197,128,83,110,239,191,189,34,61,55,239,191,189,49,239,191,189,239,191,189,35,239,191,189,239,191,189,239,191,189,239,191,189,29,2,79,239,191,189,25,239,191,189,120,239,191,189,16,109,110,78,239,191,189,51,239,191,189,62,18,239,191,189,239,191,189,239,191,189,106,118,239,191,189,30,18,15,27,239,191,189,203,134,48,211,149,239,191,189,44,110,239,191,189,6,103,239,191,189,239,191,189,16,17,239,191,189,200,139,100,94,239,191,189,239,191,189,17,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,203,172,10,111,239,191,189,15,239,191,189,61,239,191,189,239,191,189,38,6,239,191,189,239,191,189,11,33,44,239,191,189,89,100,239,191,189,85,239,191,189,239,191,189,239,191,189,70,239,191,189,239,191,189,31,20,239,191,189,239,191,189,239,191,189,90,92,89,104,1,239,191,189,239,191,189,46,239,191,189,61,87,19,100,239,191,189,239,191,189,239,191,189,89,38,239,191,189,117,37,95,239,191,189,70,40,239,191,189,30,239,191,189,239,191,189,51,101,214,141,239,191,189,239,191,189,239,191,189,122,88,239,191,189,58,39,239,191,189,109,101,51,239,191,189,68,46,239,191,189,34,239,191,189,122,239,191,189,125,52,239,191,189,239,191,189,34,239,191,189,239,191,189,116,239,191,189,4,9,239,191,189,60,239,191,189,239,191,189,43,239,191,189,78,0,74,239,191,189,78,113,239,191,189,76,19,239,191,189,101,239,191,189,5,239,191,189,239,191,189,239,191,189,2,15,124,239,191,189,42,88,126,239,191,189,239,191,189,126,239,191,189,99,115,239,191,189,239,191,189,90,3,239,191,189,212,153,48,39,47,239,191,189,10,91,14,51,120,239,191,189,239,191,189,88,112,6,57,239,191,189,110,99,239,191,189,239,191,189,239,191,189,75,239,191,189,239,191,189,194,143,239,191,189,28,239,191,189,11,239,191,189,68,239,191,189,0,239,191,189,239,191,189,224,184,189,239,191,189,73,75,239,191,189,65,239,191,189,87,239,191,189,108,239,191,189,239,191,189,239,191,189,43,239,191,189,23,239,191,189,65,96,0,122,239,191,189,239,191,189,57,109,239,191,189,94,127,112,75,94,230,181,165,198,172,54,196,163,239,191,189,106,239,191,189,107,96,21,31,75,24,239,191,189,239,191,189,214,153,127,239,191,189,67,75,86,18,25,239,191,189,124,215,130,33,94,239,191,189,54,239,191,189,101,49,239,191,189,32,239,191,189,109,239,191,189,239,191,189,23,239,191,189,35,77,77,70,239,191,189,239,191,189,117,239,191,189,103,239,191,189,98,123,86,36,239,191,189,239,191,189,118,239,191,189,25,73,1,23,239,191,189,81,239,191,189,239,191,189,7,239,191,189,239,191,189,18,33,100,51,239,191,189,239,191,189,239,191,189,91,54,81,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,219,189,117,239,191,189,239,191,189,2,239,191,189,206,144,11,101,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,71,239,191,189,53,222,159,64,66,30,239,191,189,105,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,73,63,88,28,31,239,191,189,101,52,239,191,189,102,95,239,191,189,239,191,189,122,239,191,189,239,191,189,65,94,239,191,189,239,191,189,73,239,191,189,239,191,189,2,239,191,189,239,191,189,239,191,189,48,38,239,191,189,239,191,189,66,239,191,189,239,191,189,54,239,191,189,113,56,239,191,189,94,239,191,189,92,82,120,64,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,63,81,30,38,239,191,189,194,168,85,102,94,239,191,189,52,13,88,239,191,189,29,239,191,189,239,191,189,67,108,93,9,239,191,189,60,239,191,189,239,191,189,52,31,239,191,189,24,19,2,127,239,191,189,74,100,35,239,191,189,42,116,239,191,189,27,239,191,189,93,100,239,191,189,79,239,191,189,239,191,189,34,239,191,189,239,191,189,96,68,61,54,239,191,189,239,191,189,102,239,191,189,239,191,189,239,191,189,239,191,189,77,75,239,191,189,239,191,189,239,191,189,13,76,239,191,189,53,239,191,189,207,148,65,54,68,239,191,189,18,239,191,189,58,88,239,191,189,85,44,239,191,189,58,78,20,239,191,189,65,60,114,239,191,189,78,239,191,189,239,191,189,18,110,239,191,189,239,191,189,239,191,189,122,41,239,191,189,74,239,191,189,239,191,189,239,191,189,239,191,189,107,10,84,26,82,49,239,191,189,239,191,189,30,84,122,50,239,191,189,239,191,189,239,191,189,239,191,189,41,239,191,189,69,239,191,189,239,191,189,50,105,25,239,191,189,76,239,191,189,118,239,191,189,239,191,189,18,239,191,189,82,21,73,54,239,191,189,87,239,191,189,29,239,191,189,239,191,189,239,191,189,26,126,239,191,189,239,191,189,239,191,189,113,239,191,189,33,239,191,189,106,66,77,56,239,191,189,59,75,6,83,125,49,61,66,239,191,189,239,191,189,239,191,189,77,239,191,189,17,239,191,189,84,39,37,37,62,79,239,191,189,52,88,239,191,189,4,50,239,191,189,106,31,16,239,191,189,17,239,191,189,239,191,189,11,239,191,189,239,191,189,23,91,239,191,189,215,143,239,191,189,16,239,191,189,239,191,189,78,83,66,28,40,239,191,189,81,239,191,189,23,239,191,189,88,120,239,191,189,125,239,191,189,239,191,189,239,191,189,28,60,239,191,189,100,239,191,189,239,191,189,93,13,201,137,119,11,121,71,101,20,239,191,189,113,22,239,191,189,239,191,189,22,67,12,239,191,189,239,191,189,113,239,191,189,93,56,0,239,191,189,239,191,189,239,191,189,88,5,30,239,191,189,239,191,189,239,191,189,15,94,113,218,149,239,191,189,102,239,191,189,99,78,11,239,191,189,239,191,189,239,191,189,124,37,239,191,189,88,239,191,189,239,191,189,239,191,189,110,107,80,119,75,239,191,189,83,12,15,239,191,189,239,191,189,239,191,189,239,191,189,64,239,191,189,104,118,86,122,126,59,14,45,62,239,191,189,15,119,51,93,198,182,239,191,189,239,191,189,239,191,189,239,191,189,32,99,73,15,19,239,191,189,84,239,191,189,34,56,239,191,189,239,191,189,60,127,62,239,191,189,123,107,108,51,93,35,56,127,127,239,191,189,217,178,239,191,189,51,239,191,189,239,191,189,68,77,239,191,189,5,45,70,102,239,191,189,239,191,189,81,10,5,239,191,189,23,58,239,191,189,30,239,191,189,58,60,239,191,189,108,239,191,189,239,191,189,42,202,144,55,12,239,191,189,239,191,189,239,191,189,88,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,52,4,239,191,189,77,11,24,51,239,191,189,103,239,191,189,38,239,191,189,239,191,189,239,191,189,239,191,189,113,216,183,239,191,189,239,191,189,98,239,191,189,47,239,191,189,68,94,28,239,191,189,239,191,189,100,75,239,191,189,239,191,189,48,6,55,239,191,189,31,239,191,189,239,191,189,239,191,189,28,40,239,191,189,239,191,189,14,12,239,191,189,239,191,189,239,191,189,239,191,189,55,114,94,81,126,239,191,189,72,8,239,191,189,239,191,189,239,191,189,239,191,189,2,84,109,239,191,189,239,191,189,239,191,189,108,239,191,189,239,191,189,45,239,191,189,239,191,189,69,239,191,189,239,191,189,239,191,189,54,82,37,239,191,189,70,239,191,189,20,69,239,191,189,223,136,98,112,22,239,191,189,239,191,189,113,65,38,66,121,95,87,4,71,239,191,189,34,9,239,191,189,122,11,239,191,189,60,239,191,189,239,191,189,91,214,140,239,191,189,121,64,40,39,239,191,189,105,9,72,239,191,189,80,239,191,189,114,4,103,86,43,239,191,189,239,191,189,33,239,191,189,114,103,11,118,12,211,151,38,239,191,189,67,239,191,189,17,228,173,172,2,80,55,239,191,189,239,191,189,61,239,191,189,127,239,191,189,20,7,7,239,191,189,239,191,189,119,239,191,189,96,239,191,189,239,191,189,33,17,52,239,191,189,26,2,239,191,189,239,191,189,124,95,207,169,239,191,189,86,239,191,189,84,219,158,122,239,191,189,116,239,191,189,239,191,189,82,98,4,239,191,189,13,63,84,71,33,92,10,239,191,189,239,191,189,205,158,28,126,239,191,189,90,15,32,239,191,189,106,122,239,191,189,207,146,239,191,189,93,239,191,189,45,102,59,41,239,191,189,79,22,54,197,164,39,24,239,191,189,76,239,191,189,239,191,189,31,239,191,189,60,239,191,189,239,191,189,239,191,189,26,239,191,189,239,191,189,105,239,191,189,239,191,189,26,62,239,191,189,239,191,189,239,191,189,59,46,239,191,189,80,114,239,191,189,79,6,71,1,239,191,189,239,191,189,7,59,29,239,191,189,239,191,189,11,96,239,191,189,239,191,189,110,76,101,97,121,87,239,191,189,28,239,191,189,239,191,189,111,46,114,29,239,191,189,122,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,100,239,191,189,239,191,189,45,217,147,51,239,191,189,239,191,189,87,14,81,239,191,189,87,239,191,189,16,113,239,191,189,123,42,122,239,191,189,120,239,191,189,239,191,189,0,23,108,3,111,115,95,53,239,191,189,239,191,189,119,239,191,189,75,126,239,191,189,239,191,189,239,191,189,84,24,32,32,92,239,191,189,239,191,189,239,191,189,42,239,191,189,0,239,191,189,67,239,191,189,117,239,191,189,99,239,191,189,123,198,138,50,239,191,189,27,16,110,115,112,38,121,239,191,189,66,239,191,189,107,96,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,103,69,124,95,239,191,189,109,67,2,239,191,189,239,191,189,124,33,111,33,51,114,4,76,25,27,44,3,125,125,71,239,191,189,57,20,46,239,191,189,54,239,191,189,239,191,189,35,239,191,189,103,78,111,239,191,189,42,113,239,191,189,62,239,191,189,6,32,17,73,44,70,239,191,189,86,118,239,191,189,59,65,239,191,189,239,191,189,100,239,191,189,10,239,191,189,45,109,239,191,189,56,75,52,239,191,189,35,239,191,189,239,191,189,239,191,189,117,197,168,118,39,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,116,40,239,191,189,103,107,11,239,191,189,32,239,191,189,42,16,103,117,239,191,189,239,191,189,21,95,34,15,239,191,189,239,191,189,22,239,191,189,123,87,108,61,239,191,189,27,4,239,191,189,23,239,191,189,28,15,99,239,191,189,101,239,191,189,239,191,189,239,191,189,239,191,189,38,74,239,191,189,64,1,63,239,191,189,218,136,239,191,189,6,50,239,191,189,17,35,48,15,239,191,189,239,191,189,239,191,189,5,127,239,191,189,239,191,189,239,191,189,88,239,191,189,98,239,191,189,239,191,189,106,239,191,189,239,191,189,239,191,189,239,191,189,122,239,191,189,22,106,239,191,189,14,64,124,239,191,189,16,91,48,239,191,189,64,87,85,239,191,189,239,191,189,239,191,189,201,166,194,187,102,239,191,189,102,239,191,189,77,239,191,189,91,239,191,189,53,50,32,239,191,189,106,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,2,239,191,189,239,191,189,127,40,239,191,189,34,53,239,191,189,239,191,189,239,191,189,75,239,191,189,74,239,191,189,10,239,191,189,194,151,239,191,189,239,191,189,238,129,143,37,239,191,189,221,151,239,191,189,92,35,239,191,189,239,191,189,4,239,191,189,24,239,191,189,231,128,140,102,24,233,170,181,239,191,189,65,239,191,189,239,191,189,96,72,239,191,189,56,107,239,191,189,20,41,90,89,42,239,191,189,239,191,189,71,72,239,191,189,239,191,189,236,166,159,55,239,191,189,65,10,30,239,191,189,5,239,191,189,239,191,189,59,239,191,189,7,239,191,189,239,191,189,20,81,239,191,189,86,51,239,191,189,239,191,189,120,239,191,189,85,239,191,189,239,191,189,208,160,28,239,191,189,95,84,48,82,40,127,239,191,189,46,76,239,191,189,15,82,239,191,189,29,109,239,191,189,239,191,189,52,60,46,52,239,191,189,22,239,191,189,239,191,189,59,239,191,189,121,66,10,100,239,191,189,4,239,191,189,103,239,191,189,83,100,239,191,189,239,191,189,239,191,189,9,62,239,191,189,239,191,189,239,191,189,111,239,191,189,239,191,189,22,108,239,191,189,43,239,191,189,25,239,191,189,106,68,239,191,189,239,191,189,9,235,170,152,124,66,5,30,239,191,189,86,239,191,189,123,239,191,189,42,121,239,191,189,20,239,191,189,239,191,189,4,239,191,189,75,239,191,189,239,191,189,239,191,189,93,239,191,189,203,189,239,191,189,239,191,189,80,28,239,191,189,0,83,239,191,189,3,123,45,239,191,189,125,101,239,191,189,239,191,189,101,239,191,189,1,34,239,191,189,239,191,189,239,191,189,120,239,191,189,213,189,239,191,189,239,191,189,239,191,189,31,239,191,189,58,97,239,191,189,91,78,94,239,191,189,41,38,239,191,189,16,75,239,191,189,34,96,239,191,189,52,42,115,98,239,191,189,239,191,189,58,36,86,239,191,189,124,239,191,189,67,92,35,67,92,239,191,189,239,191,189,28,239,191,189,100,127,6,30,239,191,189,239,191,189,239,191,189,124,88,239,191,189,125,116,239,191,189,194,135,76,239,191,189,239,191,189,38,239,191,189,5,118,239,191,189,239,191,189,239,191,189,202,158,239,191,189,239,191,189,2,122,68,95,207,171,108,67,214,173,121,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,108,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,239,191,189,95,9,36,59,239,191,189,49,34,239,191,189,105,239,191,189,2,48,119,239,191,189,239,191,189,239,191,189,120,13,239,191,189,18,6,121,239,191,189,94,122,49,2,239,191,189,79,74,100,78,239,191,189,112,239,191,189,71,7,239,191,189,123,86,239,191,189,239,191,189,35,239,191,189,83,239,191,189,239,191,189,23,38,239,191,189,49,72,239,191,189,88,239,191,189,66,239,191,189,118,0,31,239,191,189,25,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,113,39,104,87,25,113,85,239,191,189,10,239,191,189,239,191,189,67,239,191,189,40,239,191,189,50,6,239,191,189,24,18,5,42,111,123,54,31,123,239,191,189,95,114,18,35,239,191,189,127,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,58,92,239,191,189,239,191,189,117,239,191,189,26,239,191,189,239,191,189,107,239,191,189,7,106,39,239,191,189,70,239,191,189,239,191,189,32,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,115,103,239,191,189,63,114,29,105,20,59,49,216,169,88,126,6,90,4,239,191,189,239,191,189,239,191,189,10,239,191,189,94,239,191,189,111,239,191,189,239,191,189,208,165,239,191,189,120,239,191,189,57,125,14,30,239,191,189,126,239,191,189,1,239,191,189,239,191,189,57,78,239,191,189,239,191,189,56,239,191,189,239,191,189,239,191,189,106,27,239,191,189,2,105,239,191,189,95,81,3,81,239,191,189,68,239,191,189,63,95,239,191,189,30,1,239,191,189,59,40,11,239,191,189,239,191,189,239,191,189,62,239,191,189,15,4,239,191,189,239,191,189,239,191,189,9,239,191,189,239,191,189,93,68,55,19,96,239,191,189,239,191,189,123,127,115,239,191,189,53,239,191,189,239,191,189,21,239,191,189,54,239,191,189,239,191,189,94,71,239,191,189,51,42,44,80,77,239,191,189,239,191,189,239,191,189,58,239,191,189,2,239,191,189,239,191,189,239,191,189,125,239,191,189,239,191,189,84,127,76,9,239,191,189,32,239,191,189,91,5,126,239,191,189,40,22,239,191,189,3,239,191,189,51,110,60,239,191,189,239,191,189,239,191,189,72,77,66,239,191,189,239,191,189,72,88,13,45,239,191,189,239,191,189,31,239,191,189,33,239,191,189,47,94,239,191,189,99,239,191,189,239,191,189,5,239,191,189,239,191,189,239,191,189,239,191,189,5,98,15,98,239,191,189,239,191,189,239,191,189,3,239,191,189,68,52,103,239,191,189,18,239,191,189,113,239,191,189,90,35,239,191,189,28,199,141,62,239,191,189,39,92,71,239,191,189,72,239,191,189,0,239,191,189,4,67,239,191,189,239,191,189,239,191,189,54,95,122,239,191,189,101,98,239,191,189,239,191,189,8,80,239,191,189,73,80,52,239,191,189,98,239,191,189,61,239,191,189,209,132,112,54,93,118,115,239,191,189,51,239,191,189,239,191,189,207,183,116,239,191,189,36,239,191,189,11,57,97,43,67,239,191,189,30,12,96,67,239,191,189,127,55,60,61,5,32,44,69,239,191,189,40,29,109,239,191,189,239,191,189,239,191,189,46,68,239,191,189,47,239,191,189,101,15,4,86,239,191,189,219,170,239,191,189,239,191,189,81,42,239,191,189,50,122,17,239,191,189,239,191,189,239,191,189,201,151,72,239,191,189,94,239,191,189,239,191,189,239,191,189,110,89,124,239,191,189,218,138,49,111,239,191,189,111,50,239,191,189,42,117,239,191,189,239,191,189,116,239,191,189,32,59,120,239,191,189,203,162,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,105,104,239,191,189,108,80,17,239,191,189,119,239,191,189,239,191,189,239,191,189,239,191,189,201,165,213,159,33,239,191,189,239,191,189,239,191,189,205,145,239,191,189,239,191,189,239,191,189,21,27,210,153,239,191,189,209,190,239,191,189,126,239,191,189,36,239,191,189,239,191,189,239,191,189,94,85,119,239,191,189,29,1,239,191,189,239,191,189,25,118,239,191,189,239,191,189,239,191,189,204,154,48,118,239,191,189,96,239,191,189,91,239,191,189,49,239,191,189,22,239,191,189,0,38,239,191,189,239,191,189,239,191,189,28,58,239,191,189,62,120,25,102,123,239,191,189,23,51,239,191,189,35,239,191,189,12,239,191,189,239,191,189,239,191,189,70,109,44,239,191,189,35,239,191,189,122,57,0,239,191,189,1,54,121,198,137,215,142,33,23,16,59,239,191,189,239,191,189,40,20,13,239,191,189,9,239,191,189,4,66,40,239,191,189,239,191,189,239,191,189,73,77,239,191,189,84,239,191,189,239,191,189,65,239,191,189,64,49,239,191,189,239,191,189,57,239,191,189,32,109,195,167,54,49,123,56,119,125,22,239,191,189,112,78,239,191,189,239,191,189,216,155,239,191,189,239,191,189,63,239,191,189,239,191,189,204,149,36,239,191,189,1,120,239,191,189,239,191,189,99,239,191,189,239,191,189,203,151,127,239,191,189,100,93,116,17,239,191,189,48,62,239,191,189,122,239,191,189,88,239,191,189,239,191,189,99,67,239,191,189,239,191,189,239,191,189,17,17,55,122,239,191,189,239,191,189,239,191,189,15,239,191,189,99,21,87,54,239,191,189,97,46,239,191,189,239,191,189,239,191,189,202,169,5,76,204,158,239,191,189,239,191,189,67,66,53,10,239,191,189,111,83,37,239,191,189,82,86,68,239,191,189,239,191,189,239,191,189,113,80,239,191,189,1,239,191,189,51,1,21,239,191,189,239,191,189,103,71,103,49,45,239,191,189,239,191,189,65,16,203,168,77,89,239,191,189,239,191,189,239,191,189,102,104,239,191,189,93,108,3,14,25,239,191,189,239,191,189,53,239,191,189,239,191,189,110,65,45,82,47,33,40,239,191,189,239,191,189,239,191,189,94,116,3,121,239,191,189,239,191,189,35,239,191,189,11,26,239,191,189,205,153,57,239,191,189,110,100,57,78,239,191,189,49,239,191,189,68,71,239,191,189,239,191,189,122,239,191,189,41,106,239,191,189,239,191,189,115,239,191,189,125,239,191,189,105,239,191,189,30,49,112,5,41,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,86,239,191,189,239,191,189,47,239,191,189,239,191,189,101,109,40,205,160,91,239,191,189,89,239,191,189,239,191,189,239,191,189,5,239,191,189,26,28,44,43,239,191,189,239,191,189,26,0,239,191,189,45,104,239,191,189,239,191,189,91,28,1,220,185,239,191,189,239,191,189,239,191,189,239,191,189,72,55,239,191,189,39,88,71,239,191,189,55,49,239,191,189,239,191,189,212,128,42,111,12,108,239,191,189,216,132,239,191,189,239,191,189,100,239,191,189,121,61,239,191,189,239,191,189,239,191,189,88,40,97,88,239,191,189,239,191,189,10,239,191,189,239,191,189,239,191,189,54,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,76,10,239,191,189,53,239,191,189,77,210,151,239,191,189,239,191,189,10,239,191,189,88,78,98,239,191,189,114,40,70,122,1,239,191,189,239,191,189,31,77,239,191,189,239,191,189,239,191,189,38,239,191,189,239,191,189,74,105,14,239,191,189,77,79,44,121,239,191,189,33,115,239,191,189,227,173,135,239,191,189,239,191,189,75,18,239,191,189,239,191,189,239,191,189,23,239,191,189,122,42,239,191,189,239,191,189,71,79,27,112,13,63,239,191,189,69,73,239,191,189,20,105,70,239,191,189,239,191,189,89,239,191,189,239,191,189,239,191,189,114,198,159,79,107,20,5,239,191,189,82,63,27,35,239,191,189,68,50,71,6,3,239,191,189,239,191,189,65,239,191,189,239,191,189,54,239,191,189,66,3,239,191,189,239,191,189,65,239,191,189,45,71,33,239,191,189,239,191,189,239,191,189,91,8,83,33,239,191,189,9,239,191,189,239,191,189,239,191,189,1,123,104,83,239,191,189,239,191,189,90,239,191,189,239,191,189,239,191,189,88,52,108,239,191,189,233,161,147,239,191,189,115,239,191,189,78,35,239,191,189,71,85,239,191,189,239,191,189,79,239,191,189,78,239,191,189,91,68,239,191,189,65,239,191,189,239,191,189,107,239,191,189,239,191,189,239,191,189,194,156,239,191,189,239,191,189,123,239,191,189,70,106,127,95,11,40,239,191,189,239,191,189,239,191,189,239,191,189,32,239,191,189,239,191,189,239,191,189,10,239,191,189,54,76,239,191,189,239,152,129,97,12,40,71,239,191,189,34,239,191,189,239,191,189,212,161,218,183,239,191,189,239,191,189,77,239,191,189,50,73,79,99,239,191,189,116,110,239,191,189,239,191,189,239,191,189,11,101,105,239,191,189,239,191,189,87,239,191,189,8,114,55,239,191,189,124,239,191,189,239,191,189,86,28,126,34,44,87,36,105,72,239,191,189,202,166,73,30,203,152,239,191,189,116,239,191,189,90,239,191,189,34,107,239,191,189,79,96,239,191,189,239,191,189,219,183,213,181,112,86,12,122,239,191,189,75,239,191,189,119,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,14,239,191,189,61,239,191,189,125,78,239,191,189,126,120,52,239,191,189,239,191,189,239,191,189,239,191,189,122,71,239,191,189,239,191,189,239,191,189,21,54,239,191,189,17,80,239,191,189,110,239,191,189,102,239,191,189,239,191,189,4,239,191,189,24,106,82,54,239,191,189,1,58,239,191,189,22,239,191,189,239,191,189,239,191,189,239,191,189,110,119,239,191,189,239,191,189,92,19,239,191,189,239,191,189,201,173,27,239,191,189,239,191,189,56,14,239,191,189,57,199,153,47,239,191,189,111,105,121,68,239,191,189,239,191,189,86,86,239,191,189,69,21,56,239,191,189,52,239,191,189,239,191,189,105,89,239,191,189,120,239,191,189,78,239,191,189,55,239,191,189,239,191,189,239,191,189,43,6,239,191,189,41,67,239,191,189,239,191,189,239,191,189,14,97,239,191,189,239,191,189,239,191,189,53,239,191,189,239,191,189,104,5,93,100,3,23,239,191,189,239,191,189,110,207,183,30,33,239,191,189,66,239,191,189,239,191,189,239,191,189,42,79,33,27,209,143,239,191,189,53,232,145,176,239,191,189,67,66,90,239,191,189,84,49,66,79,239,191,189,20,121,12,239,191,189,116,239,191,189,239,191,189,98,30,21,239,191,189,239,191,189,11,51,239,191,189,76,51,206,170,239,191,189,46,239,191,189,32,202,139,117,195,158,87,17,97,239,191,189,239,191,189,21,239,191,189,21,96,93,239,191,189,11,88,239,191,189,114,239,191,189,239,191,189,55,39,239,191,189,7,239,191,189,116,239,191,189,239,191,189,239,191,189,125,239,191,189,239,191,189,239,191,189,124,239,191,189,63,11,13,239,191,189,31,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,49,239,191,189,118,239,191,189,239,191,189,239,191,189,239,191,189,9,62,239,191,189,239,191,189,79,19,239,191,189,239,191,189,8,47,88,40,111,116,32,32,25,123,100,239,191,189,239,191,189,239,191,189,65,239,191,189,70,27,39,66,6,239,191,189,62,239,191,189,103,6,239,191,189,62,78,123,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,4,107,125,98,16,127,93,44,37,239,191,189,40,75,239,191,189,239,191,189,126,51,239,191,189,239,191,189,239,191,189,239,191,189,101,239,191,189,104,239,191,189,239,191,189,209,158,239,191,189,105,31,239,191,189,3,123,239,191,189,218,158,239,191,189,50,239,191,189,35,18,239,191,189,239,191,189,221,147,66,124,239,191,189,239,191,189,14,28,41,50,213,159,239,191,189,20,239,191,189,46,239,191,189,239,191,189,109,239,191,189,126,239,191,189,72,239,191,189,12,239,191,189,239,191,189,38,119,113,101,221,151,239,191,189,239,191,189,0,239,191,189,84,239,191,189,55,91,2,118,209,165,38,47,239,191,189,239,191,189,3,239,191,189,100,239,191,189,18,74,84,75,239,191,189,112,89,239,191,189,232,165,184,239,191,189,239,191,189,7,239,191,189,239,191,189,205,142,89,29,53,96,123,18,119,239,191,189,239,191,189,116,11,47,116,239,191,189,1,56,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,72,69,114,93,239,191,189,4,239,191,189,30,123,1,42,116,127,70,111,239,191,189,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,49,32,203,191,239,191,189,6,82,24,239,191,189,116,239,191,189,239,191,189,239,191,189,29,84,114,45,239,191,189,239,191,189,10,4,239,191,189,23,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,90,99,95,239,191,189,44,239,191,189,56,239,191,189,117,239,191,189,17,239,191,189,11,112,126,196,177,239,191,189,97,239,191,189,239,191,189,239,191,189,219,180,49,8,16,239,191,189,239,191,189,41,92,55,239,191,189,25,114,239,191,189,52,239,191,189,57,63,45,239,191,189,91,239,191,189,59,12,74,74,13,44,8,126,62,239,191,189,119,239,191,189,4,239,191,189,239,191,189,40,239,191,189,239,191,189,76,82,239,191,189,11,239,191,189,239,191,189,239,191,189,239,191,189,53,39,121,239,191,189,104,127,239,191,189,239,191,189,239,191,189,197,171,239,191,189,239,191,189,84,239,191,189,121,239,191,189,239,191,189,14,47,239,191,189,34,17,71,67,55,9,24,47,26,77,93,124,107,239,191,189,86,239,191,189,4,15,3,66,5,239,191,189,98,76,69,79,239,191,189,33,239,191,189,113,3,239,191,189,96,239,191,189,19,22,50,81,48,118,239,191,189,239,191,189,239,191,189,120,78,39,239,191,189,239,191,189,98,239,191,189,123,239,191,189,10,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,239,191,189,239,191,189,73,126,28,239,191,189,239,191,189,64,239,191,189,239,191,189,222,140,239,191,189,62,239,191,189,239,191,189,239,191,189,30,239,191,189,125,239,191,189,239,191,189,239,191,189,24,239,191,189,115,217,137,103,55,83,72,107,239,191,189,41,55,46,239,191,189,11,239,191,189,239,191,189,33,33,239,191,189,12,125,82,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,41,239,191,189,56,239,191,189,239,191,189,49,239,191,189,239,191,189,239,191,189,54,239,191,189,91,95,239,191,189,33,239,191,189,21,239,191,189,239,191,189,46,19,206,187,239,191,189,239,191,189,45,12,86,33,40,239,191,189,239,191,189,58,117,30,239,191,189,120,105,239,191,189,239,191,189,37,98,39,239,191,189,72,239,191,189,104,118,91,106,239,191,189,81,8,239,191,189,239,191,189,90,210,155,2,239,191,189,37,82,239,191,189,239,191,189,126,54,32,239,191,189,119,68,112,239,191,189,239,191,189,239,191,189,8,239,191,189,239,191,189,48,84,239,191,189,197,150,239,191,189,239,191,189,239,191,189,102,239,191,189,108,239,191,189,239,191,189,11,239,191,189,102,239,191,189,239,191,189,239,191,189,219,136,12,17,239,191,189,125,239,191,189,23,239,191,189,239,191,189,84,74,239,191,189,26,239,191,189,239,191,189,71,13,239,191,189,239,191,189,87,239,191,189,18,23,239,191,189,239,191,189,64,239,191,189,57,239,191,189,69,239,191,189,239,191,189,53,239,191,189,29,36,66,79,71,239,191,189,227,189,157,18,80,239,191,189,239,191,189,16,106,239,191,189,89,60,73,123,11,118,239,191,189,118,239,191,189,61,75,239,191,189,101,239,191,189,84,99,239,191,189,69,239,191,189,124,4,239,191,189,121,239,191,189,116,18,116,4,75,12,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,195,156,239,191,189,201,167,46,239,191,189,92,10,75,4,87,239,191,189,239,191,189,22,74,121,237,145,155,239,191,189,81,6,239,191,189,2,239,191,189,42,229,139,168,15,103,239,191,189,239,191,189,239,191,189,239,191,189,123,239,191,189,78,55,98,111,239,191,189,111,239,191,189,239,191,189,70,94,239,191,189,103,41,239,191,189,109,80,0,74,239,191,189,209,164,61,239,191,189,118,127,239,191,189,239,191,189,239,191,189,53,45,37,64,206,139,239,191,189,90,56,83,239,191,189,239,191,189,61,239,191,189,239,191,189,239,191,189,239,191,189,35,127,45,239,191,189,109,239,191,189,124,34,239,191,189,74,16,239,191,189,239,191,189,239,191,189,9,122,239,191,189,76,24,57,239,191,189,239,191,189,239,191,189,67,19,24,239,191,189,239,191,189,29,239,191,189,36,239,191,189,214,134,91,34,239,191,189,239,191,189,199,157,239,191,189,29,36,64,239,191,189,239,191,189,76,99,239,191,189,27,116,52,239,191,189,239,191,189,56,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,4,22,37,125,239,191,189,101,239,191,189,239,191,189,210,132,123,239,191,189,239,191,189,116,93,239,191,189,78,239,191,189,73,9,1,31,239,191,189,1,67,78,239,191,189,65,239,191,189,16,114,239,191,189,239,191,189,25,13,27,17,6,239,191,189,207,181,105,239,191,189,239,191,189,22,1,239,191,189,22,239,191,189,53,239,191,189,239,191,189,239,191,189,239,191,189,3,239,191,189,54,123,122,23,196,165,239,191,189,239,191,189,18,239,191,189,239,191,189,127,102,66,239,191,189,71,239,191,189,122,84,239,191,189,126,63,239,191,189,66,239,191,189,239,191,189,239,191,189,239,191,189,119,239,191,189,32,3,21,22,228,149,139,239,191,189,10,15,239,191,189,222,157,85,65,32,239,191,189,66,239,191,189,80,239,191,189,31,121,107,121,239,191,189,239,191,189,56,105,11,239,191,189,44,75,41,239,191,189,239,191,189,105,79,93,13,239,191,189,19,111,68,3,239,191,189,239,191,189,239,191,189,1,239,191,189,8,122,23,38,66,1,239,191,189,239,191,189,239,191,189,239,191,189,6,83,102,239,191,189,39,104,239,191,189,115,239,191,189,239,191,189,239,191,189,97,229,131,148,239,191,189,239,191,189,52,103,239,191,189,85,239,191,189,54,239,191,189,2,110,20,36,239,191,189,50,239,191,189,239,191,189,111,7,105,239,191,189,112,29,239,191,189,12,45,239,191,189,124,213,167,239,191,189,239,191,189,239,191,189,239,191,189,81,85,67,195,152,12,28,239,191,189,239,191,189,239,191,189,83,110,239,191,189,22,83,239,191,189,239,191,189,117,123,43,239,191,189,63,22,239,191,189,239,191,189,39,24,239,191,189,6,90,217,128,239,191,189,54,77,239,191,189,124,239,191,189,239,191,189,239,191,189,76,35,115,100,71,239,191,189,239,191,189,239,191,189,41,239,191,189,239,191,189,31,24,102,239,191,189,17,63,119,239,191,189,112,239,191,189,97,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,118,123,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,204,177,239,191,189,48,239,191,189,79,239,191,189,40,98,239,191,189,103,44,106,59,239,191,189,4,239,191,189,102,6,239,191,189,208,133,116,239,191,189,75,0,239,191,189,98,55,239,191,189,239,191,189,239,191,189,10,69,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,91,64,37,108,239,191,189,239,191,189,239,191,189,119,239,191,189,55,122,239,191,189,33,239,191,189,44,15,111,59,79,239,191,189,239,191,189,42,56,207,163,96,239,191,189,15,16,49,123,98,26,68,239,191,189,95,7,16,96,114,239,191,189,239,191,189,110,73,29,239,191,189,239,191,189,73,96,239,191,189,87,239,191,189,85,239,191,189,21,239,191,189,12,239,191,189,239,191,189,239,191,189,102,239,191,189,239,191,189,24,239,191,189,239,191,189,106,239,191,189,7,94,239,191,189,239,191,189,6,217,187,239,191,189,14,119,239,191,189,239,191,189,43,239,191,189,239,191,189,12,41,239,191,189,123,113,107,4,239,191,189,239,191,189,15,239,191,189,214,141,5,239,191,189,12,223,147,239,191,189,239,191,189,239,191,189,120,239,191,189,89,239,191,189,239,191,189,239,191,189,19,239,191,189,26,59,239,191,189,239,191,189,11,239,191,189,46,239,191,189,91,239,191,189,90,5,1,239,191,189,84,239,191,189,97,239,191,189,82,107,239,191,189,27,78,239,191,189,239,191,189,239,191,189,62,239,191,189,33,114,239,191,189,6,239,191,189,239,191,189,239,191,189,73,24,239,191,189,239,191,189,14,239,191,189,239,191,189,56,64,239,191,189,239,191,189,118,239,191,189,103,116,239,191,189,61,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,239,191,189,119,112,60,239,191,189,239,191,189,26,83,67,18,2,11,239,191,189,196,179,67,239,191,189,239,191,189,239,191,189,13,66,41,28,73,239,191,189,239,191,189,239,191,189,68,90,25,239,191,189,239,191,189,93,58,239,191,189,239,191,189,239,191,189,239,191,189,33,80,38,74,239,191,189,100,239,191,189,91,239,191,189,216,137,103,26,64,27,222,154,239,191,189,91,38,239,191,189,33,18,239,191,189,239,191,189,41,63,12,239,191,189,239,191,189,30,49,239,191,189,236,188,147,239,191,189,239,191,189,239,191,189,239,191,189,87,47,6,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,38,118,239,191,189,0,61,80,82,97,36,239,191,189,20,239,191,189,88,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,46,239,191,189,206,130,27,21,27,5,42,239,191,189,49,46,239,191,189,69,10,47,239,191,189,239,191,189,85,239,191,189,239,191,189,61,239,191,189,114,239,191,189,239,191,189,66,97,50,239,191,189,14,82,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,109,239,191,189,40,52,76,54,119,239,191,189,127,33,116,78,239,191,189,49,239,191,189,50,96,239,191,189,239,191,189,16,92,1,40,210,186,239,191,189,89,239,191,189,223,167,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,45,98,88,7,27,239,191,189,1,239,191,189,239,191,189,18,239,191,189,239,191,189,70,32,39,239,191,189,239,191,189,115,75,108,239,191,189,85,122,121,239,191,189,239,191,189,239,191,189,239,191,189,43,239,191,189,239,191,189,10,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,88,5,239,191,189,51,239,191,189,89,239,191,189,127,239,191,189,239,191,189,18,60,34,26,239,191,189,239,191,189,239,191,189,42,68,239,191,189,41,239,191,189,239,191,189,74,239,191,189,239,191,189,85,27,41,90,239,191,189,127,239,191,189,109,100,80,239,191,189,70,35,125,21,88,52,239,191,189,239,191,189,205,128,239,191,189,45,22,197,190,239,191,189,239,191,189,213,178,16,92,239,191,189,239,191,189,4,239,191,189,86,239,191,189,18,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,20,239,191,189,6,239,191,189,239,191,189,239,191,189,112,239,191,189,239,191,189,239,191,189,125,126,239,191,189,18,239,191,189,17,239,191,189,239,191,189,239,191,189,239,191,189,64,118,239,191,189,103,120,113,1,239,191,189,239,191,189,33,61,239,191,189,31,239,191,189,2,43,239,191,189,239,191,189,239,191,189,4,66,17,239,191,189,239,191,189,62,239,191,189,239,191,189,67,7,1,196,152,30,5,71,239,191,189,239,191,189,77,98,239,191,189,239,191,189,27,115,239,191,189,239,191,189,95,72,16,105,89,239,191,189,23,239,191,189,110,47,239,191,189,239,191,189,40,243,187,189,145,239,191,189,93,239,191,189,239,191,189,26,94,100,58,24,239,191,189,125,52,106,239,191,189,84,74,239,191,189,38,109,51,239,191,189,239,191,189,222,128,239,191,189,239,191,189,24,239,191,189,28,118,90,239,191,189,18,70,57,21,239,191,189,4,69,239,191,189,46,64,74,239,191,189,93,4,57,90,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,57,127,36,33,239,191,189,70,118,30,239,191,189,65,239,191,189,34,35,239,191,189,63,100,239,191,189,225,131,136,111,103,239,191,189,239,191,189,45,239,191,189,222,148,239,191,189,217,141,89,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,52,16,239,191,189,9,239,191,189,59,239,191,189,125,26,36,19,239,191,189,239,191,189,1,239,191,189,239,191,189,239,191,189,61,239,191,189,239,191,189,103,239,191,189,200,179,124,239,191,189,208,188,239,191,189,239,191,189,239,191,189,31,239,191,189,83,95,201,138,35,239,191,189,97,121,109,198,162,239,191,189,239,191,189,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,60,83,239,191,189,239,191,189,86,71,239,191,189,15,239,191,189,113,239,191,189,110,239,191,189,239,191,189,36,8,96,26,2,62,5,103,29,2,16,239,191,189,18,0,239,191,189,239,191,189,32,239,191,189,78,239,191,189,0,239,191,189,239,191,189,52,239,191,189,79,239,191,189,239,191,189,8,239,191,189,87,213,162,217,171,36,75,105,239,191,189,55,239,191,189,103,239,191,189,69,88,239,191,189,15,50,115,95,239,191,189,126,74,239,191,189,73,19,43,61,239,191,189,239,191,189,100,95,48,239,191,189,58,76,57,84,105,239,191,189,239,191,189,201,188,106,20,115,34,239,191,189,239,191,189,239,191,189,110,239,191,189,239,191,189,239,191,189,87,88,43,98,17,31,43,57,239,191,189,210,140,54,39,10,12,86,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,223,153,239,191,189,239,191,189,60,239,191,189,239,191,189,10,239,191,189,202,163,11,239,191,189,239,191,189,14,239,191,189,88,239,191,189,239,191,189,239,191,189,198,151,239,191,189,60,239,191,189,239,191,189,119,105,215,166,239,191,189,229,176,149,120,239,191,189,239,191,189,31,239,191,189,112,71,239,191,189,239,191,189,194,147,27,39,23,72,239,191,189,111,45,27,95,239,191,189,71,17,239,191,189,239,191,189,87,66,239,191,189,50,79,239,191,189,239,191,189,91,78,123,123,100,57,239,191,189,27,72,219,187,197,169,223,189,95,33,13,55,239,191,189,239,191,189,81,239,191,189,49,239,191,189,239,191,189,41,239,191,189,46,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,156,239,191,189,101,53,126,0,22,31,239,191,189,75,239,191,189,22,239,191,189,239,191,189,102,36,24,79,239,191,189,10,239,191,189,74,239,191,189,112,16,34,239,191,189,35,46,239,191,189,239,191,189,31,239,191,189,239,191,189,85,239,191,189,1,39,239,191,189,58,122,239,191,189,53,4,18,239,191,189,74,87,239,191,189,116,125,239,191,189,36,82,239,191,189,239,191,189,37,92,18,239,191,189,239,191,189,93,82,28,239,191,189,239,191,189,32,17,124,23,39,43,239,191,189,57,239,191,189,239,191,189,107,239,191,189,48,239,191,189,49,239,191,189,239,191,189,123,239,191,189,105,239,191,189,112,239,191,189,239,191,189,239,191,189,203,182,239,191,189,126,72,239,191,189,239,191,189,26,60,42,70,23,92,85,239,191,189,239,191,189,239,191,189,11,239,191,189,39,44,112,91,108,239,191,189,239,191,189,42,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,60,92,117,34,239,191,189,92,239,191,189,239,191,189,239,191,189,120,239,191,189,120,93,38,60,239,191,189,239,191,189,239,191,189,121,42,239,191,189,239,191,189,69,81,17,239,191,189,12,239,191,189,239,191,189,69,122,239,191,189,78,32,239,191,189,64,239,191,189,46,81,40,5,68,56,239,191,189,112,239,191,189,69,239,191,189,239,191,189,9,33,239,191,189,18,239,191,189,239,191,189,239,191,189,47,209,169,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,48,41,60,46,239,191,189,239,191,189,239,191,189,113,80,36,110,102,77,239,191,189,30,96,93,208,131,36,239,191,189,239,191,189,239,191,189,239,191,189,58,16,239,191,189,83,64,239,191,189,239,191,189,64,239,191,189,8,239,191,189,239,191,189,73,124,122,239,191,189,121,26,87,239,191,189,239,191,189,86,120,239,191,189,210,137,110,239,191,189,120,239,191,189,239,191,189,239,191,189,239,191,189,32,239,191,189,239,191,189,239,191,189,127,239,191,189,82,239,191,189,83,88,239,191,189,239,191,189,58,239,191,189,19,239,191,189,55,126,239,191,189,47,239,191,189,239,191,189,67,239,191,189,76,28,0,239,191,189,239,191,189,81,99,239,191,189,5,121,91,239,191,189,196,150,239,191,189,123,239,191,189,81,56,239,191,189,239,191,189,20,239,191,189,239,191,189,91,239,191,189,65,38,17,239,191,189,239,191,189,39,239,191,189,35,239,191,189,99,239,191,189,239,191,189,239,191,189,2,239,191,189,78,239,191,189,239,191,189,76,112,33,239,191,189,239,191,189,103,239,191,189,239,191,189,239,191,189,68,62,55,239,191,189,31,48,22,15,60,124,72,239,191,189,51,13,239,191,189,239,191,189,54,239,191,189,239,191,189,106,53,10,77,57,215,148,234,128,160,67,239,191,189,28,34,102,80,239,191,189,95,223,187,239,191,189,239,191,189,239,191,189,210,146,23,24,98,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,67,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,70,239,191,189,111,239,191,189,239,191,189,43,239,191,189,205,189,239,191,189,239,191,189,87,239,191,189,51,239,191,189,66,81,123,239,191,189,239,191,189,123,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,69,239,191,189,239,191,189,22,239,191,189,98,51,48,79,57,239,191,189,239,191,189,0,102,239,191,189,75,239,191,189,239,191,189,3,85,225,163,168,72,239,191,189,117,86,239,191,189,14,239,191,189,239,191,189,112,98,239,191,189,239,191,189,239,191,189,239,191,189,60,36,239,191,189,239,191,189,97,239,191,189,239,191,189,122,65,48,48,239,191,189,58,239,191,189,65,2,239,191,189,54,239,191,189,45,126,11,71,33,239,191,189,239,191,189,18,93,17,239,191,189,239,191,189,88,239,191,189,239,191,189,239,191,189,49,45,239,191,189,71,239,191,189,87,239,191,189,21,239,191,189,239,191,189,239,191,189,92,118,32,239,191,189,67,113,96,120,73,48,220,146,84,239,191,189,239,191,189,52,104,239,191,189,73,239,191,189,239,191,189,62,51,16,239,191,189,239,191,189,239,191,189,8,214,132,239,191,189,239,191,189,67,239,191,189,69,239,191,189,60,37,61,117,239,191,189,239,191,189,239,191,189,239,191,189,84,239,191,189,106,239,191,189,239,191,189,35,239,191,189,84,113,6,239,191,189,30,66,16,23,94,239,191,189,88,239,191,189,239,191,189,58,79,78,239,191,189,121,15,239,191,189,67,239,191,189,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,57,122,103,43,239,191,189,239,191,189,27,60,239,191,189,38,90,44,13,239,191,189,239,191,189,239,191,189,239,191,189,92,5,76,239,191,189,14,239,191,189,43,78,209,158,38,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,27,45,239,191,189,210,152,52,18,239,191,189,83,239,191,189,239,191,189,53,239,191,189,239,191,189,64,119,239,191,189,64,239,191,189,239,191,189,88,93,239,191,189,239,191,189,239,191,189,125,22,29,239,191,189,239,191,189,239,191,189,47,239,191,189,239,191,189,114,239,191,189,27,239,191,189,239,191,189,58,239,191,189,25,96,24,45,239,191,189,239,191,189,38,239,191,189,100,239,191,189,239,191,189,52,239,191,189,239,191,189,103,47,200,183,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,8,206,129,239,191,189,124,239,191,189,202,157,68,39,239,191,189,239,191,189,239,191,189,48,239,191,189,239,191,189,80,55,62,239,191,189,21,239,191,189,239,191,189,239,191,189,239,191,189,25,62,28,239,191,189,25,107,18,239,191,189,239,191,189,23,239,191,189,118,239,191,189,61,105,37,239,191,189,64,239,191,189,37,239,191,189,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,44,239,191,189,239,191,189,117,239,191,189,239,191,189,42,239,191,189,119,29,10,25,82,37,104,126,1,92,239,191,189,22,78,71,239,191,189,33,114,75,239,191,189,105,239,191,189,75,239,191,189,239,191,189,239,191,189,239,191,189,103,239,191,189,200,187,239,191,189,97,239,191,189,44,7,239,191,189,127,0,70,62,197,135,3,22,239,191,189,76,239,191,189,239,191,189,2,99,239,191,189,239,191,189,11,44,124,73,46,239,191,189,67,1,239,191,189,57,239,191,189,109,239,191,189,239,191,189,26,239,191,189,52,239,191,189,239,191,189,239,191,189,35,113,239,191,189,26,239,191,189,239,191,189,15,239,191,189,239,191,189,68,239,191,189,88,239,191,189,239,191,189,121,0,239,191,189,239,191,189,239,191,189,223,188,68,239,191,189,239,191,189,239,191,189,97,239,191,189,50,239,191,189,116,65,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,90,239,191,189,239,191,189,68,75,115,72,239,191,189,20,80,26,67,239,191,189,61,239,191,189,24,239,191,189,239,191,189,239,191,189,52,39,114,53,98,239,191,189,207,131,239,191,189,239,191,189,3,239,191,189,90,40,24,40,78,14,239,191,189,98,24,239,191,189,239,191,189,76,239,191,189,24,239,191,189,239,191,189,4,239,191,189,239,191,189,215,173,46,100,239,191,189,90,75,99,124,239,191,189,239,191,189,17,113,239,191,189,26,120,20,239,191,189,9,239,191,189,96,239,191,189,73,37,239,191,189,74,72,239,191,189,126,23,239,191,189,68,6,239,191,189,239,191,189,239,191,189,65,239,191,189,194,156,239,191,189,40,22,239,191,189,59,22,88,126,106,239,191,189,11,239,191,189,239,191,189,119,205,151,27,239,191,189,239,191,189,0,26,239,191,189,113,112,31,239,191,189,107,18,31,239,191,189,211,170,71,66,123,239,191,189,239,191,189,102,239,191,189,239,191,189,202,128,239,191,189,11,6,99,239,191,189,239,191,189,99,239,191,189,127,69,239,191,189,239,191,189,84,239,191,189,239,191,189,239,191,189,110,239,191,189,70,94,239,191,189,28,97,239,191,189,239,191,189,239,191,189,21,23,239,191,189,239,191,189,23,14,79,16,239,191,189,100,25,105,239,191,189,50,239,191,189,44,83,100,239,191,189,239,191,189,38,239,191,189,218,163,124,239,191,189,108,239,191,189,114,239,191,189,119,197,147,239,191,189,75,239,191,189,46,239,191,189,49,68,239,191,189,65,239,191,189,4,239,191,189,20,239,191,189,120,239,191,189,239,191,189,9,239,191,189,239,191,189,22,60,17,90,44,98,239,191,189,53,112,239,191,189,239,191,189,239,191,189,71,103,112,73,239,191,189,53,210,143,239,191,189,41,239,191,189,239,191,189,119,26,239,191,189,239,191,189,98,239,191,189,239,191,189,109,232,189,179,15,239,191,189,78,1,80,78,14,101,239,191,189,7,97,239,191,189,239,191,189,48,47,31,239,191,189,54,78,239,191,189,239,191,189,24,239,191,189,17,239,191,189,24,239,191,189,239,191,189,13,52,239,191,189,239,191,189,239,191,189,97,119,91,51,239,191,189,64,239,191,189,239,191,189,17,239,191,189,21,239,191,189,239,191,189,50,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,106,239,191,189,106,239,191,189,53,59,239,191,189,122,211,167,239,191,189,239,191,189,207,183,195,146,239,191,189,13,32,40,239,191,189,38,239,191,189,127,239,191,189,126,239,191,189,63,38,239,191,189,32,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,67,239,191,189,11,239,191,189,38,239,191,189,29,110,239,191,189,239,191,189,239,191,189,123,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,216,147,239,191,189,112,239,191,189,239,191,189,239,191,189,94,83,213,134,62,11,239,191,189,239,191,189,239,191,189,78,239,191,189,1,239,191,189,1,239,191,189,8,95,239,191,189,239,191,189,37,121,239,191,189,123,239,191,189,21,78,30,42,84,239,191,189,89,84,239,191,189,239,191,189,67,72,239,191,189,84,239,191,189,239,191,189,239,191,189,4,203,139,33,239,191,189,221,138,61,239,191,189,239,191,189,3,118,239,191,189,89,239,191,189,41,239,191,189,239,191,189,239,191,189,126,123,93,239,191,189,239,191,189,56,239,191,189,239,191,189,119,239,191,189,6,239,191,189,239,191,189,239,191,189,205,175,7,239,191,189,65,239,191,189,22,78,239,191,189,80,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,43,41,57,239,191,189,116,239,191,189,110,221,149,100,38,239,191,189,239,191,189,239,191,189,66,239,191,189,93,239,191,189,239,191,189,239,191,189,53,12,120,47,103,44,239,191,189,92,5,85,239,191,189,210,131,107,220,135,239,191,189,18,68,65,41,94,76,27,239,191,189,80,96,239,191,189,13,239,191,189,239,191,189,15,68,6,239,191,189,29,239,191,189,239,191,189,12,92,239,191,189,239,191,189,239,191,189,15,49,239,191,189,66,239,191,189,211,187,239,191,189,75,111,105,239,191,189,239,191,189,239,191,189,92,88,23,239,191,189,239,191,189,79,81,239,191,189,239,191,189,125,117,239,191,189,239,191,189,112,5,231,140,168,239,191,189,60,239,191,189,239,191,189,13,239,191,189,31,82,239,191,189,58,239,191,189,239,191,189,67,31,93,100,42,239,191,189,239,191,189,239,191,189,49,61,63,76,105,239,191,189,12,20,239,191,189,111,70,239,191,189,239,191,189,27,6,239,191,189,115,120,10,239,191,189,239,191,189,124,239,191,189,68,239,191,189,57,85,97,98,70,16,86,239,191,189,118,239,191,189,239,191,189,239,191,189,118,72,239,191,189,11,93,101,239,191,189,24,239,191,189,40,25,239,191,189,239,191,189,239,191,189,68,53,239,191,189,239,191,189,8,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,41,53,49,59,239,191,189,117,239,191,189,239,191,189,2,239,191,189,26,239,191,189,239,191,189,23,239,191,189,44,239,191,189,17,60,239,191,189,113,239,191,189,37,239,191,189,91,65,239,191,189,82,239,191,189,239,191,189,239,191,189,27,89,239,191,189,60,239,191,189,239,191,189,195,131,239,191,189,82,25,239,191,189,41,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,2,122,122,41,33,239,191,189,16,126,239,191,189,99,239,191,189,52,66,67,5,239,191,189,66,239,191,189,239,191,189,239,191,189,69,239,191,189,239,191,189,53,88,239,191,189,239,191,189,41,239,191,189,239,191,189,37,73,239,191,189,239,191,189,65,239,191,189,47,239,191,189,239,191,189,239,191,189,104,239,191,189,32,239,191,189,30,239,191,189,106,35,239,191,189,101,239,191,189,239,191,189,38,239,191,189,17,239,191,189,239,191,189,239,191,189,201,173,19,85,44,239,191,189,126,235,138,133,239,191,189,94,19,43,50,53,239,191,189,13,108,239,191,189,22,239,191,189,123,216,160,77,239,191,189,86,34,35,239,191,189,84,239,191,189,59,239,191,189,239,191,189,239,191,189,19,239,191,189,104,239,191,189,51,76,239,191,189,95,42,82,239,191,189,239,191,189,239,191,189,3,239,191,189,72,239,191,189,71,49,58,239,191,189,239,191,189,239,191,189,40,239,191,189,102,239,191,189,111,239,191,189,239,191,189,75,55,239,191,189,239,191,189,87,4,24,239,191,189,53,239,191,189,121,117,239,191,189,84,239,191,189,50,107,239,191,189,239,191,189,117,94,239,191,189,239,191,189,94,94,215,155,87,107,239,191,189,12,239,191,189,122,74,100,84,239,191,189,124,48,239,191,189,18,239,191,189,239,191,189,62,239,191,189,120,111,239,191,189,239,191,189,48,239,191,189,42,121,239,191,189,110,60,108,127,104,239,191,189,120,79,239,191,189,239,191,189,239,191,189,10,84,239,191,189,126,239,191,189,86,69,100,239,191,189,46,239,191,189,31,239,191,189,34,239,191,189,239,191,189,239,191,189,239,191,189,83,96,1,239,191,189,239,191,189,24,239,191,189,45,19,111,239,191,189,239,191,189,16,56,83,98,109,26,239,191,189,124,52,69,239,191,189,21,43,63,239,191,189,77,239,191,189,70,215,163,101,239,191,189,53,239,191,189,127,114,93,239,191,189,239,191,189,239,191,189,66,239,191,189,239,191,189,239,191,189,30,100,203,147,239,191,189,239,191,189,28,109,239,191,189,14,123,239,191,189,107,239,191,189,120,51,239,191,189,205,151,239,191,189,93,96,3,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,126,102,2,14,50,103,32,58,239,191,189,239,191,189,239,191,189,9,239,191,189,239,191,189,9,38,15,239,191,189,7,239,191,189,76,239,191,189,43,117,62,4,102,239,191,189,97,3,239,191,189,239,191,189,17,41,239,191,189,63,11,109,239,191,189,3,239,191,189,62,239,191,189,239,191,189,60,239,191,189,87,101,87,220,183,78,239,191,189,22,239,191,189,239,191,189,59,239,191,189,239,191,189,46,0,98,239,191,189,125,70,239,191,189,239,191,189,92,9,239,191,189,26,239,191,189,239,191,189,3,16,13,25,126,56,239,191,189,239,191,189,1,102,239,191,189,75,98,239,191,189,239,191,189,239,191,189,58,4,126,239,191,189,239,191,189,3,52,102,51,101,101,239,191,189,239,191,189,92,239,191,189,239,191,189,21,115,239,191,189,6,239,191,189,239,191,189,239,191,189,84,29,239,191,189,239,191,189,239,191,189,82,49,239,191,189,17,239,191,189,239,191,189,239,191,189,196,156,4,81,0,219,167,239,191,189,24,239,191,189,28,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,71,41,239,191,189,7,3,56,19,2,239,191,189,83,239,191,189,33,239,191,189,239,191,189,36,17,34,239,191,189,42,241,181,163,128,1,239,191,189,90,36,239,191,189,239,191,189,239,191,189,59,8,239,191,189,46,124,114,239,191,189,73,239,191,189,239,191,189,239,191,189,239,191,189,127,239,191,189,239,191,189,23,13,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,233,164,168,126,53,239,191,189,20,239,191,189,6,239,191,189,24,239,191,189,48,95,77,239,191,189,239,191,189,239,191,189,239,191,189,93,239,191,189,12,1,125,65,66,22,239,191,189,239,191,189,41,85,61,239,191,189,68,239,191,189,239,191,189,5,20,82,239,191,189,14,239,191,189,11,103,239,191,189,95,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,68,239,191,189,22,239,191,189,239,191,189,1,239,191,189,103,239,191,189,239,191,189,48,98,239,191,189,81,55,26,117,239,191,189,196,161,239,191,189,79,239,191,189,1,239,191,189,239,191,189,239,191,189,86,1,61,53,100,239,191,189,95,46,65,33,3,32,239,191,189,120,239,191,189,239,191,189,239,191,189,239,191,189,40,239,191,189,74,4,16,47,80,77,74,31,239,191,189,13,121,17,220,167,239,191,189,239,191,189,44,94,88,239,191,189,239,191,189,52,199,131,239,191,189,239,191,189,100,239,191,189,75,88,239,191,189,239,191,189,239,191,189,12,239,191,189,44,6,19,239,191,189,20,14,239,191,189,20,239,191,189,15,15,239,191,189,239,191,189,124,69,74,80,239,191,189,22,60,239,191,189,239,191,189,239,191,189,239,191,189,115,239,191,189,61,23,239,191,189,87,239,191,189,239,191,189,38,75,239,191,189,239,191,189,221,136,239,191,189,239,191,189,239,191,189,239,191,189,121,239,191,189,219,176,239,191,189,106,58,239,191,189,239,191,189,239,191,189,121,120,195,161,57,110,239,191,189,239,191,189,239,191,189,30,80,74,239,191,189,86,239,191,189,239,191,189,239,191,189,212,141,239,191,189,239,191,189,239,191,189,239,191,189,110,126,65,97,102,239,191,189,236,181,165,239,191,189,39,239,191,189,239,191,189,239,191,189,33,239,191,189,26,239,191,189,2,218,135,41,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,102,104,55,10,239,191,189,239,191,189,84,34,239,191,189,12,239,191,189,239,191,189,239,191,189,105,239,191,189,115,202,169,39,239,191,189,107,48,114,210,146,30,109,69,212,159,220,176,239,191,189,16,79,60,239,191,189,28,43,78,239,191,189,239,191,189,239,191,189,13,32,5,15,30,126,54,239,191,189,219,142,72,112,53,239,191,189,101,120,98,23,15,77,89,48,239,191,189,239,191,189,239,191,189,25,110,212,173,126,239,191,189,31,109,239,191,189,101,239,191,189,239,191,189,14,78,198,158,239,191,189,0,34,239,191,189,239,191,189,25,71,58,239,191,189,239,191,189,54,239,191,189,239,191,189,82,239,191,189,59,5,83,5,16,98,42,93,239,191,189,40,3,239,191,189,239,191,189,239,191,189,239,191,189,83,239,191,189,72,239,191,189,239,191,189,47,239,191,189,75,28,239,191,189,39,239,191,189,8,239,191,189,239,191,189,239,191,189,239,191,189,49,239,191,189,118,239,191,189,239,191,189,73,239,191,189,60,239,191,189,239,191,189,109,239,191,189,239,191,189,104,239,191,189,239,191,189,239,191,189,117,110,61,1,239,191,189,239,191,189,119,239,191,189,55,5,239,191,189,239,191,189,33,239,191,189,17,239,191,189,71,127,8,60,99,239,191,189,126,239,191,189,114,239,191,189,85,239,191,189,239,191,189,239,191,189,112,18,79,63,52,92,239,191,189,112,239,191,189,239,191,189,205,131,67,239,191,189,115,123,239,191,189,92,239,191,189,83,239,191,189,75,85,239,191,189,239,170,143,239,191,189,32,34,239,191,189,239,191,189,110,120,239,191,189,239,191,189,105,239,191,189,51,239,191,189,15,45,61,239,191,189,21,58,239,191,189,239,191,189,121,239,191,189,239,191,189,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,98,68,239,191,189,43,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,239,191,189,127,239,191,189,239,191,189,217,128,13,239,191,189,199,180,239,191,189,83,239,191,189,40,56,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,239,191,189,98,107,116,96,239,191,189,72,101,112,65,239,191,189,239,191,189,122,239,191,189,102,239,191,189,66,239,191,189,59,239,191,189,239,191,189,204,154,80,42,239,191,189,239,191,189,67,21,239,191,189,239,191,189,209,139,239,191,189,72,100,109,12,239,191,189,239,191,189,126,78,116,78,239,191,189,239,191,189,239,191,189,63,34,239,191,189,115,53,239,191,189,107,7,239,191,189,239,191,189,26,73,239,191,189,42,5,80,239,191,189,115,239,191,189,115,239,191,189,239,191,189,2,103,54,11,64,28,65,88,76,204,154,6,90,32,42,43,239,191,189,53,32,223,147,239,191,189,82,239,191,189,2,239,191,189,121,239,191,189,239,191,189,219,134,28,26,239,191,189,31,239,191,189,61,42,92,78,239,191,189,91,123,78,239,191,189,239,191,189,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,83,239,191,189,28,102,20,115,9,111,239,191,189,66,239,191,189,112,70,126,239,191,189,239,191,189,0,239,191,189,239,191,189,110,239,191,189,239,191,189,25,55,33,4,19,92,0,239,191,189,239,191,189,239,191,189,0,239,191,189,239,191,189,103,113,239,191,189,109,239,191,189,32,236,171,131,239,191,189,10,7,48,239,191,189,4,239,191,189,125,239,191,189,108,239,129,154,239,191,189,68,16,96,239,191,189,111,14,106,239,191,189,111,239,191,189,239,191,189,239,191,189,89,70,58,36,77,239,191,189,38,239,191,189,239,191,189,22,239,191,189,239,191,189,239,191,189,239,191,189,90,67,239,191,189,239,191,189,71,204,140,116,93,105,116,124,239,191,189,25,239,191,189,127,122,53,239,191,189,239,191,189,67,239,191,189,30,2,90,4,82,46,19,124,9,116,93,15,118,218,185,110,239,191,189,239,191,189,239,191,189,220,186,239,191,189,111,239,191,189,124,239,191,189,123,125,104,110,80,19,22,239,191,189,118,239,191,189,239,191,189,239,191,189,57,70,73,239,191,189,106,8,63,9,117,239,191,189,239,191,189,12,125,239,191,189,239,191,189,103,239,191,189,68,239,191,189,209,136,239,191,189,239,191,189,239,191,189,19,239,191,189,36,74,239,191,189,239,191,189,100,239,191,189,240,147,139,147,239,191,189,110,103,74,115,48,239,191,189,239,191,189,92,239,191,189,114,71,239,191,189,239,191,189,49,58,27,63,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,16,239,191,189,91,217,138,239,191,189,74,64,239,191,189,10,239,191,189,42,239,191,189,21,124,239,191,189,223,182,239,191,189,239,191,189,3,73,239,191,189,50,239,191,189,102,239,191,189,6,239,191,189,239,191,189,239,191,189,239,191,189,86,98,239,191,189,95,239,191,189,239,191,189,99,40,7,239,191,189,239,191,189,92,15,239,191,189,42,16,239,191,189,239,191,189,34,38,50,239,191,189,199,190,40,38,35,239,191,189,67,72,239,191,189,22,54,239,191,189,48,239,191,189,239,191,189,239,191,189,1,239,191,189,69,239,191,189,239,191,189,109,35,214,163,209,133,239,191,189,91,12,239,191,189,120,81,101,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,37,104,100,120,22,5,239,191,189,62,239,191,189,239,191,189,89,239,191,189,82,239,191,189,82,86,78,239,191,189,239,191,189,67,239,191,189,85,239,191,189,22,55,96,73,53,239,191,189,239,191,189,61,239,191,189,109,239,191,189,59,109,13,239,191,189,86,58,239,191,189,239,191,189,239,191,189,113,65,39,239,191,189,53,92,48,239,191,189,239,191,189,0,114,103,19,239,191,189,97,223,164,239,191,189,9,33,2,239,191,189,239,191,189,45,239,191,189,71,239,191,189,73,111,239,191,189,239,191,189,239,191,189,36,239,191,189,88,239,191,189,15,123,20,216,142,15,108,239,191,189,239,191,189,73,39,210,172,239,191,189,239,191,189,239,191,189,239,191,189,119,239,191,189,239,191,189,110,239,191,189,66,239,191,189,119,239,191,189,38,57,83,239,191,189,66,103,65,239,191,189,239,191,189,41,116,48,239,191,189,239,191,189,73,78,49,88,31,18,239,191,189,112,239,191,189,239,191,189,37,239,191,189,5,239,191,189,102,20,56,38,97,239,191,189,239,191,189,51,50,57,6,239,191,189,239,191,189,31,46,239,191,189,61,89,239,191,189,113,32,239,191,189,239,191,189,239,191,189,100,73,239,191,189,83,87,239,191,189,239,191,189,98,239,191,189,37,239,191,189,239,191,189,77,239,191,189,239,191,189,10,21,27,239,191,189,81,95,239,191,189,125,66,94,239,191,189,239,191,189,239,191,189,81,43,70,75,78,89,239,191,189,94,51,239,191,189,218,157,113,93,239,191,189,239,191,189,115,239,191,189,239,191,189,239,191,189,239,191,189,92,4,209,153,109,239,191,189,239,191,189,115,239,191,189,239,191,189,239,191,189,239,191,189,16,119,239,191,189,111,239,191,189,239,191,189,210,141,239,191,189,53,65,90,239,191,189,2,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,65,208,168,239,191,189,66,122,239,191,189,239,191,189,23,239,191,189,239,191,189,239,191,189,65,205,165,76,118,26,3,239,191,189,239,191,189,239,191,189,107,239,191,189,38,239,191,189,118,239,191,189,107,82,72,239,191,189,47,203,142,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,7,239,191,189,239,191,189,22,74,239,191,189,239,191,189,58,239,191,189,27,105,239,191,189,239,191,189,209,138,100,214,169,127,3,239,191,189,239,191,189,239,191,189,74,27,239,191,189,118,62,239,191,189,239,191,189,239,191,189,125,14,9,239,191,189,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,125,239,191,189,54,239,191,189,239,191,189,94,239,191,189,4,239,191,189,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,76,239,191,189,239,191,189,221,141,239,191,189,27,206,187,26,126,203,143,107,65,92,125,57,19,83,239,191,189,96,30,24,109,7,239,191,189,239,191,189,76,58,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,29,239,191,189,27,118,239,191,189,117,48,97,239,191,189,113,239,191,189,102,69,239,191,189,50,12,20,125,124,124,239,191,189,239,191,189,239,191,189,111,239,191,189,51,91,239,191,189,239,191,189,127,239,191,189,239,191,189,120,35,239,191,189,97,239,191,189,112,222,160,239,191,189,71,239,191,189,239,191,189,239,191,189,122,5,25,46,239,191,189,111,104,109,103,127,239,191,189,239,191,189,111,25,239,191,189,239,191,189,86,239,191,189,239,191,189,239,191,189,205,150,109,239,191,189,81,13,239,191,189,219,140,86,6,239,191,189,239,191,189,86,104,83,239,191,189,34,125,55,16,239,191,189,219,180,239,191,189,1,239,191,189,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,110,239,191,189,239,191,189,52,97,202,145,239,191,189,41,239,191,189,239,191,189,10,239,191,189,239,191,189,69,239,191,189,93,239,191,189,88,239,191,189,239,191,189,239,191,189,239,191,189,126,12,239,191,189,239,191,189,109,101,63,239,191,189,5,12,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,53,122,239,191,189,239,191,189,239,191,189,75,1,239,191,189,239,191,189,239,191,189,10,239,191,189,86,239,191,189,123,25,239,191,189,239,191,189,85,239,191,189,109,195,163,12,5,239,191,189,218,136,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,120,239,191,189,47,239,191,189,239,191,189,239,191,189,59,239,191,189,239,191,189,52,94,239,191,189,28,108,239,191,189,67,15,107,239,191,189,239,191,189,199,183,84,239,191,189,194,162,39,37,239,191,189,239,191,189,14,239,191,189,115,104,3,126,93,239,191,189,239,191,189,25,108,239,191,189,239,191,189,110,239,191,189,87,239,191,189,110,239,191,189,120,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,70,117,239,191,189,29,239,191,189,22,3,239,191,189,38,239,191,189,59,239,191,189,105,36,239,191,189,17,214,168,239,191,189,52,239,191,189,239,191,189,12,107,23,239,191,189,63,94,115,124,239,191,189,239,191,189,239,191,189,66,56,239,191,189,9,118,105,85,239,191,189,26,72,44,27,239,191,189,5,239,191,189,239,191,189,119,239,191,189,59,84,239,191,189,239,191,189,96,105,239,191,189,6,239,191,189,214,164,99,239,191,189,239,191,189,239,191,189,12,38,239,191,189,239,191,189,7,95,63,59,239,191,189,239,191,189,239,191,189,239,191,189,79,64,239,191,189,126,239,191,189,239,191,189,194,190,57,27,71,239,191,189,126,239,191,189,112,113,126,235,182,158,239,191,189,110,239,191,189,239,191,189,213,149,112,90,239,191,189,25,239,191,189,79,195,136,58,239,191,189,67,88,239,191,189,103,239,191,189,239,191,189,115,239,191,189,239,191,189,18,126,239,191,189,239,191,189,205,188,239,191,189,239,191,189,239,191,189,60,239,191,189,118,213,168,53,239,191,189,103,239,191,189,32,51,239,191,189,21,239,191,189,70,239,191,189,45,38,17,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,107,46,92,47,91,239,191,189,76,89,79,110,239,191,189,239,191,189,239,191,189,127,8,83,239,191,189,239,191,189,239,191,189,239,191,189,64,68,239,191,189,239,191,189,239,191,189,239,191,189,72,97,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,239,191,189,239,191,189,3,239,191,189,81,239,191,189,239,191,189,91,239,191,189,118,109,114,55,210,168,26,23,197,141,239,191,189,38,239,191,189,199,136,239,191,189,123,239,191,189,116,239,191,189,239,191,189,201,133,57,239,191,189,117,239,191,189,239,191,189,75,239,191,189,239,191,189,83,239,191,189,239,191,189,30,58,50,16,239,191,189,61,239,191,189,239,191,189,32,239,191,189,239,191,189,239,191,189,3,239,191,189,123,239,191,189,213,190,120,239,191,189,38,239,191,189,239,191,189,57,239,191,189,92,24,97,239,191,189,25,239,191,189,84,60,239,191,189,239,191,189,78,239,191,189,106,91,55,46,217,169,239,191,189,63,239,191,189,113,239,191,189,62,100,239,191,189,33,239,191,189,64,239,191,189,114,82,239,191,189,93,50,36,33,239,191,189,7,227,165,152,85,83,45,98,107,98,65,122,77,3,239,191,189,239,191,189,5,239,191,189,35,103,66,239,191,189,121,239,191,189,239,191,189,54,239,191,189,239,191,189,13,40,18,13,239,191,189,17,239,191,189,21,28,63,16,1,106,239,191,189,239,191,189,239,191,189,108,110,96,239,191,189,87,71,239,191,189,239,191,189,239,191,189,239,191,189,87,44,239,191,189,96,29,49,239,191,189,93,58,46,109,101,98,239,191,189,95,239,191,189,239,191,189,69,18,102,239,191,189,239,191,189,239,191,189,55,239,191,189,199,154,239,191,189,239,191,189,239,191,189,115,14,93,220,186,110,121,239,191,189,33,239,191,189,41,13,239,191,189,108,87,7,12,239,191,189,239,191,189,103,121,89,239,191,189,36,239,191,189,77,100,239,191,189,85,239,191,189,77,239,191,189,89,239,191,189,94,8,239,191,189,38,239,191,189,118,17,35,51,60,239,191,189,71,114,223,128,239,191,189,26,239,191,189,78,103,26,34,56,239,191,189,47,32,21,239,191,189,239,191,189,71,239,191,189,101,43,239,191,189,239,191,189,239,191,189,239,191,189,90,239,191,189,239,191,189,104,53,239,191,189,239,191,189,33,67,218,132,88,239,191,189,124,97,89,239,191,189,60,207,148,239,191,189,239,191,189,97,45,87,239,191,189,96,101,28,239,191,189,239,191,189,52,239,191,189,61,93,239,191,189,239,191,189,106,81,239,191,189,239,191,189,69,239,191,189,239,191,189,50,239,191,189,122,11,57,17,239,191,189,47,239,191,189,99,221,144,58,239,191,189,203,134,239,191,189,38,25,239,191,189,239,191,189,101,239,191,189,35,239,191,189,239,191,189,239,191,189,125,239,191,189,10,239,191,189,208,162,37,32,239,191,189,90,239,191,189,42,81,66,93,96,239,191,189,239,191,189,6,239,191,189,239,191,189,19,239,191,189,44,239,191,189,239,191,189,15,87,15,69,85,239,191,189,44,88,82,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,97,67,106,115,239,191,189,34,94,239,191,189,47,46,239,191,189,50,239,191,189,239,191,189,69,94,239,191,189,239,191,189,88,17,239,191,189,75,239,191,189,90,62,239,191,189,22,4,13,13,44,77,239,191,189,41,239,191,189,239,191,189,239,191,189,126,46,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,239,191,189,239,191,189,120,19,239,191,189,239,191,189,95,239,191,189,18,21,239,191,189,15,53,239,191,189,12,90,239,191,189,33,2,104,62,239,191,189,1,194,156,96,239,191,189,239,191,189,97,239,191,189,107,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,25,45,239,191,189,239,191,189,90,22,239,191,189,220,178,73,72,239,191,189,85,223,190,20,55,122,117,119,80,87,239,191,189,239,191,189,56,24,239,191,189,30,84,239,191,189,69,110,105,239,191,189,239,191,189,126,122,239,191,189,114,101,239,191,189,239,191,189,23,119,16,11,26,239,191,189,114,239,191,189,10,43,37,239,191,189,194,172,239,191,189,60,34,239,191,189,239,191,189,94,239,191,189,3,47,239,191,189,67,202,150,239,191,189,239,191,189,3,18,106,109,105,114,239,191,189,44,239,191,189,239,191,189,239,191,189,208,165,26,72,239,191,189,239,191,189,71,239,191,189,62,239,191,189,116,115,40,239,191,189,126,116,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,115,39,18,53,85,67,40,239,191,189,239,191,189,239,191,189,239,191,189,16,239,191,189,239,191,189,239,191,189,239,191,189,33,106,239,191,189,239,191,189,126,213,143,239,191,189,66,239,191,189,239,191,189,239,191,189,239,191,189,12,38,27,239,191,189,9,50,239,191,189,53,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,116,127,23,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,109,95,42,72,239,191,189,239,191,189,115,239,191,189,116,88,42,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,9,26,31,42,239,191,189,96,115,239,191,189,14,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,89,194,162,16,239,191,189,239,191,189,239,191,189,226,155,166,239,191,189,122,200,147,74,112,239,191,189,239,191,189,52,108,239,191,189,125,83,200,145,239,191,189,239,191,189,24,239,191,189,31,29,239,191,189,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,21,39,127,121,82,103,239,191,189,239,191,189,121,239,191,189,50,239,191,189,114,84,0,239,191,189,110,239,191,189,126,239,191,189,219,173,7,123,239,191,189,62,239,191,189,239,191,189,239,191,189,92,239,191,189,239,191,189,14,239,191,189,86,108,239,191,189,239,191,189,117,42,96,215,158,60,239,191,189,67,38,109,45,239,191,189,127,16,87,31,239,191,189,104,31,3,239,191,189,19,239,191,189,239,191,189,239,191,189,29,24,239,191,189,203,161,239,191,189,239,191,189,221,148,100,84,83,3,15,203,143,69,24,74,109,52,239,191,189,117,89,239,191,189,72,239,191,189,76,239,191,189,239,191,189,97,123,99,239,191,189,36,106,119,239,191,189,110,239,191,189,239,191,189,239,191,189,3,204,132,88,84,116,239,191,189,239,191,189,100,239,191,189,239,191,189,65,239,191,189,41,239,191,189,88,16,71,239,191,189,3,239,191,189,239,191,189,21,239,191,189,239,191,189,37,205,146,239,191,189,239,191,189,81,239,191,189,239,191,189,85,34,196,149,239,191,189,239,191,189,62,101,22,239,191,189,58,63,239,191,189,64,239,191,189,45,94,82,0,64,239,191,189,42,239,191,189,111,202,173,79,239,191,189,104,239,191,189,239,191,189,98,80,239,191,189,211,186,239,191,189,122,79,94,108,239,191,189,239,191,189,25,239,191,189,78,37,239,191,189,51,101,125,239,191,189,81,239,191,189,32,42,69,84,239,191,189,74,54,96,239,191,189,239,191,189,26,239,191,189,239,191,189,109,239,191,189,239,191,189,3,239,191,189,239,191,189,10,104,194,148,123,239,191,189,106,239,191,189,3,10,56,17,239,191,189,239,191,189,239,191,189,116,62,239,191,189,4,39,11,239,191,189,51,239,191,189,3,95,125,119,83,203,153,126,239,191,189,239,191,189,22,194,131,239,191,189,79,239,191,189,203,182,239,191,189,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,107,90,52,239,191,189,121,239,191,189,105,53,195,145,27,9,239,191,189,87,55,113,239,191,189,98,196,162,239,191,189,239,191,189,126,96,65,92,84,239,191,189,239,191,189,29,61,17,239,191,189,239,191,189,239,191,189,113,101,127,53,19,239,191,189,239,191,189,239,191,189,46,51,239,191,189,239,191,189,95,239,191,189,18,39,99,239,191,189,76,239,191,189,122,239,191,189,211,189,29,116,239,191,189,239,191,189,239,191,189,84,10,123,65,111,239,191,189,12,58,45,239,191,189,239,191,189,89,49,80,44,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,218,134,66,239,191,189,108,239,191,189,239,191,189,239,191,189,23,239,191,189,239,191,189,7,24,239,191,189,40,62,239,191,189,239,191,189,239,191,189,6,239,191,189,54,239,191,189,86,239,191,189,72,239,191,189,239,191,189,54,239,191,189,127,239,191,189,239,191,189,122,239,191,189,57,108,2,49,122,119,21,18,10,82,25,118,3,72,239,191,189,5,239,191,189,7,239,191,189,239,191,189,239,191,189,80,36,9,239,191,189,126,31,16,30,103,95,239,191,189,5,42,239,191,189,201,139,117,32,239,191,189,75,49,47,21,239,191,189,239,191,189,122,239,191,189,81,239,191,189,239,191,189,239,191,189,77,27,239,191,189,39,239,191,189,239,191,189,239,191,189,239,191,189,51,239,191,189,23,94,66,239,191,189,23,34,11,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,70,239,191,189,212,165,33,205,189,239,191,189,205,184,14,14,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,81,239,191,189,125,239,191,189,68,239,191,189,239,191,189,98,239,191,189,69,23,83,239,191,189,239,191,189,239,191,189,51,74,77,239,191,189,76,239,191,189,101,244,142,144,138,239,191,189,9,239,191,189,17,8,239,191,189,17,79,32,120,239,191,189,1,239,191,189,239,191,189,67,85,239,191,189,239,191,189,53,239,191,189,11,16,37,110,239,191,189,59,200,136,120,239,191,189,239,191,189,111,239,191,189,32,48,89,76,51,14,90,239,191,189,94,239,191,189,112,60,73,90,239,191,189,9,239,191,189,239,191,189,78,88,239,191,189,127,239,191,189,239,191,189,17,98,239,191,189,48,239,191,189,214,135,239,191,189,77,210,189,239,191,189,9,84,239,191,189,239,191,189,239,191,189,239,191,189,51,239,191,189,50,102,239,191,189,239,191,189,126,239,191,189,239,191,189,57,22,0,239,191,189,239,191,189,117,58,239,191,189,65,41,85,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,22,31,121,239,191,189,239,191,189,125,239,191,189,239,191,189,113,46,239,191,189,239,191,189,239,191,189,60,10,239,191,189,203,182,112,77,49,50,116,207,131,85,239,191,189,239,191,189,36,239,191,189,52,124,105,88,239,191,189,95,123,51,239,191,189,239,191,189,74,239,191,189,26,71,90,239,191,189,85,239,191,189,75,239,191,189,239,191,189,239,191,189,69,239,191,189,86,228,170,170,4,98,239,191,189,13,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,94,239,191,189,100,239,191,189,53,239,191,189,2,99,23,44,116,239,191,189,0,239,191,189,93,125,83,106,54,239,191,189,1,239,191,189,239,191,189,239,191,189,46,31,239,191,189,61,32,239,191,189,78,239,191,189,67,239,191,189,239,191,189,239,191,189,66,239,191,189,111,239,191,189,239,191,189,239,191,189,126,54,86,98,6,239,191,189,48,64,239,191,189,44,215,145,101,239,191,189,239,191,189,105,21,8,239,191,189,66,239,191,189,239,191,189,125,106,62,54,239,191,189,58,96,239,191,189,239,191,189,13,14,45,54,239,191,189,216,189,198,142,239,191,189,70,239,191,189,239,191,189,107,47,41,239,191,189,239,191,189,239,191,189,126,102,239,191,189,59,239,191,189,239,191,189,239,191,189,35,239,191,189,239,191,189,239,191,189,223,184,100,202,131,56,239,191,189,239,191,189,239,191,189,88,65,54,82,74,31,239,191,189,239,191,189,14,13,21,239,191,189,239,191,189,87,97,36,93,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,102,6,102,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,38,36,239,191,189,93,239,191,189,127,6,239,191,189,21,239,191,189,239,191,189,105,8,97,3,239,191,189,38,70,41,21,239,191,189,239,191,189,74,239,191,189,88,239,191,189,25,75,93,98,28,46,239,191,189,239,191,189,49,60,113,239,191,189,0,23,239,191,189,0,239,191,189,52,239,191,189,239,191,189,93,239,191,189,99,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,84,103,239,191,189,24,5,12,102,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,42,48,239,191,189,51,38,69,18,57,239,191,189,58,22,239,191,189,200,134,117,239,191,189,97,239,191,189,113,112,51,239,191,189,239,191,189,99,89,239,191,189,239,191,189,33,113,209,142,17,239,191,189,51,115,239,191,189,239,191,189,95,100,239,191,189,103,239,191,189,44,239,191,189,62,60,239,191,189,239,191,189,239,191,189,44,239,191,189,52,61,97,239,191,189,102,99,239,191,189,43,81,97,24,50,105,239,191,189,239,191,189,239,191,189,83,1,75,239,191,189,123,13,239,191,189,239,191,189,217,157,239,191,189,27,239,191,189,110,239,191,189,79,68,239,191,189,89,211,153,239,191,189,12,58,239,191,189,52,19,72,78,125,239,191,189,58,116,111,50,238,135,147,91,38,119,239,191,189,239,191,189,239,191,189,195,191,109,239,191,189,239,191,189,239,191,189,110,46,239,191,189,51,239,191,189,239,191,189,17,239,191,189,71,239,191,189,124,126,91,239,191,189,101,239,191,189,78,59,239,191,189,199,177,239,191,189,50,91,4,239,191,189,66,118,46,239,191,189,47,239,191,189,239,191,189,239,191,189,84,11,127,60,115,239,191,189,118,239,191,189,19,44,239,191,189,22,106,239,191,189,93,25,31,239,191,189,239,191,189,1,60,239,191,189,239,191,189,239,191,189,46,239,191,189,125,239,191,189,239,191,189,239,191,189,239,191,189,203,133,89,39,18,239,191,189,239,191,189,81,201,139,6,96,239,191,189,98,83,24,21,239,191,189,239,191,189,214,131,83,239,191,189,16,239,191,189,13,239,191,189,71,239,191,189,106,239,191,189,98,37,29,239,191,189,106,4,239,191,189,13,239,191,189,239,191,189,239,191,189,114,67,239,191,189,57,64,239,191,189,95,239,191,189,104,239,191,189,66,239,191,189,117,120,0,73,66,4,71,239,191,189,117,95,239,191,189,239,191,189,58,239,191,189,239,191,189,239,191,189,20,34,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,65,26,239,191,189,239,191,189,239,191,189,239,191,189,90,2,239,191,189,31,39,239,191,189,38,106,239,191,189,239,191,189,8,239,191,189,104,58,19,73,81,239,191,189,112,239,191,189,118,108,69,66,239,191,189,32,239,191,189,239,191,189,239,191,189,46,239,191,189,55,85,239,191,189,26,92,67,239,191,189,19,39,239,191,189,126,89,114,239,191,189,15,117,239,191,189,239,191,189,239,191,189,201,171,92,38,113,239,191,189,116,239,191,189,6,5,239,191,189,239,191,189,239,191,189,24,239,191,189,66,239,191,189,31,239,191,189,6,239,191,189,239,191,189,72,44,239,191,189,19,210,178,239,191,189,239,191,189,10,239,191,189,239,191,189,100,239,191,189,239,191,189,46,54,45,239,191,189,239,191,189,0,12,34,15,239,191,189,239,191,189,89,239,191,189,205,181,120,23,239,191,189,239,191,189,239,191,189,19,239,191,189,122,239,191,189,239,191,189,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,40,45,239,191,189,19,239,191,189,239,191,189,22,55,239,191,189,239,191,189,38,29,36,71,120,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,102,42,239,191,189,53,239,191,189,82,239,191,189,13,6,239,191,189,39,73,239,191,189,44,201,185,43,239,191,189,0,239,191,189,50,239,191,189,239,191,189,239,191,189,85,239,191,189,114,239,191,189,60,103,105,19,13,239,191,189,2,45,239,191,189,206,160,97,41,239,191,189,45,239,191,189,239,191,189,53,239,191,189,75,41,4,239,191,189,12,239,191,189,29,52,72,239,191,189,88,102,239,191,189,66,63,239,191,189,73,239,191,189,54,239,191,189,239,191,189,41,239,191,189,239,191,189,93,229,158,143,109,239,191,189,239,191,189,8,31,239,191,189,38,239,191,189,56,239,191,189,93,97,239,140,185,83,239,191,189,103,239,191,189,31,239,191,189,239,191,189,239,191,189,65,239,191,189,83,239,191,189,33,239,191,189,41,108,38,18,239,191,189,199,148,239,191,189,80,70,239,191,189,27,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,85,112,72,85,239,191,189,5,126,239,191,189,115,208,172,106,239,191,189,47,4,22,15,49,54,78,97,239,191,189,37,103,53,32,16,4,78,103,56,239,191,189,239,191,189,96,106,239,191,189,69,239,191,189,118,33,239,191,189,239,191,189,84,239,191,189,62,239,191,189,122,239,191,189,22,239,191,189,239,191,189,122,41,239,191,189,239,191,189,239,191,189,74,239,191,189,31,239,191,189,239,191,189,122,86,11,239,191,189,203,160,107,239,191,189,83,239,191,189,58,239,191,189,21,239,191,189,120,112,97,41,78,239,191,189,112,239,191,189,239,191,189,228,189,183,67,239,191,189,239,191,189,103,100,239,191,189,239,191,189,44,25,239,191,189,73,43,114,70,15,239,191,189,195,179,72,239,191,189,20,239,191,189,24,31,239,191,189,239,191,189,46,239,191,189,239,191,189,239,191,189,38,239,191,189,20,92,239,191,189,239,191,189,239,191,189,108,239,191,189,26,239,191,189,239,191,189,39,53,239,191,189,8,239,191,189,239,191,189,42,21,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,125,239,191,189,239,191,189,113,239,191,189,239,191,189,5,34,80,94,239,191,189,115,239,191,189,239,191,189,71,239,191,189,239,191,189,44,42,50,239,191,189,239,191,189,0,200,151,239,191,189,97,118,239,191,189,239,191,189,112,239,191,189,239,191,189,49,110,239,191,189,239,191,189,239,191,189,63,19,239,191,189,5,239,191,189,87,30,35,239,191,189,83,239,191,189,239,191,189,88,119,78,239,191,189,239,191,189,202,172,26,218,188,43,239,191,189,239,191,189,115,239,191,189,6,239,191,189,239,191,189,105,239,191,189,29,239,191,189,239,191,189,22,81,239,191,189,206,168,239,191,189,116,67,14,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,95,111,239,191,189,18,239,191,189,206,131,239,191,189,81,110,113,105,24,239,191,189,239,191,189,239,191,189,70,239,191,189,91,239,191,189,56,51,239,191,189,239,191,189,4,112,101,120,29,239,191,189,239,191,189,239,191,189,239,191,189,113,48,76,239,191,189,117,239,191,189,46,105,46,0,239,191,189,93,62,239,191,189,239,191,189,87,36,98,239,191,189,40,111,92,44,239,191,189,239,191,189,14,25,104,10,239,191,189,106,239,191,189,239,191,189,117,239,191,189,100,239,191,189,36,239,191,189,40,44,33,9,50,76,239,191,189,239,191,189,222,133,33,239,191,189,239,191,189,239,191,189,198,132,21,3,239,191,189,28,103,122,239,191,189,94,100,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,123,239,191,189,0,239,191,189,239,191,189,239,191,189,78,83,239,191,189,82,11,72,58,239,191,189,239,191,189,239,191,189,230,151,186,239,191,189,96,239,191,189,8,104,239,191,189,102,194,164,239,191,189,82,239,191,189,239,191,189,239,191,189,9,106,239,191,189,239,191,189,36,239,191,189,53,239,191,189,10,90,16,30,64,239,191,189,116,239,191,189,239,191,189,98,33,239,191,189,88,27,239,191,189,239,191,189,40,30,239,191,189,239,191,189,239,191,189,91,239,191,189,74,76,69,239,191,189,126,239,191,189,239,191,189,115,239,191,189,239,191,189,85,239,191,189,239,191,189,73,109,239,191,189,77,18,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,6,53,239,191,189,19,239,191,189,91,239,191,189,239,191,189,239,191,189,11,239,191,189,239,191,189,239,191,189,239,191,189,49,27,239,191,189,239,191,189,43,0,223,176,19,62,239,191,189,109,15,239,191,189,38,239,191,189,239,191,189,239,191,189,239,191,189,42,108,239,191,189,17,239,191,189,239,191,189,60,48,119,115,118,87,90,51,0,110,9,19,39,123,239,191,189,239,191,189,85,34,107,119,65,75,28,239,191,189,80,32,30,221,144,239,191,189,119,10,239,191,189,31,239,191,189,239,191,189,103,60,239,191,189,239,191,189,65,57,15,59,29,239,191,189,239,191,189,92,239,191,189,63,22,239,191,189,239,191,189,68,100,239,191,189,19,239,191,189,35,86,57,124,239,191,189,125,239,191,189,239,191,189,71,7,239,191,189,46,239,191,189,25,239,191,189,239,191,189,54,7,59,239,191,189,239,191,189,93,239,191,189,2,81,108,239,191,189,100,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,25,69,239,191,189,196,151,239,191,189,69,30,79,239,191,189,206,172,239,191,189,239,191,189,16,32,14,93,239,191,189,51,60,105,239,191,189,119,121,80,17,21,239,191,189,239,191,189,77,239,191,189,114,239,191,189,239,191,189,64,239,191,189,114,111,239,191,189,239,191,189,111,107,239,191,189,239,191,189,86,239,191,189,110,239,191,189,68,121,93,70,239,191,189,95,239,191,189,77,54,74,70,239,191,189,48,239,191,189,239,191,189,110,62,57,239,191,189,239,191,189,239,191,189,72,239,191,189,239,191,189,12,239,191,189,239,191,189,239,191,189,85,239,191,189,35,239,191,189,239,191,189,68,86,70,239,191,189,73,239,191,189,79,239,191,189,39,41,40,106,239,191,189,239,191,189,52,239,191,189,29,239,191,189,112,1,239,191,189,239,191,189,111,58,239,191,189,239,191,189,239,191,189,39,239,191,189,239,191,189,239,191,189,46,73,126,239,191,189,80,79,239,191,189,219,166,116,239,191,189,239,191,189,45,239,191,189,34,32,239,191,189,6,239,191,189,50,67,90,104,127,14,239,191,189,239,191,189,239,191,189,239,191,189,0,239,191,189,74,126,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,110,239,191,189,37,84,105,239,191,189,86,195,177,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,87,91,16,223,183,115,37,239,191,189,239,191,189,35,239,191,189,106,14,56,239,191,189,112,29,5,239,191,189,212,184,53,66,14,36,11,239,191,189,17,239,191,189,239,191,189,233,176,183,239,191,189,118,19,239,191,189,69,239,191,189,239,191,189,239,191,189,239,191,189,20,239,191,189,239,191,189,108,239,191,189,239,191,189,239,191,189,59,239,191,189,239,191,189,239,191,189,42,45,33,25,2,239,191,189,239,191,189,239,191,189,20,239,191,189,239,191,189,57,223,178,52,239,191,189,123,239,191,189,239,191,189,104,9,78,239,191,189,33,239,191,189,16,239,191,189,53,239,191,189,18,98,74,27,207,141,239,191,189,84,239,191,189,239,191,189,239,191,189,239,191,189,97,113,239,191,189,59,84,30,239,191,189,239,191,189,37,239,191,189,125,239,191,189,101,239,191,189,239,191,189,50,0,100,239,191,189,2,118,239,191,189,2,239,191,189,239,191,189,29,16,37,239,191,189,110,239,191,189,14,76,120,239,191,189,239,191,189,57,239,191,189,96,239,191,189,239,191,189,239,191,189,209,142,229,150,182,239,191,189,239,191,189,121,84,239,191,189,239,191,189,239,191,189,121,239,191,189,111,40,239,191,189,54,13,239,191,189,23,239,191,189,2,110,104,239,191,189,47,239,191,189,239,191,189,26,3,239,191,189,3,239,191,189,239,191,189,115,239,191,189,239,191,189,102,25,116,15,25,239,191,189,81,239,191,189,239,191,189,239,191,189,109,17,55,42,239,191,189,106,125,25,239,191,189,118,46,239,191,189,199,177,239,191,189,57,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,116,239,191,189,239,191,189,239,191,189,31,8,239,191,189,22,29,239,191,189,239,191,189,75,239,191,189,239,191,189,239,191,189,239,191,189,26,239,191,189,99,239,191,189,239,191,189,61,200,156,82,195,142,239,191,189,88,239,191,189,62,103,239,191,189,113,239,191,189,239,191,189,91,239,191,189,75,117,124,117,89,239,191,189,239,191,189,123,30,239,191,189,86,239,191,189,239,191,189,239,191,189,52,70,21,55,239,191,189,51,239,191,189,91,121,239,191,189,239,191,189,239,191,189,102,239,191,189,95,32,74,99,125,41,77,239,191,189,53,112,239,191,189,63,239,191,189,214,164,239,191,189,239,191,189,82,51,239,191,189,92,101,239,191,189,39,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,35,88,28,239,191,189,79,239,191,189,61,121,239,191,189,69,16,239,191,189,83,239,191,189,117,202,182,239,191,189,52,32,239,191,189,19,81,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,93,239,191,189,119,239,191,189,20,27,101,239,191,189,239,191,189,239,191,189,239,191,189,96,118,239,191,189,238,148,184,18,227,178,133,57,118,239,191,189,239,191,189,51,15,7,97,58,107,33,239,191,189,65,81,239,191,189,239,191,189,62,239,191,189,16,15,15,223,157,239,191,189,37,96,99,37,11,239,191,189,239,191,189,84,35,125,239,191,189,33,239,191,189,11,93,88,107,58,116,120,239,191,189,113,239,191,189,239,191,189,239,191,189,239,191,189,79,239,191,189,118,41,239,191,189,239,191,189,239,191,189,14,239,191,189,239,191,189,60,47,239,191,189,51,68,74,30,212,170,239,191,189,94,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,41,70,78,239,191,189,239,191,189,40,62,239,191,189,239,191,189,1,239,191,189,239,191,189,239,191,189,2,73,239,191,189,92,239,191,189,28,59,239,191,189,65,52,239,191,189,83,239,191,189,81,3,117,239,191,189,239,191,133,239,191,189,194,145,239,191,189,239,191,189,239,191,189,19,239,191,189,67,108,36,239,191,189,127,239,191,189,42,239,191,189,239,191,189,104,4,239,191,189,18,194,155,239,191,189,239,191,189,58,239,191,189,239,191,189,17,31,116,239,191,189,64,239,191,189,17,239,191,189,239,191,189,8,74,6,239,191,189,239,191,189,31,46,218,169,239,191,189,239,191,189,239,191,189,36,28,239,191,189,239,191,189,127,239,191,189,36,239,191,189,60,239,191,189,16,239,191,189,49,77,239,191,189,239,191,189,104,239,191,189,122,239,191,189,28,239,191,189,29,239,191,189,59,33,239,191,189,108,36,46,239,191,189,239,191,189,57,27,239,191,189,87,9,101,57,19,119,239,191,189,203,147,239,191,189,239,191,189,239,191,189,125,239,191,189,65,239,191,189,110,14,217,146,239,191,189,239,191,189,93,91,239,191,189,239,191,189,14,0,111,239,191,189,22,82,89,239,191,189,3,239,191,189,103,23,31,198,137,7,77,98,239,191,189,239,191,189,67,239,191,189,239,191,189,50,42,65,103,87,26,239,191,189,219,183,239,191,189,67,239,191,189,239,191,189,239,191,189,104,239,191,189,239,191,189,36,239,191,189,62,47,6,239,191,189,239,191,189,239,191,189,117,239,191,189,82,239,191,189,239,191,189,239,191,189,119,33,7,61,90,239,191,189,239,191,189,1,239,191,189,61,239,191,189,239,191,189,88,239,191,189,8,239,191,189,239,191,189,239,191,189,79,239,191,189,80,239,191,189,239,191,189,44,51,239,191,189,239,191,189,239,191,189,50,115,239,191,189,43,239,191,189,204,156,239,191,189,73,13,210,148,34,29,0,125,85,239,191,189,239,191,189,239,191,189,126,103,108,64,60,239,191,189,38,114,61,16,39,78,79,30,239,191,189,239,191,189,209,133,98,15,107,105,54,239,191,189,231,186,168,51,239,191,189,76,214,148,239,191,189,239,191,189,100,239,191,189,6,239,191,189,239,191,189,239,191,189,239,191,189,42,79,57,239,191,189,68,3,123,54,239,191,189,239,191,189,60,239,191,189,88,20,48,239,191,189,88,239,191,189,86,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,120,239,191,189,239,191,189,239,191,189,48,239,191,189,106,105,65,26,239,191,189,239,191,189,99,117,239,191,189,239,191,189,119,239,191,189,5,87,239,191,189,126,79,239,191,189,113,72,109,239,191,189,239,191,189,102,95,239,191,189,82,239,191,189,239,191,189,72,239,191,189,114,123,58,239,191,189,101,23,239,191,189,51,239,191,189,239,191,189,11,239,191,189,58,76,79,53,60,239,191,189,239,191,189,107,60,82,239,191,189,39,201,182,219,187,239,191,189,239,191,189,239,191,189,239,191,189,92,19,4,37,202,133,114,103,84,102,239,191,189,83,98,239,191,189,119,25,15,239,191,189,22,16,239,191,189,239,191,189,104,32,239,191,189,19,8,239,191,189,60,63,52,4,112,97,85,39,71,42,106,239,191,189,91,239,191,189,23,213,132,239,191,189,239,191,189,239,191,189,62,239,191,189,239,191,189,53,239,191,189,116,239,191,189,127,239,191,189,228,145,183,124,239,191,189,42,21,50,239,191,189,239,191,189,1,239,191,189,80,239,191,189,239,191,189,94,95,239,191,189,62,197,146,239,191,189,239,191,189,77,47,112,122,239,191,189,239,191,189,123,239,191,189,239,191,189,239,191,189,123,98,239,191,189,239,191,189,58,239,191,189,104,1,239,191,189,239,191,189,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,239,191,189,41,239,191,189,239,191,189,239,191,189,24,73,239,191,189,105,77,83,239,191,189,239,191,189,51,78,239,191,189,120,239,191,189,239,191,189,111,76,239,191,189,37,29,239,191,189,239,191,189,239,191,189,239,191,189,76,239,191,189,239,191,189,239,191,189,239,191,189,39,81,59,239,191,189,29,98,25,5,74,239,191,189,68,239,191,189,127,112,107,239,191,189,75,121,25,239,191,189,122,44,4,239,191,189,239,191,189,239,191,189,41,104,70,239,191,189,93,239,191,189,37,239,191,189,11,239,191,189,239,191,189,239,191,189,239,191,189,114,85,71,97,56,239,191,189,29,69,126,116,239,191,189,62,118,105,10,81,239,191,189,77,239,191,189,42,40,57,239,191,189,239,191,189,106,239,191,189,115,239,191,189,239,191,189,101,110,28,239,191,189,210,166,42,51,239,191,189,239,191,189,202,167,239,191,189,239,191,189,239,191,189,195,161,239,191,189,103,26,101,15,239,191,189,20,95,127,56,239,191,189,239,191,189,239,191,189,239,191,189,100,239,191,189,124,25,6,102,124,239,191,189,239,191,189,239,191,189,30,48,239,191,189,205,131,120,239,191,189,239,191,189,239,191,189,201,169,12,120,99,85,239,191,189,7,99,82,110,239,191,189,239,191,189,239,191,189,34,101,28,51,239,191,189,239,191,189,92,36,65,239,191,189,58,71,239,191,189,45,71,239,191,189,6,239,191,189,239,191,189,44,239,191,189,88,17,25,239,191,189,71,94,25,82,84,89,116,91,95,103,102,69,239,191,189,207,158,239,191,189,104,103,61,28,119,239,191,189,239,191,189,239,191,189,75,195,158,28,239,191,189,34,13,11,26,205,166,239,191,189,11,239,191,189,80,239,191,189,211,130,239,191,189,239,191,189,117,239,191,189,239,191,189,23,239,136,151,239,191,189,239,191,189,239,191,189,76,239,191,189,239,191,189,239,191,189,6,239,191,189,239,191,189,87,239,191,189,61,89,91,43,47,41,239,191,189,239,191,189,120,22,92,73,239,191,189,239,191,189,239,191,189,17,239,191,189,22,239,191,189,44,31,239,191,189,28,55,29,239,191,189,239,191,189,95,121,239,191,189,38,123,206,145,239,191,189,26,239,191,189,125,239,191,189,79,239,191,189,31,239,191,189,119,239,191,189,88,239,191,189,123,122,52,43,239,191,189,239,191,189,61,35,13,239,191,189,56,64,30,239,191,189,86,53,239,191,189,37,49,89,239,191,189,239,191,189,239,191,189,239,191,189,48,107,65,239,191,189,105,40,239,191,189,239,191,189,239,191,189,109,69,239,191,189,79,58,239,191,189,72,239,191,189,239,191,189,206,182,15,208,143,239,191,189,66,239,191,189,50,239,191,189,101,239,191,189,239,191,189,239,191,189,79,99,70,239,191,189,100,239,191,189,239,191,189,58,239,191,189,37,34,17,66,126,239,191,189,83,16,0,107,239,191,189,239,191,189,239,191,189,95,220,190,125,239,191,189,239,191,189,60,59,112,239,191,189,99,86,0,214,151,77,239,191,189,239,191,189,72,124,111,239,191,189,109,114,239,191,189,103,70,109,84,239,191,189,28,23,239,191,189,239,191,189,3,106,61,239,191,189,32,239,191,189,239,191,189,100,239,191,189,60,239,191,189,239,191,189,126,21,239,191,189,239,191,189,110,239,191,189,239,191,189,101,93,239,191,189,110,76,125,28,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,76,239,191,189,125,239,191,189,44,15,239,191,189,196,185,126,11,239,191,189,49,239,191,189,18,239,191,189,49,239,191,189,239,191,189,26,239,191,189,239,191,189,85,37,79,239,191,189,239,191,189,105,4,239,191,189,46,125,239,191,189,114,97,80,0,66,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,81,239,191,189,61,239,191,189,106,50,126,29,86,239,191,189,51,239,191,189,69,88,239,191,189,48,30,65,239,191,189,239,191,189,80,239,191,189,41,239,191,189,98,239,191,189,239,191,189,239,191,189,34,239,191,189,86,239,191,189,239,191,189,111,211,144,239,191,189,105,239,191,189,239,191,189,97,16,38,239,191,189,62,239,191,189,11,239,191,189,239,191,189,94,239,191,189,239,191,189,2,239,191,189,195,149,126,37,239,191,189,73,239,191,189,239,191,189,120,119,96,239,191,189,214,133,239,191,189,113,239,191,189,67,239,191,189,121,63,103,42,239,191,189,239,191,189,239,191,189,64,47,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,15,239,191,189,64,67,85,239,191,189,239,191,189,21,239,191,189,239,191,189,239,191,189,239,191,189,52,34,239,191,189,239,191,189,239,191,189,61,20,117,87,91,106,239,191,189,110,239,191,189,8,95,55,48,239,191,189,239,191,189,9,239,191,189,117,239,191,189,48,113,239,191,189,101,239,191,189,41,239,191,189,239,191,189,239,191,189,239,191,189,30,99,239,191,189,104,239,191,189,239,191,189,106,239,191,189,239,191,189,239,191,189,66,239,191,189,99,127,113,239,191,189,125,239,191,189,77,239,191,189,54,239,191,189,213,189,109,79,239,191,189,239,191,189,45,239,191,189,239,191,189,91,121,111,239,191,189,239,191,189,97,239,191,189,8,212,158,124,239,191,189,101,237,156,139,239,191,189,53,74,60,239,191,189,84,59,76,113,239,191,189,24,239,191,189,72,12,239,191,189,84,17,239,191,189,239,191,189,91,239,191,189,117,124,239,191,189,239,191,189,120,26,239,191,189,239,191,189,111,239,191,189,239,191,189,239,191,189,200,152,239,191,189,101,9,6,61,35,121,110,73,239,191,189,239,191,189,239,191,189,1,40,239,191,189,239,191,189,6,65,239,191,189,82,239,191,189,206,136,239,191,189,239,191,189,32,239,191,189,239,191,189,30,73,41,239,191,189,68,4,113,239,191,189,239,191,189,239,191,189,29,239,191,189,26,6,51,239,191,189,29,239,191,189,25,239,191,189,58,239,191,189,200,143,44,118,239,191,189,20,239,191,189,41,42,29,239,191,189,239,191,189,80,0,239,191,189,59,239,191,189,239,191,189,239,191,189,4,239,191,189,37,35,239,191,189,55,239,191,189,239,191,189,239,191,189,239,191,189,43,7,1,75,73,239,191,189,239,191,189,88,239,191,189,44,92,206,152,239,191,189,0,63,38,239,191,189,51,65,239,191,189,44,28,239,191,189,53,239,191,189,239,191,189,107,100,62,30,121,59,102,239,191,189,21,239,191,189,239,191,189,7,127,11,239,191,189,239,191,189,89,54,64,111,35,239,191,189,17,3,103,97,239,191,189,239,191,189,239,191,189,38,21,77,239,191,189,46,239,191,189,13,239,191,189,50,239,191,189,239,191,189,125,239,191,189,239,191,189,53,239,191,189,117,75,239,191,189,239,191,189,239,191,189,51,72,239,191,189,44,27,18,217,132,239,191,189,42,105,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,38,239,191,189,118,239,191,189,13,239,191,189,56,216,147,84,239,191,189,43,227,137,159,239,191,189,23,239,191,189,239,191,189,239,191,189,23,99,239,191,189,208,184,239,191,189,239,191,189,239,191,189,70,239,191,189,239,191,189,16,88,14,79,239,191,189,10,90,239,191,189,123,15,3,239,191,189,239,191,189,95,239,191,189,239,191,189,117,239,191,189,239,191,189,123,40,239,191,189,239,191,189,239,191,189,239,191,189,208,166,239,191,189,95,239,191,189,120,239,191,189,239,191,189,96,239,191,189,239,191,189,239,191,189,58,22,239,191,189,239,191,189,239,191,189,46,239,191,189,20,239,191,189,44,113,10,12,66,53,239,191,189,110,239,191,189,24,97,53,239,191,189,239,191,189,99,111,78,123,239,191,189,112,239,191,189,102,239,191,189,239,191,189,239,191,189,59,115,41,239,191,189,69,239,191,189,33,239,191,189,239,191,189,239,191,189,53,239,191,189,83,239,191,189,66,16,57,239,191,189,239,191,189,113,239,191,189,239,191,189,93,55,77,239,191,189,239,191,189,62,239,191,189,239,191,189,197,180,46,63,6,239,191,189,88,239,191,189,239,191,189,78,64,113,239,191,189,21,46,239,191,189,239,191,189,239,191,189,84,96,239,191,189,239,191,189,50,106,46,239,191,189,21,239,191,189,113,239,191,189,21,239,191,189,33,31,222,128,239,191,189,20,239,191,189,239,191,189,239,191,189,239,191,189,14,59,49,45,28,72,9,239,191,189,239,191,189,239,191,189,239,191,189,66,35,239,191,189,239,191,189,16,121,239,191,189,103,62,239,191,189,56,93,80,114,55,239,191,189,239,191,189,239,191,189,6,212,168,43,239,191,189,239,191,189,57,0,112,239,191,189,239,191,189,21,31,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,3,61,239,191,189,80,76,56,3,239,191,189,221,169,17,92,239,191,189,239,191,189,20,239,191,189,239,191,189,48,239,191,189,239,191,189,16,8,239,191,189,126,239,191,189,239,191,189,24,100,113,119,76,239,191,189,239,191,189,239,191,189,239,191,189,1,87,223,139,239,191,189,101,35,199,187,239,191,189,239,191,189,96,48,239,191,189,67,3,239,191,189,114,100,239,191,189,52,239,191,189,239,191,189,239,191,189,120,239,191,189,111,107,50,196,173,239,191,189,239,191,189,37,19,66,24,239,191,189,239,191,189,36,239,191,189,65,35,239,191,189,94,239,191,189,45,115,239,191,189,61,239,191,189,239,191,189,12,239,191,189,31,18,9,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,213,141,10,239,191,189,1,239,191,189,20,239,191,189,63,7,239,191,189,239,191,189,239,191,189,1,26,2,239,191,189,61,239,191,189,49,112,113,239,191,189,7,239,191,189,239,191,189,239,191,189,239,191,189,46,52,239,191,189,44,19,239,191,189,239,191,189,221,176,44,239,191,189,126,99,71,239,191,189,58,239,191,189,29,239,191,189,6,7,122,239,191,189,239,191,189,111,99,239,191,189,122,239,191,189,67,239,191,189,73,17,239,191,189,69,239,191,189,239,191,189,24,72,36,62,16,53,239,191,189,12,41,239,191,189,239,191,189,239,191,189,22,219,155,239,191,189,38,239,191,189,239,191,189,102,239,191,189,239,191,189,41,98,239,191,189,239,191,189,239,191,189,26,53,20,93,239,191,189,239,191,189,5,239,191,189,239,191,189,239,191,189,105,239,191,189,18,98,57,239,191,189,239,191,189,239,191,189,44,22,239,191,189,239,191,189,239,191,189,24,111,62,38,239,191,189,31,239,191,189,87,39,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,59,239,191,189,239,191,189,93,80,53,83,65,75,127,239,191,189,234,188,128,22,89,74,239,191,189,239,191,189,86,239,191,189,115,239,191,189,31,114,65,2,92,112,69,239,191,189,239,191,189,239,191,189,239,191,189,65,239,191,189,26,239,191,189,239,191,189,58,239,191,189,239,191,189,70,239,191,189,239,191,189,108,107,30,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,92,239,191,189,239,191,189,15,50,239,191,189,239,191,189,5,239,191,189,239,191,189,36,239,191,189,63,28,63,239,191,189,52,239,191,189,107,239,191,189,44,239,191,189,50,5,239,191,189,239,191,189,216,156,239,191,189,92,239,191,189,104,222,157,239,191,189,239,191,189,239,191,189,7,239,191,189,20,65,239,191,189,22,72,239,191,189,223,130,89,239,191,189,239,191,189,116,239,191,189,54,109,84,239,191,189,57,79,58,239,191,189,105,239,191,189,122,62,98,96,127,239,191,189,26,124,239,191,189,120,239,191,189,239,191,189,16,27,239,191,189,52,4,58,126,239,191,189,23,110,113,239,191,189,239,191,189,48,62,239,191,189,126,239,191,189,239,191,189,26,239,191,189,239,191,189,9,62,126,3,239,191,189,239,191,189,61,65,239,191,189,239,191,189,75,92,56,39,4,74,239,191,189,122,239,191,189,239,191,189,12,204,178,239,191,189,79,109,93,239,191,189,239,191,189,239,191,189,19,32,127,239,191,189,239,191,189,239,191,189,55,239,191,189,239,191,189,239,191,189,44,117,239,191,189,92,239,191,189,5,239,191,189,122,109,239,191,189,239,191,189,32,23,239,191,189,60,239,191,189,197,180,63,115,64,77,60,94,55,59,239,191,189,114,14,239,191,189,200,168,239,191,189,239,191,189,239,191,189,87,1,92,123,103,198,130,239,191,189,6,239,191,189,239,191,189,9,239,191,189,119,105,239,191,189,239,191,189,239,191,189,109,239,191,189,239,191,189,57,82,36,239,191,189,76,35,107,239,191,189,239,191,189,239,191,189,72,25,239,191,189,239,191,189,105,57,216,172,239,191,189,239,191,189,54,95,68,50,239,191,189,239,191,189,239,191,189,5,70,22,106,100,0,29,239,191,189,55,239,191,189,27,239,191,189,23,239,191,189,21,6,239,191,189,239,191,189,63,239,191,189,239,191,189,86,73,239,191,189,239,191,189,239,191,189,24,2,239,191,189,239,191,189,101,239,191,189,40,199,162,239,191,189,239,191,189,222,180,239,191,189,239,191,189,239,191,189,49,85,239,191,189,9,239,191,189,239,191,189,32,88,239,191,189,65,239,191,189,104,197,175,239,191,189,92,239,191,189,239,191,189,239,191,189,26,239,191,189,87,125,239,191,189,122,80,60,107,37,239,191,189,60,239,191,189,239,191,189,2,36,239,191,189,239,191,189,239,191,189,54,49,239,191,189,69,36,239,191,189,239,191,189,1,239,191,189,52,44,199,172,31,239,191,189,239,191,189,34,239,191,189,86,239,191,189,239,191,189,51,239,191,189,5,239,191,189,239,191,189,195,138,8,95,239,191,189,81,239,191,189,56,34,18,88,239,191,189,239,191,189,78,73,239,191,189,239,191,189,239,191,189,15,239,191,189,29,239,191,189,74,27,239,191,189,39,239,191,189,45,102,119,31,239,191,189,33,62,104,239,191,189,37,65,239,191,189,17,116,239,191,189,239,191,189,127,127,239,191,189,7,96,239,191,189,239,191,189,54,239,191,189,51,239,191,189,239,191,189,63,239,191,189,239,191,189,113,46,10,239,191,189,239,191,189,57,239,191,189,239,191,189,16,239,191,189,25,123,86,53,239,191,189,239,191,189,230,130,155,90,83,239,191,189,39,55,239,191,189,65,41,199,160,94,40,239,191,189,239,191,189,118,104,239,191,189,105,63,44,70,239,191,189,60,239,191,189,127,239,191,189,23,223,191,125,239,191,189,239,191,189,239,191,189,82,41,119,239,191,189,7,239,191,189,239,191,189,89,15,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,85,85,239,191,189,23,239,191,189,90,239,191,189,97,105,73,239,191,189,101,107,100,119,239,191,189,239,191,189,218,149,86,239,191,189,54,239,191,189,67,67,239,191,189,122,60,0,239,191,189,82,103,239,191,189,239,191,189,96,239,191,189,95,121,45,239,191,189,239,191,189,239,191,189,48,77,76,239,191,189,99,239,191,189,239,191,189,239,191,189,239,191,189,80,239,191,189,31,239,191,189,211,159,239,191,189,239,191,189,126,96,118,239,191,189,47,19,4,104,208,158,27,123,27,40,219,144,97,19,239,191,189,122,124,239,191,189,32,239,191,189,239,191,189,239,191,189,1,239,191,189,239,191,189,28,239,191,189,21,126,239,191,189,239,191,189,239,191,189,47,239,191,189,0,57,71,239,191,189,239,191,189,66,239,191,189,125,239,191,189,39,239,191,189,239,191,189,40,239,191,189,239,191,189,102,98,239,191,189,64,239,191,189,239,191,189,64,17,31,239,191,189,239,191,189,16,5,239,191,189,239,191,189,121,68,96,107,18,239,191,189,50,239,191,189,69,239,191,189,21,51,96,239,191,189,62,78,239,191,189,239,191,189,108,24,55,9,86,239,191,189,8,239,191,189,40,39,11,239,191,189,49,220,129,12,239,191,189,98,46,239,191,189,239,191,189,239,191,189,51,123,95,98,107,239,191,189,239,191,189,55,239,191,189,59,239,191,189,67,239,191,189,239,191,189,74,111,239,191,189,98,82,239,191,189,10,239,191,189,101,239,191,189,57,239,191,189,83,43,239,191,189,32,55,31,127,228,187,169,239,191,189,67,77,239,191,189,239,191,189,70,239,191,189,33,239,191,189,66,239,191,189,239,191,189,62,115,124,90,91,89,40,239,191,189,239,191,189,239,191,189,50,8,239,191,189,11,5,26,239,191,189,35,25,239,191,189,239,191,189,239,191,189,239,191,189,109,20,113,239,191,189,239,191,189,12,68,239,191,189,239,191,189,20,239,191,189,239,191,189,104,239,191,189,239,191,189,239,191,189,37,239,191,189,28,239,191,189,61,17,69,84,239,191,189,64,239,191,189,239,191,189,239,191,189,40,239,191,189,52,120,120,14,69,239,191,189,99,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,30,239,191,189,117,239,191,189,95,239,191,189,67,113,21,239,191,189,92,239,191,189,28,239,191,189,239,191,189,86,239,191,189,239,191,189,239,191,189,118,93,116,239,150,151,239,191,189,111,87,239,191,189,239,191,189,70,239,191,189,81,90,199,162,64,239,191,189,106,53,90,239,191,189,98,239,191,189,239,191,189,118,239,191,189,239,191,189,239,191,189,61,10,0,110,125,239,191,189,239,191,189,239,191,189,239,191,189,19,239,191,189,239,191,189,239,191,189,239,191,189,26,118,239,191,189,125,239,191,189,239,191,189,239,191,189,22,239,191,189,239,191,189,239,191,189,28,239,191,189,18,52,239,191,189,32,13,116,120,76,239,191,189,69,102,212,189,29,239,191,189,96,239,191,189,239,191,189,110,239,191,189,71,68,42,239,191,189,10,4,239,191,189,38,79,117,239,191,189,96,1,239,191,189,121,239,191,189,239,191,189,119,16,115,239,191,189,42,48,32,239,191,189,5,239,191,189,239,191,189,222,165,239,191,189,239,191,189,239,191,189,239,191,189,38,3,111,123,37,239,191,189,208,143,115,239,191,189,239,191,189,123,101,239,191,189,110,239,191,189,239,191,189,62,29,19,10,80,5,45,15,113,113,239,191,189,239,191,189,64,205,137,65,239,191,189,116,239,191,189,239,191,189,118,239,191,189,96,239,191,189,52,73,81,114,79,239,191,189,55,71,239,191,189,239,191,189,239,191,189,220,174,239,191,189,239,191,189,66,107,239,191,189,47,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,36,29,239,191,189,239,191,189,2,199,146,239,191,189,122,28,239,191,189,219,157,33,124,239,191,189,239,191,189,0,239,191,189,31,239,191,189,239,191,189,239,191,189,118,93,239,191,189,239,191,189,91,96,239,191,189,115,205,152,127,43,239,191,189,60,72,239,191,189,239,191,189,26,42,52,239,191,189,65,103,205,146,239,191,189,102,239,191,189,239,191,189,239,191,189,239,191,189,69,239,191,189,39,239,191,189,239,191,189,118,5,55,81,239,191,189,239,191,189,239,191,189,66,29,239,191,189,239,191,189,92,94,81,1,5,239,191,189,93,60,52,239,191,189,239,191,189,47,239,191,189,239,191,189,239,191,189,239,191,189,14,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,216,170,17,82,37,239,191,189,239,191,189,13,10,239,191,189,110,239,191,189,239,191,189,239,191,189,52,239,191,189,79,239,191,189,239,191,189,213,143,87,239,191,189,239,191,189,239,191,189,66,239,191,189,92,239,191,189,239,191,189,239,191,189,23,75,34,239,191,189,239,191,189,42,239,191,189,239,191,189,15,239,191,189,239,191,189,239,191,189,89,69,82,107,118,101,239,191,189,105,239,191,189,239,191,189,239,191,189,82,239,191,189,20,28,115,239,191,189,239,191,189,62,23,102,239,191,189,86,113,112,26,239,191,189,239,191,189,109,219,166,65,239,191,189,104,59,239,191,189,239,191,189,239,191,189,108,239,191,189,50,58,239,191,189,239,191,189,106,239,191,189,39,239,191,189,14,110,239,191,189,68,84,239,191,189,239,191,189,118,239,191,189,239,191,189,239,191,189,91,239,191,189,3,239,191,189,30,219,159,94,25,239,191,189,109,239,191,189,11,94,71,239,191,189,44,35,239,191,189,6,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,111,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,17,18,46,63,239,191,189,239,191,189,239,191,189,113,13,197,160,239,191,189,239,191,189,239,191,189,13,239,191,189,92,83,44,239,191,189,89,104,2,80,239,191,189,50,120,239,191,189,239,191,189,57,19,239,191,189,56,48,77,52,239,191,189,239,191,189,7,59,48,239,191,189,27,18,118,9,125,239,191,189,208,131,114,239,191,189,211,129,239,191,189,15,239,191,189,67,110,65,24,239,191,189,212,178,239,191,189,80,239,191,189,239,191,189,239,191,189,239,191,189,111,239,191,189,36,239,191,189,41,239,191,189,239,191,189,62,239,191,189,40,239,191,189,239,191,189,30,239,191,189,239,191,189,24,101,239,191,189,239,191,189,37,215,168,20,239,191,189,34,239,191,189,17,105,30,38,87,239,191,189,6,239,191,189,19,239,191,189,111,52,88,38,40,239,191,189,239,191,189,70,69,68,100,29,16,239,191,189,239,191,189,4,239,191,189,17,199,186,93,124,123,113,125,32,94,239,191,189,20,239,191,189,54,239,191,189,239,191,189,239,191,189,48,86,126,239,191,189,56,239,191,189,206,128,239,191,189,73,239,191,189,89,67,58,82,239,191,189,82,239,191,189,76,239,191,189,17,239,191,189,220,181,239,191,189,127,96,117,49,119,45,122,17,50,239,191,189,239,191,189,116,239,191,189,239,191,189,239,191,189,239,191,189,220,158,49,125,35,239,191,189,36,126,33,122,95,86,23,239,191,189,120,121,239,191,189,80,239,191,189,239,191,189,89,79,102,28,121,71,17,127,239,191,189,126,239,191,189,239,191,189,110,239,191,189,53,25,239,191,189,55,239,191,189,239,191,189,59,239,191,189,15,239,191,189,239,191,189,35,239,191,189,239,191,189,66,52,239,191,189,102,31,83,239,191,189,239,191,189,56,21,3,239,191,189,203,164,217,163,239,191,189,97,239,191,189,28,97,94,206,145,239,191,189,23,77,98,64,105,78,86,78,118,60,111,239,191,189,53,239,191,189,26,104,239,191,189,239,191,189,52,239,191,189,214,150,29,107,29,108,59,239,191,189,57,239,191,189,101,26,239,191,189,7,6,47,75,239,191,189,199,173,239,191,189,85,104,105,209,170,239,191,189,204,179,239,191,189,125,57,92,30,64,239,191,189,69,239,191,189,76,239,191,189,26,112,60,87,9,239,191,189,239,191,189,239,191,189,20,56,92,17,205,134,29,239,191,189,46,239,191,189,239,191,189,114,239,191,189,110,41,239,191,189,103,43,239,191,189,126,239,191,189,79,239,191,189,118,239,191,189,239,191,189,29,24,16,95,26,17,239,191,189,239,191,189,122,92,107,107,239,191,189,1,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,239,191,189,70,239,191,189,239,191,189,239,191,189,239,191,189,25,15,239,191,189,78,239,191,189,239,191,189,239,191,189,239,191,189,104,30,83,126,96,62,239,191,189,239,191,189,35,239,191,189,239,191,189,239,191,189,125,9,239,191,189,88,57,239,191,189,239,191,189,239,191,189,239,191,189,92,31,239,191,189,33,239,191,189,239,191,189,239,191,189,44,118,220,130,239,191,189,1,85,106,61,239,191,189,120,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,29,16,239,191,189,6,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,41,12,239,191,189,239,191,189,93,105,239,191,189,195,131,239,191,189,30,61,6,124,239,191,189,92,27,124,48,51,239,191,189,63,239,191,189,42,99,16,91,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,73,107,108,95,15,22,49,20,239,191,189,239,191,189,239,191,189,10,32,82,239,191,189,239,191,189,47,239,191,189,239,191,189,27,239,191,189,71,239,191,189,109,76,13,13,239,191,189,76,239,191,189,39,239,191,189,49,239,191,189,105,239,191,189,28,32,29,239,191,189,42,239,191,189,84,239,191,189,6,59,66,81,92,239,191,189,65,239,191,189,239,191,189,239,191,189,1,239,191,189,239,191,189,19,2,8,97,239,191,189,7,239,191,189,42,239,191,189,123,239,191,189,43,19,239,191,189,239,191,189,91,239,191,189,110,126,239,191,189,70,239,191,189,239,191,189,126,239,191,189,73,239,191,189,239,191,189,120,239,191,189,103,88,239,191,189,9,30,20,94,98,209,165,88,46,239,191,189,89,239,191,189,49,239,191,189,239,191,189,19,94,46,239,191,189,25,19,239,191,189,47,61,239,191,189,216,190,239,191,189,51,95,197,128,88,122,9,118,239,191,189,239,191,189,92,239,191,189,216,146,24,18,113,221,190,239,191,189,56,239,191,189,26,239,191,189,239,191,189,63,239,191,189,60,239,191,189,239,191,189,122,239,191,189,19,239,191,189,36,239,191,189,239,191,189,239,191,189,71,239,191,189,124,55,124,97,239,191,189,239,191,189,64,239,191,189,239,191,189,29,239,191,189,6,26,239,191,189,239,191,189,80,69,61,239,191,189,25,239,191,189,205,135,239,191,189,239,191,189,210,136,239,191,189,109,73,24,239,191,189,239,191,189,7,70,0,102,239,191,189,239,191,189,239,191,189,239,191,189,28,239,191,189,239,191,189,9,116,111,24,76,212,136,239,191,189,44,46,217,175,239,191,189,239,191,189,239,191,189,0,111,68,19,106,4,52,112,19,239,191,189,239,191,189,233,140,136,239,191,189,26,239,191,189,68,239,191,189,239,191,189,13,98,112,239,191,189,239,191,189,239,191,189,92,108,103,45,239,191,189,81,239,191,189,217,181,109,239,191,189,9,29,239,191,189,239,191,189,3,92,99,239,191,189,239,191,189,239,191,189,51,91,19,25,106,239,191,189,4,209,157,239,191,189,239,191,189,122,239,191,189,239,191,189,239,191,189,9,239,191,189,30,62,63,239,191,189,239,191,189,99,95,239,191,189,39,239,191,189,239,191,189,10,6,13,239,191,189,239,191,189,41,16,83,19,44,87,239,191,189,8,23,110,37,239,191,189,115,37,12,239,191,189,118,68,125,239,191,189,73,95,239,191,189,239,191,189,98,67,16,34,199,150,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,239,191,189,239,191,189,231,154,170,239,191,189,239,191,189,58,40,239,191,189,239,191,189,239,191,189,16,239,191,189,239,191,189,117,3,122,239,191,189,23,239,191,189,239,191,189,239,191,189,70,239,191,189,65,239,191,189,125,239,191,189,194,141,239,191,189,84,67,239,191,189,82,239,191,189,16,239,191,189,239,191,189,4,121,58,239,191,189,76,75,239,191,189,6,40,43,239,191,189,107,239,191,189,239,191,189,23,32,9,239,191,189,23,105,58,119,239,191,189,101,37,28,239,191,189,239,191,189,239,191,189,118,239,191,189,239,191,189,239,191,189,39,19,37,119,88,239,191,189,54,239,191,189,123,84,88,239,191,189,34,239,191,189,44,239,191,189,72,239,191,189,239,191,189,54,104,239,191,189,239,191,189,239,191,189,106,48,239,191,189,239,191,189,26,239,191,189,76,214,144,239,191,189,239,191,189,242,169,176,166,239,191,189,223,190,34,92,107,2,40,206,159,103,45,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,239,191,189,109,239,191,189,97,239,191,189,12,35,239,191,189,102,39,58,218,152,78,24,87,239,191,189,105,103,104,103,7,239,191,189,74,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,5,239,191,189,6,239,191,189,239,191,189,115,64,93,239,191,189,80,72,112,194,166,101,239,191,189,239,191,189,239,191,189,239,191,189,77,19,29,239,191,189,57,239,191,189,239,191,189,114,84,239,191,189,29,239,191,189,69,239,191,189,239,191,189,34,239,191,189,239,191,189,239,191,189,113,239,191,189,23,76,239,191,189,23,31,239,191,189,69,84,239,191,189,36,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,28,1,239,191,189,99,239,191,189,3,239,191,189,42,239,191,189,239,191,189,239,191,189,239,191,189,41,58,54,239,191,189,52,239,191,189,26,239,191,189,124,29,110,239,191,189,45,239,191,189,72,8,239,191,189,58,17,6,239,191,189,85,239,191,189,43,239,191,189,239,191,189,112,28,45,27,239,191,189,41,107,49,239,191,189,239,191,189,103,243,179,182,178,239,191,189,239,191,189,239,191,189,125,36,53,196,187,239,191,189,76,74,239,191,189,239,191,189,33,212,150,11,40,239,191,189,113,239,191,189,99,96,78,69,30,239,191,189,67,239,191,189,239,191,189,239,191,189,91,83,239,191,189,239,191,189,239,191,189,121,79,239,191,189,97,108,206,133,125,239,191,189,16,239,191,189,44,92,239,191,189,4,68,239,191,189,69,62,239,191,189,55,5,57,239,191,189,53,31,98,239,191,189,80,95,45,31,239,191,189,93,239,191,189,95,197,156,239,191,189,239,191,189,239,191,189,239,191,189,103,239,191,189,122,89,68,31,239,191,189,22,239,191,189,239,191,189,118,44,117,116,22,43,43,77,108,239,191,189,45,87,239,191,189,87,239,191,189,27,239,191,189,127,24,79,239,191,189,239,191,189,112,239,191,189,77,6,239,191,189,239,191,189,66,63,57,239,191,189,127,239,191,189,239,191,189,239,191,189,58,73,239,191,189,112,239,191,189,37,5,239,191,189,15,9,239,191,189,1,69,4,222,151,239,191,189,94,239,191,189,96,5,239,191,189,239,191,189,36,79,113,41,239,191,189,239,191,189,98,1,239,191,189,23,239,191,189,91,228,168,165,239,191,189,239,191,189,214,142,68,54,218,150,62,97,239,191,189,59,32,239,191,189,71,239,191,189,100,239,191,189,117,33,55,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,82,45,36,239,191,189,239,191,189,221,184,66,239,191,189,46,71,239,191,189,239,191,189,116,239,191,189,239,191,189,33,82,91,66,34,103,52,123,239,191,189,111,239,191,189,110,239,191,189,67,49,22,239,191,189,104,239,191,189,104,25,239,191,189,239,191,189,94,104,239,191,189,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,91,16,97,82,29,100,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,67,86,74,239,191,189,87,239,191,189,49,239,191,189,239,191,189,115,239,191,189,66,99,239,191,189,217,133,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,18,121,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,111,113,56,239,191,189,7,29,239,191,189,86,239,191,189,239,191,189,21,0,239,191,189,239,191,189,63,30,239,191,189,32,239,191,189,38,50,119,74,239,191,189,90,124,55,62,117,30,56,239,191,189,239,191,189,81,3,96,9,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,113,239,191,189,239,191,189,27,41,58,239,191,189,239,191,189,215,174,239,191,189,105,239,191,189,38,112,81,239,191,189,239,191,189,225,152,179,104,53,109,239,191,189,239,191,189,21,56,42,206,134,207,172,239,191,189,239,191,189,114,97,13,3,239,191,189,47,97,239,191,189,53,239,191,189,11,58,239,191,189,101,107,239,191,189,239,191,189,239,191,189,50,239,191,189,96,239,191,189,239,191,189,68,92,239,191,189,239,191,189,239,191,189,239,191,189,14,239,191,189,75,77,113,239,191,189,41,216,163,47,104,82,105,0,239,191,189,217,164,123,210,191,239,191,189,239,191,189,77,122,27,239,191,189,239,191,189,239,191,189,200,167,4,120,239,191,189,30,38,77,239,191,189,239,191,189,40,239,191,189,65,239,191,189,86,82,239,191,189,107,239,191,189,239,191,189,39,106,239,191,189,50,239,191,189,239,191,189,239,191,189,77,239,191,189,49,239,191,189,30,117,15,239,191,189,43,239,191,189,75,239,191,189,56,25,239,191,189,83,75,126,239,191,189,53,239,191,189,239,191,189,239,191,189,239,191,189,14,239,191,189,93,239,191,189,209,148,239,191,189,55,239,191,189,0,239,191,189,85,104,239,191,189,239,191,189,91,39,239,191,189,205,171,239,191,189,239,191,189,81,0,222,152,111,239,191,189,77,83,33,239,191,189,42,16,239,191,189,12,89,90,239,191,189,19,54,55,43,239,191,189,239,191,189,239,191,189,14,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,12,239,191,189,239,191,189,239,191,189,88,76,86,239,191,189,239,191,189,57,42,88,239,191,189,59,79,239,191,189,127,239,191,189,239,191,189,239,191,189,239,191,189,38,5,224,182,189,239,191,189,114,239,191,189,75,239,191,189,46,239,191,189,77,239,191,189,29,101,94,126,239,191,189,223,139,93,239,191,189,211,137,239,191,189,211,139,4,86,239,191,189,100,239,191,189,239,191,189,239,191,189,239,191,189,19,70,239,191,189,111,239,191,189,44,239,191,189,239,191,189,239,191,189,127,239,191,189,239,191,189,49,104,32,119,239,191,189,239,191,189,44,239,191,189,67,12,44,239,191,189,8,239,191,189,124,239,191,189,239,191,189,239,191,189,68,104,239,191,189,52,82,24,239,191,189,87,239,191,189,94,239,191,189,39,239,191,189,10,57,61,89,239,191,189,53,117,239,191,189,211,184,29,239,191,189,6,25,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,50,58,44,239,191,189,239,191,189,22,8,239,191,189,120,239,191,189,239,191,189,239,191,189,27,52,33,239,191,189,203,141,239,191,189,60,52,112,239,191,189,239,191,189,239,191,189,75,239,191,189,54,239,191,189,239,191,189,239,191,189,77,63,239,191,189,239,191,189,13,102,91,239,191,189,44,239,191,189,28,13,239,191,189,48,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,110,239,191,189,205,171,239,191,189,239,191,189,124,54,111,239,191,189,10,92,239,191,189,239,191,189,30,239,191,189,219,142,81,239,191,189,101,49,91,239,191,189,90,24,98,239,191,189,112,2,121,6,61,84,239,191,189,223,128,239,191,189,239,191,189,5,239,191,189,47,239,191,189,34,239,191,189,239,191,189,71,203,144,239,191,189,67,239,191,189,82,54,60,115,57,80,239,191,189,103,239,191,189,239,191,189,109,81,3,31,52,53,63,31,70,239,191,189,76,21,53,69,239,191,189,112,212,133,27,239,191,189,239,191,189,82,53,95,239,191,189,29,83,107,70,67,195,158,239,191,189,105,126,105,30,102,95,17,239,191,189,113,105,93,90,60,1,239,191,189,239,191,189,239,191,189,123,95,75,239,191,189,239,191,189,26,27,239,191,189,52,22,239,191,189,239,191,189,239,191,189,2,35,239,191,189,59,239,191,189,239,191,189,54,81,110,37,9,111,111,239,191,189,239,191,189,5,239,191,189,27,92,239,191,189,125,239,191,189,99,82,31,239,191,189,99,78,122,49,72,48,239,191,189,239,191,189,102,57,239,191,189,1,53,47,239,191,189,119,13,58,66,75,118,49,67,239,191,189,239,191,189,239,191,189,239,191,189,59,90,58,239,191,189,91,27,72,99,239,191,189,239,191,189,61,239,191,189,217,182,214,130,239,191,189,89,239,191,189,239,191,189,44,239,191,189,6,239,191,189,40,16,239,191,189,13,49,10,219,169,78,239,191,189,125,61,44,121,80,239,191,189,239,191,189,204,181,239,191,189,239,191,189,93,104,239,191,189,239,191,189,239,191,189,239,191,189,69,239,191,189,20,88,64,84,127,239,191,189,75,71,58,49,239,191,189,239,191,189,239,191,189,239,191,189,46,56,239,191,189,85,36,8,239,191,189,239,191,189,96,68,102,239,191,189,203,167,61,109,239,191,189,101,239,191,189,239,191,189,57,81,61,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,216,164,59,239,191,189,57,93,6,89,239,191,189,60,21,27,239,191,189,239,191,189,239,191,189,203,164,9,205,175,120,101,239,191,189,84,239,191,189,239,191,189,239,191,189,239,191,189,65,4,39,70,239,191,189,107,194,175,239,191,189,109,239,191,189,102,40,239,191,189,90,239,191,189,29,88,64,239,191,189,24,22,96,239,191,189,239,191,189,239,191,189,96,63,118,122,92,98,87,239,191,189,63,56,239,191,189,239,191,189,51,239,191,189,44,239,191,189,239,191,189,55,41,102,239,191,189,239,191,189,11,12,54,239,191,189,239,191,189,239,191,189,239,191,189,42,239,191,189,239,191,189,97,239,191,189,11,239,191,189,56,239,191,189,16,126,15,120,239,191,189,33,239,191,189,72,36,239,191,189,239,191,189,51,70,41,107,126,101,239,191,189,52,106,67,215,167,239,191,189,31,20,239,191,189,92,115,90,239,191,189,239,191,189,239,191,189,79,38,239,191,189,87,13,239,191,189,239,191,189,66,239,191,189,95,9,239,191,189,93,239,191,189,122,39,239,191,189,116,63,78,239,191,189,60,56,239,191,189,109,88,239,191,189,239,191,189,109,239,191,189,239,191,189,43,37,239,191,189,239,191,189,2,239,191,189,39,87,239,191,189,74,39,85,120,239,191,189,239,191,189,239,191,189,47,26,53,239,191,189,239,191,189,69,90,239,191,189,19,239,191,189,239,191,189,239,191,189,93,92,239,191,189,24,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,119,102,239,191,189,28,97,3,239,191,189,239,191,189,239,191,189,56,239,191,189,239,191,189,97,114,55,68,239,191,189,239,191,189,202,169,239,191,189,21,239,191,189,61,239,191,189,239,191,189,239,191,189,81,60,239,191,189,239,191,189,239,191,189,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,86,54,44,45,239,191,189,55,30,239,191,189,239,191,189,212,175,239,191,189,239,191,189,44,10,97,123,126,121,239,191,189,21,85,239,191,189,239,191,189,120,239,191,189,239,191,189,31,239,191,189,105,111,27,2,115,114,239,191,189,239,191,189,79,5,239,191,189,239,191,189,4,239,191,189,104,51,239,191,189,4,239,191,189,55,65,83,86,80,3,65,239,191,189,80,35,239,191,189,117,239,191,189,27,52,101,239,191,189,239,191,189,83,121,44,120,239,191,189,90,16,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,21,25,239,191,189,239,191,189,50,239,191,189,52,239,191,189,43,239,191,189,15,239,191,189,239,191,189,126,3,239,191,189,212,130,6,239,191,189,239,191,189,39,239,191,189,91,239,191,189,49,63,65,239,191,189,115,206,140,239,191,189,31,75,239,191,189,239,191,189,80,40,31,239,191,189,0,239,191,189,239,191,189,39,35,62,9,239,191,189,47,239,191,189,5,239,191,189,239,191,189,60,111,86,0,81,239,191,189,240,183,181,131,239,191,189,90,95,239,191,189,239,191,189,239,191,189,50,239,191,189,239,191,189,239,191,189,38,239,191,189,119,239,191,189,9,28,2,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,48,15,89,239,191,189,79,239,191,189,44,239,191,189,72,62,97,239,191,189,239,191,189,195,134,50,239,191,189,239,191,189,4,66,239,191,189,239,191,189,83,239,191,189,94,239,191,189,53,239,191,189,82,31,22,239,191,189,199,145,47,239,191,189,125,63,239,191,189,7,239,191,189,239,191,189,222,170,22,239,191,189,59,88,124,106,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,104,239,191,189,97,64,87,239,191,189,60,239,191,189,41,40,239,191,189,51,60,239,191,189,222,181,239,191,189,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,116,239,191,189,116,51,28,239,191,189,239,191,189,239,191,189,27,239,191,189,239,191,189,101,89,84,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,196,157,239,191,189,223,135,239,191,189,239,191,189,239,191,189,127,19,127,220,155,239,191,189,200,182,239,191,189,239,191,189,83,23,239,191,189,239,191,189,242,154,189,143,239,191,189,82,239,191,189,52,39,83,239,191,189,239,191,189,24,239,191,189,50,239,191,189,239,191,189,29,239,191,189,70,216,155,34,239,160,144,239,191,189,14,239,191,189,59,239,191,189,106,239,191,189,239,191,189,26,34,239,191,189,16,239,191,189,101,74,239,191,189,44,64,223,172,239,191,189,3,239,191,189,239,191,189,239,191,189,239,191,189,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,37,89,24,239,191,189,81,34,44,23,239,191,189,239,191,189,122,112,69,239,191,189,239,191,189,110,239,191,189,15,239,191,189,25,11,6,114,239,191,189,239,191,189,110,239,191,189,28,239,191,189,86,25,239,191,189,107,37,239,191,189,20,84,239,191,189,239,191,189,239,191,189,108,239,191,189,239,191,189,77,239,191,189,239,191,189,239,191,189,46,239,191,189,239,191,189,239,191,189,2,34,239,191,189,26,83,239,191,189,54,209,179,239,191,189,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,239,191,189,90,90,239,191,189,239,191,189,105,217,173,239,191,189,53,37,43,239,191,189,239,191,189,97,239,191,189,239,191,189,239,191,189,22,200,138,10,63,111,29,239,191,189,239,191,189,40,112,239,191,189,49,239,191,189,4,202,180,239,191,189,53,42,14,239,191,189,73,51,239,191,189,29,127,10,239,191,189,239,191,189,58,111,41,239,191,189,74,239,191,189,79,239,191,189,26,239,191,189,112,197,147,239,191,189,60,239,191,189,3,56,39,17,46,239,191,189,86,239,191,189,239,191,189,125,126,86,120,33,239,191,189,19,239,191,189,6,239,191,189,1,96,88,239,191,189,70,122,239,191,189,74,239,191,189,73,5,239,191,189,239,191,189,239,191,189,25,70,239,191,189,227,161,173,24,239,191,189,34,239,191,189,62,239,191,189,84,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,70,239,191,189,12,239,191,189,109,119,239,191,189,95,239,191,189,7,239,191,189,48,239,191,189,101,64,239,191,189,239,191,189,53,239,191,189,8,239,191,189,239,191,189,239,191,189,78,92,73,121,214,188,239,191,189,110,239,191,189,2,76,90,239,191,189,11,239,191,189,239,191,189,84,89,239,191,189,110,239,191,189,83,44,27,39,239,191,189,81,239,191,189,117,239,191,189,239,191,189,21,239,191,189,19,239,191,189,239,191,189,35,239,191,189,14,239,191,189,239,191,189,239,191,189,46,239,191,189,10,102,239,191,189,69,239,191,189,239,191,189,239,191,189,239,191,189,37,239,191,189,239,191,189,48,45,81,84,107,50,239,191,189,239,191,189,41,55,239,191,189,239,191,189,77,8,239,191,189,86,75,239,191,189,125,88,91,239,191,189,239,191,189,28,27,116,123,239,191,189,64,42,44,239,191,189,68,239,191,189,94,239,191,189,239,191,189,239,191,189,55,239,191,189,239,191,189,8,5,95,98,239,191,189,239,191,189,61,239,191,189,42,98,239,191,189,118,239,191,189,51,239,191,189,53,57,239,191,189,239,191,189,3,239,191,189,239,191,189,10,26,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,82,239,191,189,38,239,191,189,122,239,191,189,61,6,21,239,191,189,58,239,191,189,239,191,189,35,42,77,119,127,64,7,239,191,189,89,6,84,72,31,4,239,191,189,82,239,191,189,239,191,189,51,239,191,189,76,59,239,191,189,122,239,191,189,17,121,239,191,189,239,191,189,55,239,191,189,52,239,191,189,102,127,78,50,18,126,239,191,189,27,239,191,189,239,191,189,239,191,189,113,91,224,170,179,239,191,189,239,191,189,7,239,191,189,15,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,47,239,191,189,239,191,189,239,191,189,206,132,19,107,239,191,189,20,4,78,239,191,189,239,191,189,48,239,191,189,83,73,239,191,189,8,100,49,239,191,189,72,4,65,239,191,189,55,239,191,189,239,191,189,239,191,189,239,191,189,53,82,79,42,123,56,35,76,94,239,191,189,65,239,191,189,239,191,189,70,55,82,239,191,189,107,239,191,189,239,191,189,26,239,191,189,91,239,191,189,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,15,239,191,189,239,191,189,25,108,101,6,39,27,38,99,239,191,189,117,239,191,189,58,239,191,189,239,191,189,9,118,108,56,11,239,191,189,105,65,239,191,189,81,107,36,123,239,191,189,239,191,189,239,191,189,39,50,16,47,45,239,191,189,239,191,189,239,191,189,67,104,127,239,191,189,73,239,191,189,13,239,191,189,239,191,189,239,191,189,239,191,189,70,111,239,191,189,3,239,191,189,22,239,191,189,118,20,239,191,189,3,239,191,189,239,191,189,239,191,189,39,77,239,191,189,41,105,239,191,189,63,239,191,189,239,191,189,239,191,189,106,239,191,189,239,191,189,15,67,239,191,189,102,125,18,74,19,239,191,189,46,118,25,85,84,239,191,189,42,64,239,191,189,239,191,189,239,191,189,33,239,191,189,80,90,84,109,68,239,191,189,200,154,96,47,99,239,191,189,103,208,178,239,191,189,33,125,239,191,189,20,239,191,189,239,191,189,239,191,189,80,59,239,191,189,124,239,191,189,239,191,189,123,239,191,189,239,191,189,118,239,191,189,18,15,206,141,74,239,191,189,239,191,189,70,239,191,189,116,239,191,189,7,119,239,191,189,239,191,189,113,89,13,239,191,189,239,191,189,239,191,189,3,50,89,11,75,230,135,180,239,191,189,10,239,191,189,239,191,189,37,239,191,189,18,239,191,189,239,191,189,201,182,239,191,189,109,239,191,189,239,191,189,239,191,189,239,191,189,5,16,50,10,118,200,145,49,239,191,189,14,239,191,189,117,239,191,189,239,191,189,24,70,239,191,189,35,106,239,191,189,43,81,25,239,191,189,239,191,189,93,68,45,1,58,105,107,91,98,70,239,191,189,84,239,191,189,27,66,94,239,191,189,63,123,52,57,121,202,158,121,239,191,189,119,92,1,126,239,191,189,239,191,189,239,191,189,71,25,239,191,189,100,48,239,191,189,239,191,189,114,25,31,239,191,189,66,239,191,189,239,191,189,7,40,239,191,189,127,17,239,191,189,96,239,191,189,239,191,189,121,239,191,189,239,191,189,95,239,191,189,15,90,239,191,189,221,183,97,2,239,191,189,239,191,189,123,239,191,189,239,191,189,239,191,189,32,89,18,91,239,191,189,239,191,189,112,51,99,239,191,189,239,191,189,90,61,239,191,189,53,9,213,168,76,239,191,189,99,239,191,189,60,37,101,59,239,191,189,4,106,239,191,189,4,125,198,157,104,239,191,189,103,51,0,109,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,121,239,191,189,205,180,37,239,191,189,72,35,95,97,29,239,191,189,239,191,189,76,107,108,239,191,189,239,191,189,239,191,189,36,239,191,189,239,191,189,87,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,49,239,191,189,239,191,189,87,51,239,191,189,239,191,189,239,191,189,54,239,191,189,125,49,53,239,191,189,62,6,108,122,60,239,191,189,1,21,17,54,239,191,189,239,191,189,239,191,189,239,191,189,74,34,18,239,191,189,42,104,239,191,189,215,153,198,185,20,239,191,189,239,191,189,53,20,67,239,191,189,239,191,189,239,191,189,97,80,62,40,101,239,191,189,239,191,189,28,118,239,191,189,108,102,239,191,189,239,191,189,19,239,191,189,239,191,189,7,204,177,103,108,239,191,189,239,191,189,39,40,122,239,191,189,239,191,189,239,191,189,34,239,191,189,239,191,189,121,239,191,189,239,191,189,239,191,189,29,54,239,191,189,239,191,189,96,8,90,82,33,239,191,189,239,191,189,33,112,73,239,191,189,34,63,239,191,189,239,191,189,103,61,239,191,189,98,60,120,239,191,189,74,239,191,189,239,191,189,109,239,191,189,47,239,191,189,239,191,189,239,191,189,65,239,191,189,6,100,75,110,6,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,127,21,74,239,191,189,239,191,189,106,41,239,191,189,239,191,189,106,15,239,191,189,44,53,76,239,191,189,109,239,191,189,239,191,189,98,239,191,189,127,77,239,191,189,55,70,239,191,189,126,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,54,239,191,189,102,23,67,30,239,191,189,59,239,191,189,239,191,189,79,65,239,191,189,239,191,189,60,111,239,191,189,92,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,36,85,26,239,191,189,117,38,239,191,189,239,191,189,71,239,191,189,12,239,191,189,112,239,191,189,239,191,189,31,213,133,17,85,92,239,191,189,239,191,189,239,191,189,23,239,191,189,122,239,191,189,239,191,189,98,239,191,189,239,191,189,84,65,239,191,189,40,34,239,191,189,21,239,191,189,239,191,189,8,127,239,191,189,82,239,191,189,239,191,189,18,60,239,191,189,15,239,191,189,53,75,45,239,191,189,104,227,188,171,14,28,239,191,189,239,191,189,37,239,191,189,28,72,6,239,191,189,239,191,189,0,239,191,189,239,191,189,119,239,191,189,18,239,191,189,239,191,189,239,191,189,222,156,239,191,189,239,191,189,239,191,189,118,8,20,0,239,191,189,62,239,191,189,105,239,191,189,239,191,189,36,239,191,189,239,191,189,124,239,191,189,239,191,189,11,70,3,15,239,191,189,239,191,189,63,239,191,189,118,30,239,191,189,23,48,127,55,239,191,189,41,95,19,51,6,54,115,55,239,191,189,25,239,191,189,239,191,189,95,87,72,61,239,191,189,239,191,189,86,239,191,189,239,191,189,12,239,191,189,52,239,191,189,80,73,32,239,191,189,82,102,73,239,191,189,239,191,189,112,29,239,191,189,105,5,15,239,191,189,239,191,189,92,107,36,117,80,30,214,145,32,93,40,239,191,189,17,29,109,239,191,189,95,239,191,189,239,191,189,83,61,64,239,191,189,102,221,147,239,191,189,42,239,191,189,239,191,189,239,191,189,70,25,239,191,189,239,191,189,239,191,189,15,94,239,191,189,43,74,103,50,8,32,94,239,191,189,82,239,191,189,239,191,189,9,79,35,60,239,191,189,28,239,191,189,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,117,20,110,239,191,189,239,191,189,0,239,191,189,239,191,189,8,239,191,189,14,239,191,189,69,126,218,148,121,239,191,189,125,35,239,191,189,99,239,191,189,239,191,189,81,239,191,189,66,239,191,189,119,239,191,189,119,62,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,98,51,239,191,189,14,12,120,25,239,191,189,50,10,14,18,239,191,189,239,191,189,239,191,189,239,191,189,22,126,57,116,239,191,189,106,94,110,50,7,239,191,189,52,239,191,189,239,191,189,239,191,189,122,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,216,173,95,82,108,109,239,191,189,101,127,80,239,191,189,8,239,191,189,109,239,191,189,35,239,191,189,239,191,189,101,239,191,189,239,191,189,113,239,191,189,239,191,189,239,191,189,17,239,191,189,44,239,191,189,239,191,189,18,87,84,239,191,189,239,191,189,20,122,239,191,189,239,191,189,239,191,189,205,135,69,65,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,42,239,191,189,57,239,191,189,239,191,189,103,41,239,191,189,95,239,191,189,91,239,191,189,56,239,191,189,97,239,191,189,96,239,191,189,66,14,27,239,191,189,116,239,191,189,12,239,191,189,62,108,74,239,191,189,239,191,189,239,191,189,106,239,191,189,14,239,191,189,114,107,62,99,99,26,22,239,191,189,223,149,5,239,191,189,95,239,191,189,239,191,189,239,191,189,103,239,191,189,14,22,239,191,189,34,239,191,189,126,239,191,189,69,21,95,239,191,189,19,205,175,83,9,62,239,191,189,223,171,1,239,191,189,239,191,189,239,191,189,119,239,191,189,90,13,83,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,18,79,239,191,189,239,191,189,120,29,4,239,191,189,239,191,189,239,191,189,239,191,189,86,239,191,189,85,239,191,189,239,191,189,60,239,191,189,6,12,97,239,191,189,63,100,239,191,189,239,191,189,55,239,191,189,112,22,239,191,189,21,239,191,189,91,239,191,189,239,191,189,101,239,191,189,103,239,191,189,239,191,189,239,191,189,32,22,239,191,189,239,191,189,202,183,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,43,16,42,38,239,191,189,239,191,189,66,70,239,191,189,58,239,191,189,106,52,94,239,191,189,64,117,32,120,15,100,239,191,189,40,239,191,189,11,239,191,189,127,37,40,239,191,189,239,191,189,100,52,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,34,239,191,189,88,239,191,189,7,14,239,191,189,56,239,191,189,50,101,239,191,189,117,26,33,102,29,29,20,239,191,189,77,54,112,239,191,189,239,191,189,5,212,160,239,191,189,85,239,191,189,78,75,239,191,189,239,191,189,48,39,81,32,239,191,189,239,191,189,44,239,191,189,239,191,189,101,239,191,189,197,133,94,65,239,191,189,239,191,189,99,58,239,191,189,239,191,189,37,239,191,189,239,191,189,2,57,56,103,81,239,191,189,22,239,191,189,239,191,189,49,239,191,189,63,239,191,189,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,46,239,191,189,64,78,65,239,191,189,239,191,189,18,239,191,189,17,7,239,191,189,10,98,103,30,75,239,191,189,239,191,189,58,12,79,90,6,83,109,1,208,156,239,191,189,86,239,191,189,65,71,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,215,152,114,42,239,191,189,239,191,189,53,239,191,189,239,191,189,100,239,191,189,69,94,92,111,239,191,189,222,152,57,239,191,189,212,141,239,191,189,118,24,239,191,189,121,239,191,189,239,191,189,239,191,189,113,92,96,239,191,189,239,191,189,239,191,189,37,239,191,189,79,30,239,191,189,36,108,239,191,189,239,191,189,239,191,189,49,239,191,189,117,239,191,189,94,239,191,189,239,191,189,34,73,239,191,189,239,191,189,17,239,191,189,62,121,34,17,239,191,189,239,191,189,239,191,189,111,239,191,189,55,239,191,189,239,191,189,239,191,189,239,191,189,78,104,123,239,191,189,239,191,189,239,191,189,71,239,191,189,78,19,18,239,191,189,112,108,239,191,189,239,191,189,19,1,17,239,191,189,100,19,121,59,239,191,189,40,239,191,189,5,62,239,191,189,239,191,189,239,191,189,19,239,191,189,239,191,189,52,67,239,191,189,12,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,116,98,239,191,189,219,153,239,191,189,239,191,189,239,191,189,55,239,191,189,85,2,125,226,153,134,239,191,189,15,20,123,55,92,239,191,189,195,189,91,239,191,189,239,191,189,27,19,239,191,189,20,239,191,189,239,191,189,51,239,191,189,239,191,189,41,239,191,189,89,239,191,189,239,191,189,239,191,189,239,191,189,49,197,164,114,111,239,191,189,239,191,189,239,191,189,101,116,24,239,191,189,8,30,61,25,209,189,35,90,65,106,239,191,189,211,144,239,191,189,106,239,191,189,239,191,189,114,239,191,189,239,191,189,56,239,191,189,239,191,189,231,129,171,101,239,191,189,42,50,26,27,239,191,189,239,191,189,11,103,63,0,6,239,191,189,239,191,189,73,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,89,47,239,191,189,1,239,191,189,27,208,146,239,191,189,50,79,18,239,191,189,239,191,189,23,55,212,146,215,163,239,191,189,3,123,239,191,189,108,239,191,189,30,239,191,189,195,189,239,191,189,239,191,189,239,191,189,113,114,239,191,189,118,24,239,191,189,239,191,189,28,120,239,191,189,13,239,191,189,239,191,189,239,191,189,1,50,239,191,189,3,99,239,191,189,59,70,86,239,191,189,18,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,65,108,70,75,28,28,239,191,189,239,191,189,15,239,191,189,239,191,189,53,68,110,239,191,189,119,239,191,189,28,239,191,189,52,239,191,189,239,191,189,27,239,191,189,43,27,70,100,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,239,191,189,68,239,191,189,239,191,189,239,191,189,21,239,191,189,71,84,207,179,17,18,69,25,30,2,239,191,189,37,239,191,189,49,239,191,189,81,239,191,189,32,0,239,191,189,93,57,91,21,77,239,191,189,112,239,191,189,239,191,189,239,191,189,30,55,239,191,189,101,113,56,75,239,191,189,26,9,1,74,99,239,191,189,1,20,15,239,191,189,23,239,191,189,239,191,189,239,191,189,239,191,189,64,113,14,239,191,189,239,191,189,102,239,191,189,239,191,189,239,191,189,101,84,239,191,189,127,52,239,191,189,124,5,239,191,189,5,239,191,189,239,191,189,18,213,170,20,57,124,206,138,239,191,189,209,144,82,101,239,191,189,99,63,239,191,189,118,239,191,189,104,93,239,191,189,15,239,191,189,88,239,191,189,239,191,189,239,191,189,239,191,189,31,239,191,189,239,191,189,107,94,56,78,239,191,189,45,9,239,191,189,25,239,191,189,239,191,189,83,86,25,64,91,61,115,97,113,239,191,189,119,46,239,191,189,221,188,239,191,189,239,191,189,239,191,189,239,191,189,212,177,7,101,239,191,189,239,191,189,43,239,191,189,239,191,189,73,239,191,189,239,191,189,68,64,239,191,189,121,1,123,239,191,189,239,191,189,93,122,239,191,189,23,94,239,191,189,48,113,112,239,191,189,104,239,191,189,41,239,191,189,239,191,189,75,239,191,189,31,239,191,189,48,76,239,191,189,24,239,191,189,239,191,189,51,239,191,189,58,100,239,191,189,40,7,100,239,191,189,89,239,191,189,239,191,189,7,5,102,239,191,189,239,191,189,4,239,191,189,34,239,191,189,26,112,239,191,189,46,15,91,239,191,189,86,17,239,191,189,49,99,239,191,189,66,55,11,46,96,97,239,191,189,239,191,189,118,239,191,189,90,239,191,189,26,67,119,203,129,87,239,191,189,76,24,124,239,191,189,54,239,191,189,239,191,189,22,14,239,191,189,101,78,239,191,189,239,191,189,68,35,239,191,189,117,239,191,189,96,239,191,189,42,239,191,189,239,191,189,239,191,189,239,191,189,37,65,239,191,189,239,191,189,70,115,77,110,23,239,191,189,198,183,213,130,239,191,189,74,117,23,17,239,191,189,239,191,189,71,239,191,189,32,239,191,189,85,239,191,189,239,191,189,1,34,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,104,47,57,239,191,189,1,80,239,191,189,239,191,189,92,202,160,83,239,191,189,118,239,191,189,106,239,191,189,78,55,239,191,189,107,239,191,189,239,191,189,239,191,189,239,191,189,85,109,239,191,189,18,68,19,114,239,191,189,8,239,191,189,69,239,191,189,31,239,191,189,74,239,191,189,58,239,191,189,42,239,191,189,87,43,239,191,189,109,43,239,191,189,84,43,239,191,189,31,239,191,189,70,72,41,239,191,189,227,151,137,24,239,191,189,46,86,196,148,111,239,191,189,239,191,189,239,191,189,239,191,189,35,49,201,190,59,112,41,239,191,189,230,170,191,70,85,239,191,189,6,239,191,189,239,191,189,239,191,189,239,191,189,103,35,239,191,189,239,191,189,115,239,191,189,1,103,239,191,189,239,191,189,239,191,189,207,146,63,239,191,189,239,191,189,18,239,191,189,13,239,191,189,239,191,189,0,16,239,191,189,109,239,191,189,239,191,189,1,219,142,112,239,191,189,239,191,189,239,191,189,0,239,191,189,30,74,239,191,189,111,239,191,189,239,191,189,70,239,191,189,44,6,239,191,189,239,191,189,239,191,189,119,239,191,189,61,93,102,18,13,60,124,239,191,189,0,239,191,189,102,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,108,239,191,189,62,89,73,239,191,189,19,239,191,189,92,239,191,189,239,191,189,239,191,189,48,223,154,239,191,189,109,239,191,189,239,191,189,30,239,191,189,116,239,191,189,239,191,189,19,111,54,239,191,189,239,191,189,239,191,189,239,191,189,124,76,76,239,191,189,239,191,189,56,46,239,191,189,83,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,207,172,204,148,60,102,44,239,191,189,239,191,189,239,191,189,18,112,70,218,137,239,191,189,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,80,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,98,239,191,189,55,28,85,239,191,189,239,191,189,239,191,189,102,96,119,80,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,25,20,239,191,189,239,191,189,239,191,189,239,191,189,98,41,239,191,189,91,49,239,191,189,239,191,189,239,191,189,69,239,191,189,52,52,239,191,189,83,239,191,189,58,239,191,189,239,191,189,36,96,60,239,191,189,239,191,189,46,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,5,98,239,191,189,66,239,191,189,43,239,191,189,46,239,191,189,239,191,189,98,239,191,189,10,239,191,189,98,18,117,239,191,189,239,191,189,22,239,191,189,218,143,239,191,189,99,70,239,191,189,239,191,189,239,191,189,221,168,58,116,239,191,189,239,191,189,96,239,191,189,239,191,189,196,134,239,191,189,73,239,191,189,239,191,189,239,191,189,239,191,189,1,239,191,189,86,239,191,189,239,191,189,93,239,191,189,239,191,189,17,239,191,189,68,239,191,189,86,239,191,189,239,191,189,239,191,189,4,239,191,189,239,191,189,120,239,191,189,23,239,191,189,2,122,239,191,189,51,88,70,239,191,189,71,239,191,189,47,111,68,14,75,239,191,189,92,74,239,191,189,239,191,189,239,191,189,73,27,14,66,223,143,67,68,239,191,189,67,15,94,239,191,189,239,191,189,84,32,239,191,189,42,82,116,102,64,239,191,189,90,239,191,189,239,191,189,65,27,88,111,239,191,189,239,191,189,94,102,239,191,189,107,239,191,189,83,239,191,189,2,102,105,77,31,17,89,15,239,191,189,201,183,31,62,68,82,8,104,239,191,189,91,62,239,191,189,2,41,239,191,189,239,191,189,39,239,191,189,239,191,189,239,191,189,109,239,191,189,9,214,137,114,0,239,191,189,101,58,239,191,189,71,239,191,189,74,81,239,191,189,80,239,191,189,239,191,189,11,93,126,239,191,189,63,21,34,0,60,239,191,189,122,239,191,189,239,191,189,239,191,189,118,239,191,189,20,239,191,189,73,239,191,189,239,191,189,81,48,2,122,239,191,189,239,191,189,205,184,239,191,189,239,191,189,125,239,191,189,59,239,191,189,239,191,189,239,191,189,239,191,189,103,113,239,191,189,239,191,189,239,191,189,66,70,121,98,239,191,189,61,239,191,189,7,239,191,189,196,186,45,124,60,239,191,189,30,85,72,101,239,191,189,239,191,189,122,239,191,189,77,59,239,191,189,23,239,191,189,77,96,239,191,189,60,22,56,63,125,106,239,191,189,239,191,189,239,191,189,124,239,191,189,38,239,191,189,13,114,239,191,189,16,239,191,189,18,41,93,239,191,189,239,191,189,199,163,43,39,38,37,14,127,239,191,189,99,43,239,191,189,101,4,122,239,191,189,239,191,189,81,239,191,189,11,122,239,191,189,125,239,191,189,45,40,87,239,191,189,239,191,189,58,55,48,70,33,113,239,191,189,82,66,239,191,189,116,239,191,189,239,191,189,239,191,189,194,154,28,13,239,191,189,239,191,189,3,39,216,146,239,191,189,122,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,59,239,191,189,110,44,239,191,189,239,191,189,67,239,191,189,239,191,189,77,239,191,189,239,191,189,86,38,125,21,239,191,189,239,191,189,17,27,239,191,189,60,239,191,189,19,94,239,191,189,91,239,191,189,239,191,189,117,239,191,189,73,210,166,239,191,189,96,112,239,191,189,239,191,189,113,239,191,189,40,239,191,189,239,191,189,127,88,59,239,191,189,239,191,189,239,191,189,107,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,90,239,191,189,93,79,239,191,189,239,191,189,104,239,191,189,94,239,191,189,239,191,189,125,28,239,191,189,36,78,239,191,189,81,114,239,191,189,42,239,191,189,6,98,239,191,189,239,191,189,239,191,189,10,239,191,189,96,239,191,189,115,239,191,189,239,191,189,21,239,191,189,65,33,45,50,79,22,33,239,191,189,239,191,189,70,239,191,189,25,70,103,72,239,191,189,239,191,189,121,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,23,93,239,191,189,239,191,189,239,191,189,61,239,191,189,118,239,191,189,92,13,126,36,63,53,20,114,92,239,191,189,80,239,191,189,239,191,189,195,144,24,93,239,191,189,50,21,78,239,191,189,70,104,58,27,239,191,189,111,35,239,191,189,77,116,106,239,191,189,239,191,189,90,239,191,189,109,239,191,189,67,123,84,108,35,104,42,82,239,191,189,22,239,191,189,97,239,191,189,239,191,189,96,64,93,239,191,189,22,239,191,189,36,67,239,191,189,79,113,239,191,189,239,191,189,94,58,239,191,189,53,78,239,191,189,49,239,191,189,239,191,189,239,191,189,34,0,16,239,191,189,87,89,61,239,191,189,239,191,189,239,191,189,9,74,239,191,189,239,191,189,239,191,189,239,191,189,92,239,191,189,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,23,239,191,189,239,191,189,113,89,239,191,189,239,191,189,69,202,163,21,239,191,189,91,239,191,189,75,17,239,191,189,239,191,189,8,84,239,191,189,76,239,191,189,239,191,189,108,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,116,68,239,191,189,239,191,189,119,239,191,189,23,105,34,66,5,239,191,189,239,191,189,0,18,239,191,189,239,191,189,18,211,131,119,40,115,63,239,191,189,5,239,191,189,239,191,189,4,79,49,26,239,191,189,239,191,189,239,191,189,86,239,191,189,106,239,191,189,93,239,191,189,18,234,138,177,239,191,189,239,191,189,239,191,189,239,191,189,54,2,239,191,189,239,191,189,239,191,189,205,137,34,56,239,191,189,17,239,191,189,95,61,239,191,189,239,191,189,239,191,189,239,191,189,21,86,239,191,189,239,191,189,239,191,189,65,118,239,191,189,101,61,239,191,189,239,191,189,67,239,191,189,239,191,189,239,191,189,76,239,191,189,101,239,191,189,239,191,189,32,51,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,51,239,191,189,239,191,189,1,239,191,189,125,31,126,122,68,63,84,103,75,57,239,191,189,239,191,189,239,191,189,53,121,111,106,239,191,189,112,76,77,54,239,191,189,29,202,129,239,191,189,22,239,191,189,9,239,191,189,239,191,189,239,191,189,50,239,191,189,79,239,191,189,103,37,90,95,239,191,189,239,191,189,239,191,189,15,239,191,189,66,12,100,239,191,189,20,108,239,191,189,94,71,239,191,189,96,239,191,189,239,191,189,65,62,239,191,189,65,73,239,191,189,239,191,189,55,3,239,191,189,32,239,191,189,125,74,239,191,189,239,191,189,97,239,191,189,46,239,191,189,239,191,189,239,191,189,10,45,63,239,191,189,68,70,56,239,191,189,47,239,191,189,34,239,191,189,239,191,189,28,239,191,189,239,191,189,239,191,189,239,191,189,92,239,191,189,63,89,67,49,239,191,189,33,239,191,189,112,239,191,189,8,50,239,191,189,49,239,191,189,52,239,191,189,2,110,239,191,189,109,239,191,189,24,239,191,189,49,118,239,191,189,102,239,191,189,101,239,191,189,239,191,189,57,94,239,191,189,123,239,191,189,239,191,189,14,67,34,239,191,189,239,191,189,3,38,239,191,189,45,115,93,239,191,189,223,144,67,62,239,191,189,38,239,191,189,18,239,191,189,239,191,189,239,191,189,239,191,189,10,24,43,239,191,189,239,191,189,91,10,239,191,189,239,191,189,239,191,189,42,239,191,189,239,191,189,54,20,93,117,72,100,8,239,191,189,61,239,191,189,239,191,189,111,26,84,239,191,189,239,191,189,82,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,194,150,23,82,101,30,239,191,189,24,239,191,189,4,239,191,189,17,120,239,191,189,114,91,239,191,189,0,239,191,189,218,146,239,191,189,38,65,239,191,189,239,191,189,233,161,166,43,85,120,41,98,239,191,189,239,191,189,77,239,191,189,239,191,189,103,239,191,189,239,191,189,79,107,239,191,189,67,99,58,239,191,189,40,239,191,189,239,191,189,57,17,104,239,191,189,111,213,156,239,191,189,53,239,191,189,114,127,239,191,189,12,239,191,189,21,239,191,189,239,191,189,13,239,191,189,120,28,58,18,239,191,189,239,191,189,239,191,189,115,68,239,191,189,239,191,189,126,118,239,191,189,63,24,239,191,189,239,191,189,66,119,25,239,191,189,49,239,191,189,14,207,188,239,191,189,90,77,79,31,26,239,191,189,26,28,239,191,189,86,20,239,191,189,40,41,120,239,191,189,58,239,191,189,9,239,191,189,239,191,189,239,191,189,27,239,191,189,126,239,191,189,239,191,189,239,191,189,3,239,191,189,239,191,189,37,24,239,191,189,95,239,191,189,99,239,191,189,239,191,189,35,65,239,191,189,217,141,79,239,191,189,82,239,191,189,106,26,239,191,189,208,187,239,191,189,49,83,239,191,189,239,191,189,239,191,189,108,49,65,82,52,239,191,189,3,17,239,191,189,39,239,191,189,239,191,189,75,69,239,191,189,239,191,189,119,35,239,191,189,70,239,191,189,91,64,42,239,191,189,25,46,105,239,191,189,239,191,189,11,1,239,191,189,239,191,189,57,239,191,189,239,191,189,81,239,191,189,239,191,189,75,239,191,189,209,130,210,137,123,239,191,189,17,239,191,189,239,191,189,48,239,191,189,62,239,191,189,17,239,191,189,22,105,27,239,191,189,239,191,189,239,191,189,239,191,189,28,239,191,189,239,191,189,100,11,239,191,189,239,191,189,38,126,25,239,191,189,21,239,191,189,239,191,189,88,95,239,191,189,239,191,189,88,239,191,189,12,239,191,189,81,239,191,189,4,40,1,239,191,189,239,191,189,79,239,191,189,91,22,102,59,239,191,189,22,126,90,106,239,191,189,239,191,189,239,191,189,67,205,134,51,239,191,189,9,125,239,191,189,65,239,191,189,65,69,18,95,227,182,166,61,239,191,189,239,191,189,72,239,191,189,115,86,29,239,191,189,239,191,189,38,239,191,189,41,121,41,239,191,189,92,55,239,191,189,239,191,189,42,239,191,189,11,107,113,109,104,37,239,191,189,196,183,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,239,191,189,19,19,220,160,239,191,189,239,191,189,239,191,189,67,239,191,189,52,23,239,191,189,239,191,189,40,64,239,191,189,123,94,239,191,189,94,239,191,189,75,10,49,39,239,191,189,208,138,90,102,35,109,239,191,189,97,35,239,191,189,239,191,189,94,21,239,191,189,45,239,191,189,52,13,105,15,239,191,189,90,239,191,189,71,239,191,189,239,191,189,110,36,239,191,189,9,239,191,189,121,239,191,189,37,50,239,191,189,93,17,239,191,189,239,191,189,83,4,239,191,189,239,191,189,239,191,189,239,191,189,212,175,239,191,189,239,191,189,239,191,189,35,239,191,189,239,191,189,65,48,239,191,189,30,43,239,191,189,127,61,91,239,191,189,69,16,239,191,189,239,191,189,123,68,76,35,99,204,187,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,239,191,189,122,38,51,239,191,189,239,191,189,8,239,191,189,1,74,62,239,191,189,14,29,22,239,191,189,44,239,191,189,239,191,189,93,239,191,189,52,100,85,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,239,191,189,53,82,239,191,189,85,239,191,189,12,121,239,191,189,13,61,84,239,191,189,239,191,189,239,191,189,122,15,116,239,191,189,25,239,191,189,22,208,128,239,191,189,239,191,189,15,43,120,110,117,239,191,189,112,92,83,116,239,191,189,239,191,189,239,191,189,239,191,189,215,186,106,72,117,107,66,83,239,191,189,14,239,191,189,84,239,191,189,239,191,189,55,239,191,189,100,239,191,189,239,191,189,239,191,189,1,239,191,189,239,191,189,239,191,189,239,191,189,82,81,108,239,191,189,25,239,191,189,239,191,189,65,207,172,239,191,189,10,93,239,191,189,239,191,189,84,106,239,191,189,33,23,239,191,189,36,239,191,189,15,8,1,0,57,239,191,189,239,191,189,221,176,239,191,189,239,191,189,2,107,110,239,191,189,107,239,191,189,67,103,0,239,191,189,199,151,3,207,140,239,191,189,239,191,189,117,116,239,191,189,45,239,191,189,92,239,191,189,23,239,191,189,74,22,239,191,189,239,191,189,33,214,151,239,191,189,239,191,189,239,191,189,239,191,189,83,239,191,189,239,191,189,239,191,189,51,65,106,239,191,189,106,105,34,239,191,189,58,116,239,191,189,239,191,189,87,15,214,154,239,191,189,40,239,191,189,81,49,4,239,191,189,239,191,189,107,21,239,191,189,239,191,189,239,191,189,239,191,189,33,78,113,3,41,86,239,191,189,239,191,189,49,239,191,189,239,191,189,219,156,239,191,189,70,239,191,189,97,239,191,189,37,84,50,43,239,191,189,107,117,46,239,191,189,239,191,189,239,191,189,84,197,135,239,191,189,123,83,64,80,83,239,191,189,239,191,189,239,191,189,23,93,86,103,239,191,189,122,239,191,189,239,191,189,239,191,189,116,239,191,189,239,191,189,239,191,189,239,191,189,5,239,191,189,239,191,189,239,191,189,4,87,239,191,189,27,108,239,191,189,33,89,5,239,191,189,13,239,191,189,102,239,191,189,52,239,191,189,14,30,198,162,46,239,191,189,239,191,189,239,191,189,19,80,239,191,189,93,239,191,189,75,239,191,189,239,191,189,239,191,189,239,191,189,65,26,239,191,189,239,191,189,115,70,239,191,189,117,16,239,191,189,239,191,189,239,191,189,64,239,191,189,239,191,189,6,239,191,189,112,51,23,239,191,189,89,60,32,89,239,191,189,51,239,191,189,99,57,72,7,239,191,189,126,87,26,239,191,189,29,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,35,68,15,239,191,189,239,191,189,239,191,189,83,84,239,191,189,239,191,189,18,239,191,189,239,191,189,220,151,239,191,189,19,239,191,189,17,239,191,189,93,239,191,189,239,191,189,194,155,239,191,189,106,239,191,189,197,179,20,29,108,66,239,191,189,20,239,191,189,55,96,239,191,189,239,191,189,239,191,189,80,51,108,112,60,239,191,189,239,191,189,239,191,189,109,96,239,191,189,22,239,191,189,83,86,77,96,239,191,189,49,121,239,191,189,3,239,191,189,239,191,189,123,239,191,189,222,130,93,239,191,189,66,74,239,191,189,105,127,239,191,189,86,43,107,239,191,189,84,239,191,189,70,239,191,189,118,85,239,191,189,239,191,189,239,191,189,53,239,191,189,109,239,191,189,108,100,76,239,191,189,119,239,191,189,239,191,189,3,109,239,191,189,30,93,38,50,212,155,239,191,189,52,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,126,37,239,191,189,52,239,191,189,39,3,213,179,239,191,189,5,50,33,239,191,189,54,239,191,189,239,191,189,80,239,191,189,239,191,189,239,191,189,25,47,114,239,191,189,35,62,239,191,189,239,191,189,15,70,206,142,239,191,189,239,191,189,207,171,239,191,189,63,69,239,191,189,72,239,191,189,239,191,189,45,239,191,189,121,24,239,191,189,239,191,189,239,191,189,239,191,189,7,9,80,101,239,191,189,239,191,189,95,239,191,189,239,191,189,96,239,191,189,61,54,239,191,189,109,239,191,189,102,31,30,17,72,37,76,111,239,191,189,69,52,239,191,189,38,239,191,189,39,83,113,199,132,99,239,191,189,239,191,189,40,76,239,191,189,91,45,88,4,100,239,191,189,239,191,189,12,50,239,191,189,239,191,189,239,191,189,195,191,239,191,189,4,239,191,189,103,61,42,239,191,189,195,188,239,191,189,81,239,191,189,111,30,10,82,239,191,189,239,191,189,239,191,189,114,239,191,189,239,191,189,239,191,189,107,41,77,54,239,191,189,239,191,189,12,239,191,189,239,191,189,239,191,189,7,239,191,189,94,239,191,189,114,239,191,189,33,239,191,189,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,2,239,191,189,11,239,191,189,239,191,189,80,239,191,189,239,191,189,16,239,191,189,61,239,191,189,239,191,189,89,207,176,62,239,191,189,29,104,126,239,191,189,239,191,189,25,11,239,191,189,239,191,189,83,239,191,189,100,239,191,189,239,191,189,239,191,189,87,239,191,189,19,0,239,191,189,239,191,189,94,51,239,191,189,78,20,52,239,191,189,44,79,201,191,81,23,122,31,96,86,44,239,191,189,27,239,191,189,239,191,189,100,239,191,189,210,172,41,239,191,189,239,191,189,239,191,189,239,191,189,91,239,191,189,239,191,189,52,239,191,189,93,239,191,189,239,191,189,16,239,191,189,122,239,191,189,239,191,189,18,239,191,189,22,239,191,189,239,191,189,68,239,191,189,13,72,239,191,189,215,179,79,239,191,189,66,239,191,189,209,143,239,191,189,14,14,239,191,189,101,239,191,189,239,191,189,239,191,189,239,191,189,13,239,191,189,239,191,189,12,239,191,189,239,191,189,239,191,189,49,239,191,189,239,191,189,239,191,189,122,211,163,19,239,191,189,239,191,189,122,239,191,189,92,91,62,239,191,189,239,191,189,123,239,191,189,29,58,91,239,191,189,96,74,90,239,191,189,239,191,189,54,203,188,239,191,189,8,16,239,191,189,77,239,191,189,22,58,107,239,191,189,239,191,189,105,27,62,48,239,191,189,76,239,191,189,34,123,239,191,189,124,239,191,189,58,239,191,189,70,47,121,239,191,189,85,239,191,189,28,239,191,189,198,179,76,104,239,191,189,11,239,191,189,64,77,58,239,191,189,239,191,189,80,68,12,42,77,113,239,191,189,239,191,189,64,208,139,25,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,200,141,214,182,239,191,189,85,239,191,189,239,191,189,73,91,239,191,189,79,59,239,191,189,65,63,239,191,189,120,1,35,79,85,239,191,189,24,116,239,191,189,239,191,189,39,50,239,191,189,108,105,239,191,189,126,239,191,189,239,191,189,239,191,189,208,172,239,191,189,69,3,22,239,191,189,88,4,58,73,239,191,189,6,11,239,191,189,239,191,189,114,115,239,191,189,239,191,189,66,31,94,99,239,191,189,239,191,189,239,191,189,46,99,239,191,189,17,239,191,189,93,239,191,189,239,191,189,18,239,191,189,9,81,239,191,189,29,27,239,191,189,239,191,189,239,191,189,88,239,191,189,97,239,191,189,40,12,17,3,36,239,191,189,239,191,189,239,191,189,30,239,191,189,104,39,239,191,189,239,191,189,71,40,239,191,189,125,36,62,239,191,189,33,104,33,219,159,38,239,191,189,239,191,189,239,191,189,88,239,191,189,100,58,239,191,189,239,191,189,239,191,189,56,83,63,239,191,189,239,191,189,116,239,191,189,80,38,57,239,191,189,40,219,131,34,60,7,239,191,189,239,191,189,40,239,191,189,103,239,191,189,239,191,189,59,118,239,191,189,104,239,191,189,239,191,189,40,36,68,239,191,189,239,191,189,11,239,191,189,239,191,189,56,52,79,239,191,189,101,15,93,125,110,107,40,50,12,15,104,239,191,189,239,191,189,80,239,191,189,239,191,189,57,114,13,239,191,189,108,239,191,189,106,3,239,191,189,239,191,189,35,48,106,239,191,189,239,191,189,239,191,189,53,103,239,191,189,239,191,189,59,239,191,189,7,45,64,239,191,189,239,191,189,25,239,191,189,239,191,189,239,191,189,119,239,191,189,239,191,189,239,191,189,39,104,239,191,189,195,165,89,239,191,189,72,239,191,189,239,191,189,92,87,117,127,239,191,189,198,182,239,191,189,123,106,239,191,189,239,191,189,22,80,71,6,239,191,189,116,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,75,239,191,189,72,239,191,189,46,239,191,189,70,17,98,239,191,189,239,191,189,2,63,90,71,239,191,189,239,191,189,239,191,189,84,18,239,191,189,239,191,189,239,191,189,62,16,102,100,239,191,189,239,191,189,239,191,189,0,125,206,164,31,239,191,189,94,37,239,191,189,0,239,191,189,105,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,37,25,239,191,189,239,191,189,239,191,189,90,18,10,239,191,189,239,191,189,93,239,191,189,95,239,191,189,239,191,189,68,51,239,191,189,58,76,99,239,191,189,239,191,189,239,191,189,17,239,191,189,70,69,89,239,191,189,239,191,189,36,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,83,119,31,49,99,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,27,93,56,239,191,189,239,191,189,85,31,239,191,189,12,239,191,189,239,191,189,239,191,189,84,24,239,191,189,121,239,191,189,41,0,239,191,189,52,239,191,189,117,100,15,17,239,191,189,239,191,189,239,191,189,83,208,161,239,191,189,215,148,110,239,191,189,239,191,189,239,191,189,121,64,239,191,189,239,191,189,28,239,191,189,34,7,239,191,189,239,191,189,222,140,239,191,189,8,78,46,239,191,189,212,153,239,191,189,239,191,189,239,191,189,16,239,191,189,3,42,51,125,239,191,189,34,239,191,189,239,191,189,59,111,50,239,191,189,76,239,191,189,71,127,239,191,189,239,191,189,239,191,189,117,67,239,191,189,239,191,189,239,191,189,101,239,191,189,23,100,99,239,191,189,239,191,189,48,239,191,189,239,191,189,239,191,189,92,239,191,189,239,191,189,125,92,35,81,52,239,191,189,90,239,191,189,98,239,191,189,25,239,191,189,19,239,191,189,76,67,239,191,189,45,239,191,189,239,191,189,30,239,191,189,118,85,216,142,67,239,191,189,101,239,191,189,84,35,74,26,118,103,81,239,191,189,200,178,46,239,191,189,36,239,191,189,74,239,191,189,239,191,189,88,239,191,189,44,197,178,239,191,189,100,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,239,191,189,123,239,191,189,56,239,191,189,80,239,191,189,31,239,191,189,239,191,189,239,191,189,101,239,191,189,197,153,118,239,191,189,11,16,239,191,189,239,191,189,239,191,189,239,191,189,107,239,191,189,113,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,122,33,31,239,191,189,8,89,81,83,118,239,191,189,57,239,191,189,239,191,189,94,96,239,191,189,239,191,189,239,191,189,107,239,191,189,239,191,189,103,229,168,182,239,191,189,95,239,191,189,239,191,189,239,191,189,67,239,191,189,100,110,83,67,239,191,189,45,239,191,189,29,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,15,13,46,239,191,189,239,191,189,239,191,189,40,239,191,189,239,191,189,18,60,118,239,191,189,78,239,191,189,239,191,189,205,191,239,191,189,239,191,189,239,191,189,67,10,29,239,191,189,57,78,96,11,239,191,189,239,191,189,239,191,189,212,170,82,123,239,191,189,9,89,99,221,173,65,6,98,76,67,36,239,191,189,239,191,189,239,191,189,90,3,72,239,191,189,3,16,239,191,189,239,191,189,239,191,189,38,239,191,189,69,66,239,191,189,12,239,191,189,239,191,189,43,239,191,189,239,191,189,55,74,239,191,189,239,191,189,239,191,189,22,126,114,239,191,189,41,109,33,239,191,189,239,191,189,239,191,189,79,107,239,191,189,25,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,124,239,191,189,239,191,189,36,34,239,191,189,239,191,189,53,57,239,191,189,88,125,239,191,189,239,191,189,239,191,189,239,191,189,82,239,191,189,239,191,189,127,239,191,189,88,239,191,189,7,239,191,189,239,191,189,239,191,189,3,239,191,189,239,191,189,81,239,191,189,50,85,239,191,189,239,191,189,55,239,191,189,125,57,239,191,189,239,191,189,21,112,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,33,84,239,191,189,239,191,189,36,6,227,135,147,239,191,189,239,191,189,239,191,189,108,239,191,189,239,191,189,75,100,2,18,92,239,191,189,37,84,239,191,189,25,67,79,103,0,239,191,189,239,191,189,4,58,36,48,71,114,121,239,191,189,239,191,189,83,70,239,191,189,66,118,19,239,191,189,239,191,189,239,191,189,80,239,191,189,239,191,189,239,191,189,6,36,239,191,189,0,63,239,191,189,239,191,189,123,239,191,189,239,191,189,13,239,191,189,91,71,120,116,239,191,189,239,191,189,121,115,9,61,59,17,10,5,239,191,189,239,191,189,239,191,189,239,191,189,22,20,24,52,0,51,71,50,239,191,189,239,191,189,239,191,189,216,191,239,191,189,52,239,191,189,97,79,110,120,239,191,189,91,121,239,191,189,239,191,189,239,191,189,239,191,189,53,239,191,189,70,48,239,191,189,239,191,189,239,191,189,239,191,189,107,39,71,68,45,239,191,189,52,209,138,48,125,69,239,191,189,24,78,56,55,22,55,119,239,191,189,239,191,189,54,24,115,88,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,25,59,239,191,189,239,191,189,26,11,64,239,191,189,106,239,191,189,239,191,189,239,191,189,105,123,17,28,111,13,239,191,189,239,191,189,101,65,239,191,189,239,191,189,46,239,191,189,213,168,59,111,239,191,189,79,239,191,189,43,239,191,189,239,191,189,239,191,189,30,43,239,191,189,101,12,45,239,191,189,105,239,191,189,239,191,189,70,239,191,189,84,239,191,189,0,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,106,41,47,27,27,125,239,191,189,79,111,239,191,189,239,191,189,239,191,189,239,191,189,10,58,88,19,27,239,191,189,127,217,143,198,176,26,19,79,76,118,239,191,189,239,191,189,30,51,239,191,189,107,59,239,191,189,17,239,191,189,239,191,189,217,168,239,191,189,87,239,191,189,101,239,191,189,239,191,189,13,91,239,191,189,24,107,96,239,191,189,99,126,1,8,45,239,191,189,239,191,189,199,176,239,191,189,239,191,189,218,158,239,191,189,123,2,239,191,189,239,191,189,239,191,189,49,239,191,189,111,215,181,32,88,62,27,239,191,189,60,5,199,146,239,191,189,239,191,189,94,16,239,191,189,239,191,189,81,239,191,189,14,239,191,189,69,239,191,189,24,87,14,239,191,189,239,191,189,22,126,239,191,189,46,34,239,191,189,76,239,191,189,239,191,189,73,239,191,189,5,116,239,191,189,239,191,189,72,13,39,29,239,191,189,239,191,189,239,191,189,84,98,239,191,189,199,146,11,8,0,48,59,239,191,189,37,239,191,189,2,99,110,239,191,189,196,164,239,191,189,8,17,9,51,239,191,189,239,191,189,239,191,189,74,239,191,189,239,191,189,239,191,189,28,239,191,189,112,239,191,189,120,44,20,64,239,191,189,239,191,189,24,239,191,189,38,78,6,239,191,189,239,191,189,67,101,44,85,239,191,189,76,80,239,191,189,239,191,189,239,191,189,85,56,239,191,189,73,120,239,191,189,9,229,145,150,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,21,239,191,189,239,191,189,239,191,189,239,191,189,234,170,164,93,239,191,189,198,176,36,123,216,152,58,239,191,189,29,239,191,189,10,57,69,33,96,78,239,191,189,239,191,189,194,169,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,40,239,191,189,78,11,239,191,189,26,39,67,52,108,27,28,30,103,239,191,189,31,239,191,189,32,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,0,24,239,191,189,27,54,239,191,189,199,185,27,239,191,189,18,89,87,17,42,239,191,189,17,1,239,191,189,239,191,189,50,239,191,189,108,90,16,113,239,191,189,60,60,19,15,239,191,189,46,239,191,189,11,239,191,189,127,11,13,96,239,191,189,97,1,53,85,62,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,110,105,115,239,191,189,63,11,239,191,189,239,191,189,125,7,239,191,189,122,43,239,191,189,6,239,191,189,111,6,239,191,189,79,209,139,54,5,210,170,239,191,189,70,239,191,189,124,114,239,191,189,73,239,191,189,239,191,189,63,0,72,113,25,239,191,189,239,191,189,92,239,191,189,19,33,239,191,189,87,37,239,191,189,239,191,189,23,31,239,191,189,239,191,189,116,58,56,26,239,191,189,68,214,139,103,239,191,189,107,92,109,239,191,189,48,5,239,191,189,27,53,239,191,189,239,191,189,42,239,191,189,239,191,189,30,239,191,189,239,191,189,239,191,189,219,160,239,191,189,239,191,189,107,5,239,191,189,45,239,191,189,239,191,189,13,110,239,191,189,83,239,191,189,239,191,189,114,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,85,239,191,189,15,121,239,191,189,239,191,189,84,84,239,191,189,239,191,189,239,191,189,203,170,239,191,189,81,43,61,126,239,191,189,96,239,191,189,35,239,191,189,239,191,189,23,194,172,84,239,191,189,95,239,191,189,223,182,7,92,239,191,189,239,191,189,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,87,239,191,189,239,191,189,27,239,191,189,73,239,191,189,78,125,97,239,191,189,239,191,189,49,239,191,189,55,97,239,191,189,37,0,239,191,189,65,239,191,189,239,191,189,20,239,191,189,96,127,53,239,191,189,239,191,189,239,191,189,239,191,189,37,85,239,191,189,48,58,239,191,189,239,191,189,11,239,191,189,16,79,125,44,61,42,28,239,191,189,239,191,189,202,137,239,191,189,239,191,189,239,191,189,239,191,189,120,85,201,148,95,239,191,189,117,239,191,189,239,191,189,239,191,189,39,7,38,41,45,239,191,189,4,48,239,191,189,79,239,191,189,101,54,99,119,0,24,98,95,51,239,191,189,7,85,115,46,239,191,189,65,45,239,191,189,239,191,189,8,239,191,189,239,191,189,77,239,191,189,198,161,91,239,191,189,239,191,189,91,3,239,191,189,239,191,189,19,30,102,29,94,239,191,189,18,75,112,20,31,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,127,239,191,189,71,102,239,191,189,239,191,189,110,239,191,189,58,119,7,239,191,189,69,108,4,202,147,26,239,191,189,239,191,189,16,81,52,239,191,189,54,39,56,239,191,189,5,18,239,191,189,239,191,189,239,191,189,23,239,191,189,54,68,120,70,53,239,191,189,92,36,9,11,118,42,239,191,189,27,239,191,189,31,239,191,189,8,239,191,189,239,191,189,46,239,191,189,81,47,239,191,189,239,191,189,239,191,189,239,191,189,39,239,191,189,55,239,191,189,46,239,191,189,205,134,27,239,191,189,78,239,191,189,45,43,239,191,189,239,191,189,239,191,189,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,81,239,191,189,239,191,189,239,191,189,72,239,191,189,239,191,189,93,239,191,189,239,191,189,57,239,191,189,121,239,191,189,22,78,96,4,11,239,191,189,239,191,189,18,0,108,103,111,239,191,189,30,239,191,189,52,9,111,0,239,191,189,239,191,189,46,239,191,189,239,191,189,50,200,133,17,47,239,191,189,22,70,0,122,106,239,191,189,239,191,189,13,5,62,239,191,189,50,239,191,189,239,191,189,239,191,189,102,124,7,239,191,189,48,100,120,30,52,31,239,191,189,49,239,191,189,239,191,189,113,1,239,191,189,122,81,41,239,191,189,239,191,189,118,239,191,189,68,77,98,239,191,189,239,191,189,53,239,191,189,9,239,191,189,56,98,9,10,102,239,191,189,239,191,189,239,191,189,239,191,189,70,75,239,191,189,239,191,189,28,239,191,189,61,220,184,57,239,191,189,83,239,191,189,5,43,239,191,189,239,191,189,2,125,127,239,191,189,35,239,191,189,55,239,191,189,239,191,189,104,239,191,189,106,239,191,189,239,191,189,91,239,191,189,94,43,239,191,189,107,69,102,97,89,67,239,191,189,74,239,191,189,3,239,191,189,239,191,189,223,175,80,99,71,39,48,239,191,189,64,239,191,189,43,70,113,239,191,189,239,191,189,84,239,191,189,99,239,191,189,67,239,191,189,118,239,191,189,23,29,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,100,24,239,191,189,239,191,189,239,191,189,11,97,22,3,239,191,189,0,43,239,191,189,58,27,239,191,189,67,54,239,191,189,86,61,40,239,191,189,239,191,189,104,239,191,189,56,69,239,191,189,71,61,239,191,189,239,191,189,239,191,189,239,191,189,46,239,191,189,38,239,191,189,73,45,77,214,139,239,191,189,75,4,239,191,189,2,239,191,189,239,191,189,239,191,189,239,191,189,102,239,191,189,59,124,239,191,189,112,239,191,189,239,191,189,27,115,239,191,189,121,102,239,191,189,24,115,239,191,189,239,191,189,28,239,191,189,239,191,189,40,239,191,189,82,16,239,191,189,29,239,191,189,92,67,229,170,129,239,191,189,29,239,139,177,70,239,191,189,239,191,189,119,17,239,191,189,26,17,239,191,189,239,191,189,239,191,189,105,21,239,191,189,239,191,189,45,72,61,239,191,189,239,191,189,108,239,191,189,83,16,117,215,141,18,239,191,189,194,138,40,239,191,189,59,239,191,189,102,239,191,189,54,23,22,56,239,191,189,81,122,1,239,191,189,46,39,42,84,92,239,191,189,47,239,191,189,68,239,191,189,98,239,191,189,1,57,75,7,25,239,191,189,24,195,128,239,191,189,6,25,72,17,38,239,191,189,239,191,189,109,105,239,191,189,15,239,191,189,239,191,189,102,239,191,189,101,239,191,189,239,191,189,71,239,191,189,45,3,76,53,239,191,189,239,191,189,48,239,191,189,125,97,61,114,84,32,16,12,74,239,191,189,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,126,239,191,189,239,191,189,31,118,110,110,239,191,189,57,239,191,189,239,191,189,21,239,191,189,239,191,189,73,222,129,239,191,189,239,191,189,119,239,191,189,15,85,70,215,150,27,239,191,189,115,87,32,11,122,195,182,77,239,191,189,17,111,15,239,191,189,114,57,114,71,239,191,189,17,109,112,239,191,189,110,78,53,17,239,191,189,110,59,239,191,189,72,239,191,189,82,124,87,239,191,189,239,191,189,205,155,56,38,239,191,189,239,191,189,112,25,220,132,95,239,191,189,239,191,189,239,191,189,220,133,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,104,12,71,17,71,200,143,239,191,189,118,27,86,239,191,189,122,95,239,191,189,71,116,239,191,189,239,191,189,52,88,239,191,189,87,239,191,189,88,239,191,189,107,89,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,51,43,239,191,189,234,176,167,239,191,189,31,14,68,127,49,239,191,189,124,239,191,189,103,12,29,239,191,189,125,219,180,239,191,189,239,191,189,239,191,189,93,53,24,121,239,191,189,93,194,131,44,239,191,189,104,239,191,189,239,191,189,87,239,191,189,56,126,19,23,39,26,239,191,189,61,239,191,189,110,15,80,120,88,119,47,49,9,74,83,7,239,191,189,239,191,189,34,110,1,80,0,239,191,189,239,191,189,31,239,191,189,239,191,189,68,92,239,191,189,239,191,189,239,191,189,239,191,189,109,239,191,189,219,137,33,78,114,10,239,191,189,53,56,89,239,191,189,13,87,49,239,191,189,94,239,191,189,239,191,189,25,239,191,189,239,191,189,62,110,79,124,93,52,239,191,189,213,151,239,191,189,124,239,191,189,239,191,189,44,11,239,191,189,239,191,189,239,191,189,239,191,189,124,239,191,189,239,191,189,40,42,239,191,189,239,191,189,19,114,67,239,191,189,239,191,189,115,239,191,189,219,157,26,239,191,189,239,191,189,20,239,191,189,239,191,189,96,239,191,189,239,191,189,120,49,239,191,189,5,239,191,189,239,191,189,33,239,191,189,34,34,239,191,189,120,70,37,239,191,189,239,191,189,32,239,191,189,239,191,189,239,191,189,239,191,189,9,13,239,191,189,239,191,189,239,191,189,1,239,191,189,32,239,191,189,105,36,110,239,191,189,84,15,13,239,191,189,119,239,191,189,25,80,239,191,189,239,191,189,36,212,172,239,191,189,82,239,191,189,79,206,172,239,191,189,111,35,239,191,189,118,239,191,189,10,32,239,191,189,2,126,121,83,239,191,189,115,239,191,189,239,191,189,19,239,191,189,26,116,239,191,189,239,191,189,96,239,191,189,105,27,20,38,239,191,189,107,84,239,191,189,120,124,66,48,113,239,191,189,239,191,189,108,96,67,77,46,127,239,191,189,239,191,189,57,56,239,191,189,239,191,189,89,239,191,189,55,67,239,191,189,195,166,12,239,191,189,239,191,189,239,191,189,66,239,191,189,41,239,191,189,239,191,189,90,48,114,65,124,81,239,191,189,19,106,107,50,118,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,64,57,239,191,189,108,203,138,239,191,189,118,103,0,239,191,189,5,239,191,189,239,191,189,239,191,189,8,239,191,189,94,37,7,5,35,239,191,189,75,239,191,189,48,115,239,191,189,27,10,77,239,191,189,45,239,191,189,239,191,189,33,239,191,189,6,118,239,191,189,55,239,191,189,106,239,191,189,45,212,162,125,239,191,189,41,239,191,189,239,191,189,239,191,189,239,191,189,28,96,64,219,154,22,29,90,92,239,191,189,239,191,189,215,172,90,239,191,189,99,239,191,189,239,191,189,52,239,191,189,239,191,189,119,110,239,191,189,100,92,239,191,189,54,73,239,191,189,43,57,19,126,239,191,189,100,42,239,191,189,239,191,189,98,239,191,189,80,239,191,189,239,191,189,85,39,71,239,191,189,110,106,239,191,189,110,108,20,239,191,189,239,191,189,119,62,69,239,191,189,16,122,239,191,189,239,191,189,239,191,189,239,191,189,220,191,239,191,189,239,191,189,12,89,36,239,191,189,38,239,191,189,239,191,189,14,52,239,191,189,57,239,191,189,119,9,239,191,189,239,191,189,239,191,189,239,191,189,207,185,239,191,189,239,191,189,239,191,189,123,239,191,189,214,187,16,239,191,189,239,191,189,107,61,110,214,161,21,72,36,126,58,239,191,189,105,10,239,191,189,239,191,189,53,3,239,191,189,0,208,153,3,239,191,189,69,239,191,189,111,195,168,35,80,239,191,189,239,191,189,85,239,191,189,30,239,191,189,108,239,191,189,103,239,191,189,239,191,189,239,191,189,89,239,191,189,239,191,189,74,239,191,189,239,191,189,206,151,239,191,189,239,191,189,16,239,191,189,239,191,189,103,78,41,239,191,189,49,82,239,191,189,0,46,63,40,19,101,239,191,189,239,191,189,239,191,189,98,239,191,189,89,75,239,191,189,239,191,189,90,109,239,191,189,239,191,189,239,191,189,218,139,125,49,239,191,189,109,239,191,189,239,191,189,239,191,189,67,239,191,189,53,84,239,191,189,239,191,189,43,85,239,191,189,54,45,59,29,239,191,189,112,62,239,191,189,239,191,189,55,239,191,189,239,191,189,94,85,104,239,191,189,116,239,191,189,13,127,239,191,189,239,191,189,239,191,189,3,239,191,189,239,191,189,84,4,103,239,191,189,126,4,239,191,189,96,239,191,189,239,191,189,239,191,189,239,191,189,13,239,191,189,239,191,189,239,191,189,118,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,30,102,122,72,48,239,191,189,119,84,26,74,239,191,189,239,191,189,52,84,62,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,239,191,189,26,239,191,189,239,191,189,63,239,191,189,72,239,191,189,103,116,24,73,125,3,239,191,189,239,191,189,239,191,189,55,89,239,191,189,114,81,9,64,239,191,189,34,239,191,189,203,136,80,57,50,20,239,191,189,239,191,189,46,239,191,189,239,191,189,55,102,239,191,189,76,83,117,239,191,189,239,191,189,239,191,189,58,50,114,45,111,96,103,69,81,17,77,58,29,51,124,116,22,58,239,191,189,52,239,191,189,44,239,191,189,239,191,189,22,0,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,75,127,239,191,189,21,35,239,191,189,210,173,105,239,191,189,28,85,127,26,51,85,239,191,189,60,58,239,191,189,239,191,189,8,14,239,191,189,239,191,189,22,110,109,239,191,189,31,83,125,239,191,189,239,191,189,210,179,239,191,189,94,239,191,189,112,19,239,191,189,100,239,191,189,112,239,191,189,239,191,189,239,191,189,123,77,239,191,189,88,239,191,189,239,191,189,66,113,239,191,189,12,91,101,22,74,50,239,191,189,239,191,189,239,191,189,72,239,191,189,113,121,73,202,161,46,239,191,189,102,51,239,191,189,239,191,189,239,191,189,239,191,189,27,209,145,37,239,191,189,239,191,189,239,191,189,65,239,191,189,239,191,189,239,191,189,20,239,191,189,112,26,117,239,191,189,228,159,157,63,10,239,191,189,120,239,191,189,81,204,158,10,239,191,189,239,191,189,239,191,189,210,183,239,191,189,120,239,191,189,122,239,191,189,104,239,191,189,62,239,191,189,239,191,189,97,239,191,189,239,191,189,239,191,189,98,17,239,191,189,239,191,189,110,17,239,191,189,24,239,191,189,99,239,191,189,239,191,189,55,47,60,91,65,239,191,189,116,239,191,189,239,191,189,87,239,191,189,54,239,191,189,0,239,191,189,45,22,239,191,189,94,13,21,24,94,239,191,189,239,191,189,239,191,189,72,239,191,189,123,239,191,189,227,151,166,239,191,189,7,81,105,6,116,239,191,189,73,239,191,189,29,10,40,239,191,189,5,110,239,191,189,239,191,189,1,239,191,189,4,239,191,189,239,191,189,30,209,184,239,191,189,89,239,191,189,239,191,189,39,76,116,82,239,191,189,30,239,191,189,54,239,191,189,16,99,97,239,191,189,46,239,191,189,83,92,1,239,191,189,239,191,189,97,239,191,189,239,191,189,35,239,191,189,239,191,189,239,191,189,232,128,177,87,27,79,239,191,189,239,191,189,208,150,239,191,189,25,239,191,189,116,81,11,239,191,189,92,239,191,189,239,191,189,34,125,92,239,191,189,119,239,191,189,41,123,239,191,189,80,239,191,189,239,191,189,51,16,239,191,189,18,239,191,189,71,18,5,111,42,239,191,189,239,191,189,239,191,189,239,191,189,101,15,239,191,189,239,191,189,239,191,189,239,191,189,1,61,239,191,189,2,84,239,191,189,239,191,189,123,239,191,189,67,10,69,21,123,239,191,189,99,239,191,189,239,191,189,56,20,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,239,191,189,123,109,25,239,191,189,49,239,191,189,209,156,239,191,189,74,239,191,189,239,191,189,16,239,191,189,239,191,189,112,43,32,119,113,107,71,2,116,239,191,189,91,239,191,189,93,22,239,191,189,239,191,189,66,126,239,191,189,40,14,123,104,217,188,68,223,189,25,239,191,189,58,40,112,239,191,189,122,19,239,191,189,72,100,91,52,107,239,191,189,50,239,191,189,239,191,189,115,239,191,189,239,191,189,123,113,63,47,123,239,191,189,239,191,189,239,191,189,70,239,191,189,44,239,191,189,239,191,189,239,191,189,109,51,66,98,239,191,189,239,191,189,239,191,189,239,191,189,26,239,191,189,239,191,189,239,191,189,53,3,239,191,189,239,191,189,90,198,157,117,239,191,189,239,191,189,239,191,189,114,239,191,189,80,239,191,189,239,191,189,55,207,171,239,191,189,22,197,161,239,191,189,16,239,191,189,11,239,191,189,120,36,239,191,189,239,191,189,239,191,189,29,239,191,189,67,239,191,189,92,49,239,191,189,74,24,114,59,78,239,191,189,22,239,191,189,102,107,239,191,189,71,32,239,191,189,112,97,83,239,191,189,113,239,191,189,24,239,191,189,239,191,189,78,107,239,191,189,103,239,191,189,77,239,191,189,219,157,239,191,189,55,239,191,189,82,102,68,32,239,191,189,112,30,12,66,239,191,189,64,239,191,189,93,28,226,128,156,239,191,189,8,50,27,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,25,239,191,189,6,24,95,239,191,189,239,191,189,29,239,191,189,15,239,191,189,239,191,189,74,239,191,189,239,191,189,91,43,239,191,189,10,239,191,189,106,56,63,239,191,189,239,191,189,5,239,191,189,122,98,239,191,189,35,239,191,189,5,89,60,239,191,189,239,191,189,220,156,239,191,189,239,191,189,113,239,191,189,33,239,191,189,56,42,8,239,191,189,239,191,189,239,191,189,239,191,189,49,239,191,189,122,239,191,189,59,127,239,191,189,239,191,189,102,127,239,191,189,239,191,189,123,239,191,189,239,191,189,87,239,191,189,73,239,191,189,109,239,191,189,239,191,189,239,191,189,66,239,191,189,34,205,184,239,191,189,239,191,189,33,126,102,87,239,191,189,117,239,191,189,97,239,191,189,239,191,189,239,191,189,103,239,191,189,25,239,191,189,11,67,239,191,189,239,191,189,16,109,239,191,189,54,239,191,189,42,239,191,189,239,191,189,239,191,189,93,21,37,239,191,189,239,191,189,1,239,191,189,239,191,189,76,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,15,27,2,41,21,22,239,191,189,36,239,191,189,239,191,189,61,113,71,239,191,189,44,43,239,191,189,30,4,239,191,189,239,191,189,239,191,189,239,191,189,87,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,47,239,191,189,239,191,189,239,191,189,122,15,239,191,189,91,107,70,239,191,189,1,239,191,189,239,191,189,239,191,189,81,239,191,189,111,112,239,191,189,239,191,189,239,191,189,239,191,189,13,23,46,73,62,239,191,189,108,86,239,191,189,73,46,239,191,189,239,191,189,239,191,189,239,191,189,97,29,122,239,191,189,239,191,189,239,191,189,89,239,191,189,38,21,239,191,189,5,239,191,189,79,53,79,239,191,189,109,239,191,189,239,191,189,110,75,239,191,189,114,239,191,189,239,191,189,239,167,184,239,191,189,18,12,239,191,189,239,191,189,14,83,18,91,14,36,239,191,189,239,191,189,8,52,64,239,191,189,119,6,239,191,189,239,191,189,79,59,20,1,82,21,87,7,12,239,191,189,206,177,222,154,2,239,191,189,103,0,65,239,191,189,60,239,191,189,95,125,239,191,189,239,191,189,67,239,191,189,50,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,59,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,10,78,91,86,2,239,191,189,109,49,78,100,119,239,191,189,203,188,239,191,189,220,150,4,100,239,191,189,239,191,189,239,191,189,80,44,239,191,189,32,95,43,239,191,189,239,191,189,94,72,239,191,189,50,53,3,39,239,191,189,75,239,191,189,95,239,191,189,87,16,35,46,1,111,239,191,189,97,239,191,189,61,39,52,53,239,191,189,47,113,75,239,191,189,14,6,84,239,191,189,24,125,228,138,151,239,191,189,111,9,25,239,191,189,103,239,191,189,239,191,189,27,239,191,189,239,191,189,30,239,191,189,48,239,191,189,50,33,32,239,191,189,239,191,189,55,212,181,239,191,189,239,191,189,239,191,189,89,239,191,189,239,191,189,239,191,189,239,191,189,74,118,239,191,189,33,239,191,189,35,44,239,191,189,68,5,19,239,191,189,239,191,189,99,30,213,188,104,239,191,189,92,50,239,191,189,95,3,239,191,189,90,80,50,13,97,59,36,28,62,239,191,189,23,14,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,50,239,191,189,6,239,191,189,101,239,191,189,239,191,189,239,191,189,84,239,191,189,73,24,239,191,189,120,29,56,52,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,238,147,132,239,191,189,6,239,191,189,22,239,191,189,239,191,189,103,77,239,191,189,45,66,239,191,189,109,235,136,138,239,191,189,239,191,189,37,239,191,189,38,239,191,189,239,191,189,239,191,189,109,110,42,239,191,189,36,239,191,189,104,239,191,189,114,104,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,5,239,191,189,239,191,189,17,75,219,132,239,191,189,239,191,189,113,53,83,239,191,189,239,191,189,239,191,189,94,239,191,189,104,213,168,86,239,191,189,108,40,0,239,191,189,110,64,5,65,239,191,189,239,191,189,239,191,189,86,31,239,191,189,91,239,191,189,83,20,239,191,189,66,239,191,189,239,130,132,10,239,191,189,9,239,191,189,59,239,191,189,20,57,53,117,239,191,189,17,239,191,189,109,68,239,191,189,239,191,189,239,191,189,104,239,191,189,239,191,189,239,191,189,239,191,189,2,76,21,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,126,63,99,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,29,239,191,189,123,239,191,189,239,191,189,203,167,239,191,189,239,191,189,239,191,189,239,191,189,0,239,191,189,97,239,191,189,7,99,38,38,85,239,191,189,239,191,189,239,191,189,104,239,191,189,71,9,239,191,189,239,191,189,19,239,191,189,239,191,189,111,239,191,189,84,72,239,191,189,73,25,26,239,191,189,239,191,189,239,191,189,125,71,2,239,191,189,239,191,189,47,239,191,189,239,191,189,104,239,191,189,64,239,191,189,81,10,239,191,189,239,191,189,239,191,189,31,239,191,189,26,3,61,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,58,239,191,189,239,191,189,239,191,189,239,191,189,20,239,191,189,7,7,239,191,189,239,191,189,95,239,191,189,90,239,191,189,126,107,239,191,189,239,191,189,239,191,189,123,42,239,191,189,102,201,174,64,239,191,189,95,32,53,123,239,191,189,239,191,189,45,210,135,59,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,63,239,191,189,36,33,239,191,189,15,24,239,191,189,16,23,82,239,191,189,7,239,191,189,63,239,191,189,239,191,189,105,239,191,189,17,45,10,239,191,189,48,91,239,191,189,63,239,191,189,65,91,239,191,189,14,111,94,20,59,239,191,189,110,107,239,191,189,32,28,239,191,189,53,87,239,191,189,33,68,239,191,189,1,239,191,189,58,1,45,239,191,189,239,191,189,45,239,191,189,108,96,216,172,206,187,239,191,189,213,152,117,43,107,239,191,189,45,239,191,189,44,239,191,189,16,79,239,191,189,239,191,189,198,140,239,191,189,239,191,189,64,239,191,189,239,191,189,12,65,239,191,189,115,14,13,1,10,239,191,189,116,78,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,25,239,191,189,24,239,191,189,60,239,191,189,60,239,191,189,81,107,23,239,191,189,239,191,189,221,181,239,191,189,19,9,239,191,189,86,204,184,93,239,191,189,43,239,191,189,119,125,239,191,189,80,28,87,239,191,189,239,191,189,239,191,189,116,39,35,74,54,4,5,33,239,191,189,239,191,189,91,55,214,191,239,191,189,235,155,185,239,191,189,239,191,189,96,37,61,90,73,94,239,191,189,239,191,189,1,79,239,191,189,239,191,189,239,191,189,239,191,189,65,102,239,191,189,82,199,151,239,191,189,239,191,189,207,187,239,191,189,239,191,189,2,100,239,191,189,239,191,189,35,1,239,191,189,78,239,191,189,239,191,189,1,239,191,189,69,34,31,83,53,127,68,239,191,189,126,88,239,191,189,239,191,189,39,83,24,239,191,189,106,87,239,191,189,239,191,189,239,191,189,1,223,157,239,191,189,33,239,191,189,239,191,189,123,239,191,189,124,39,239,191,189,239,191,189,12,239,191,189,119,103,239,191,189,79,119,239,191,189,63,239,191,189,104,239,191,189,119,239,191,189,239,191,189,239,191,189,61,115,27,67,67,239,191,189,239,191,189,19,239,191,189,83,94,239,191,189,239,191,189,239,191,189,32,110,70,116,81,3,239,191,189,59,22,239,191,189,239,191,189,53,52,42,239,191,189,239,191,189,8,239,191,189,14,239,191,189,239,191,189,74,239,191,189,239,191,189,96,239,191,189,225,156,136,36,104,239,191,189,205,148,239,191,189,8,239,191,189,116,101,239,191,189,239,191,189,2,92,37,239,191,189,13,77,91,105,239,191,189,74,239,191,189,125,239,191,189,239,191,189,239,191,189,239,191,189,125,19,91,33,11,239,191,189,239,191,189,14,104,239,191,189,239,191,189,239,191,189,94,239,191,189,94,46,239,191,189,239,191,189,239,191,189,120,71,82,239,191,189,239,191,189,50,239,191,189,239,191,189,239,191,189,54,217,169,239,191,189,56,11,97,9,239,191,189,239,191,189,79,105,239,191,189,114,239,191,189,239,191,189,239,191,189,199,128,239,191,189,60,78,239,191,189,4,239,191,189,88,53,239,191,189,239,191,189,239,191,189,239,191,189,9,24,239,191,189,216,142,239,191,189,239,191,189,105,83,51,84,111,32,239,191,189,239,191,189,239,191,189,213,173,239,191,189,239,191,189,107,41,36,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,213,160,86,35,5,70,80,213,154,22,239,191,189,239,191,189,93,45,239,191,189,239,191,189,239,191,189,239,191,189,109,99,118,96,19,239,191,189,239,191,189,109,239,191,189,239,191,189,47,239,191,189,82,50,239,191,189,125,239,191,189,239,191,189,75,26,80,51,11,58,239,191,189,68,20,14,239,191,189,239,191,189,239,191,189,7,18,54,97,105,117,239,191,189,239,191,189,89,239,191,189,102,92,239,191,189,239,191,189,110,100,239,191,189,211,175,239,191,189,232,147,185,29,48,106,37,124,115,239,191,189,95,239,191,189,82,239,191,189,239,191,189,27,239,191,189,32,8,4,96,239,191,189,239,191,189,239,191,189,101,239,191,189,40,239,191,189,58,76,239,191,189,239,191,189,116,89,25,49,239,191,189,79,17,42,239,191,189,56,239,191,189,10,33,239,191,189,239,191,189,73,239,191,189,239,191,189,239,191,189,234,136,161,54,52,90,4,239,191,189,84,239,191,189,42,37,239,191,189,239,191,189,239,191,189,116,61,2,239,191,189,33,239,191,189,239,191,189,54,77,73,102,239,191,189,68,239,191,189,81,239,191,189,209,134,239,191,189,239,191,189,56,239,191,189,34,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,122,19,239,191,189,105,92,75,239,191,189,71,25,239,191,189,239,191,189,239,191,189,82,83,239,191,189,206,141,239,191,189,239,191,189,3,239,191,189,88,239,191,189,239,191,189,217,139,239,191,189,27,29,239,191,189,39,239,191,189,54,239,191,189,239,191,189,53,122,98,231,134,183,79,239,191,189,239,191,189,239,191,189,239,191,189,127,53,22,73,57,239,191,189,239,191,189,239,191,189,34,117,239,191,189,239,191,189,209,169,126,41,81,106,239,191,189,239,191,189,239,191,189,127,239,191,189,83,42,239,191,189,60,75,239,191,189,239,191,189,239,191,189,61,9,239,191,189,33,239,191,189,7,127,239,191,189,6,124,6,239,191,189,239,191,189,239,191,189,239,191,189,22,239,191,189,56,37,103,239,191,189,239,191,189,15,51,0,126,239,191,189,30,96,239,191,189,110,239,191,189,203,187,239,191,189,44,239,191,189,239,191,189,34,239,191,189,125,239,191,189,67,239,191,189,239,191,189,239,191,189,239,191,189,88,239,191,189,96,19,239,191,189,56,31,121,239,191,189,113,33,103,68,96,239,191,189,75,14,26,46,239,191,189,239,191,189,75,239,191,189,85,239,191,189,2,239,191,189,12,239,191,189,203,135,49,239,191,189,239,191,189,197,157,90,91,100,74,239,191,189,65,239,191,189,239,191,189,101,49,239,191,189,113,239,191,189,53,239,191,189,239,191,189,2,12,12,239,191,189,11,115,239,191,189,239,191,189,18,239,191,189,46,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,239,191,189,239,191,189,71,239,191,189,239,191,189,47,239,191,189,109,36,35,29,57,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,79,239,191,189,223,167,239,191,189,239,191,189,94,239,191,189,117,81,239,191,189,239,191,189,0,239,191,189,239,191,189,220,187,239,191,189,239,191,189,77,239,191,189,27,6,96,127,239,191,189,102,239,191,189,239,191,189,94,91,112,239,191,189,43,239,191,189,239,191,189,239,191,189,61,239,191,189,239,191,189,97,94,121,28,239,191,189,77,28,239,191,189,21,24,239,191,189,239,191,189,92,108,26,51,239,191,189,126,39,239,191,189,58,239,191,189,239,191,189,22,239,191,189,25,239,191,189,239,191,189,14,239,191,189,5,126,12,239,191,189,239,191,189,75,239,191,189,239,191,189,239,191,189,50,239,191,189,220,130,219,137,239,191,189,20,116,16,108,239,191,189,88,21,9,239,191,189,239,191,189,239,191,189,99,37,239,191,189,87,72,123,95,19,87,239,191,189,239,191,189,239,191,189,206,145,239,191,189,239,191,189,239,191,189,239,191,189,93,68,0,239,191,189,100,5,239,191,189,196,161,202,173,104,3,239,191,189,80,239,191,189,62,239,191,189,69,218,144,97,34,239,191,189,49,239,191,189,92,239,191,189,65,239,191,189,239,191,189,31,61,74,86,239,191,189,239,191,189,239,191,189,123,215,131,217,149,101,238,185,187,47,4,83,50,114,27,59,239,191,189,33,56,91,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,73,198,178,239,191,189,72,104,2,239,191,189,3,12,239,191,189,239,191,189,98,66,27,239,191,189,239,191,189,61,239,191,189,239,191,189,45,4,1,77,52,73,122,50,239,191,189,74,1,18,239,191,189,88,239,191,189,239,191,189,9,53,239,191,189,239,191,189,48,239,191,189,23,46,116,239,191,189,239,191,189,25,115,8,239,191,189,69,62,19,239,191,189,68,239,191,189,100,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,117,239,191,189,9,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,159,115,97,239,191,189,201,130,239,191,189,211,172,121,97,46,239,191,189,112,239,191,189,239,191,189,96,239,191,189,95,35,239,191,189,239,191,189,239,191,189,124,74,112,57,196,161,239,191,189,89,88,239,191,189,37,239,191,189,239,191,189,15,46,54,79,239,191,189,31,239,191,189,59,239,191,189,239,191,189,30,194,161,48,213,141,239,191,189,239,191,189,215,168,239,191,189,117,89,72,239,191,189,50,42,32,8,61,26,74,50,111,81,239,191,189,41,239,191,189,93,239,191,189,59,64,80,125,27,1,0,81,239,191,189,239,191,189,66,239,191,189,78,227,168,153,239,191,189,239,191,189,87,111,239,191,189,111,50,239,191,189,239,191,189,211,144,50,239,191,189,82,100,239,191,189,125,46,108,239,191,189,37,239,191,189,45,239,191,189,50,217,155,61,239,191,189,107,239,191,189,78,198,183,239,191,189,59,124,239,191,189,239,191,189,14,239,191,189,239,191,189,71,113,239,191,189,114,49,102,103,49,31,118,4,116,239,191,189,239,191,189,98,60,27,239,191,189,239,191,189,239,191,189,108,239,191,189,65,107,39,239,191,189,40,93,239,191,189,122,239,191,189,239,191,189,239,191,189,53,239,191,189,100,103,106,214,147,57,239,191,189,239,191,189,239,191,189,66,239,191,189,124,26,239,191,189,239,191,189,239,191,189,25,239,191,189,57,113,47,98,74,239,191,189,62,10,239,191,189,239,191,189,239,191,189,111,239,191,189,239,191,189,239,191,189,239,191,189,216,180,105,30,46,51,239,191,189,105,239,191,189,239,191,189,239,191,189,67,239,191,189,239,191,189,124,239,191,189,239,191,189,116,84,1,28,222,152,239,191,189,239,191,189,56,3,82,95,239,191,189,60,239,191,189,239,191,189,239,191,189,239,191,189,6,120,197,184,101,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,43,239,191,189,36,239,191,189,101,239,191,189,214,152,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,102,87,239,191,189,239,191,189,8,7,5,0,27,239,191,189,27,239,191,189,239,191,189,239,191,189,73,239,191,189,65,4,239,191,189,239,191,189,119,239,191,189,95,58,41,61,239,191,189,1,74,2,116,239,191,189,106,239,191,189,94,96,223,157,239,191,189,239,191,189,239,191,189,239,191,189,15,112,9,239,191,189,104,239,191,189,239,191,189,239,191,189,73,239,191,189,239,191,189,239,191,189,72,239,191,189,239,191,189,75,239,191,189,239,191,189,84,4,239,191,189,25,12,29,239,191,189,68,48,239,191,189,215,163,122,1,20,239,191,189,239,191,189,239,191,189,48,86,212,184,116,105,239,191,189,239,191,189,25,239,191,189,110,239,191,189,104,239,191,189,200,191,107,239,191,189,11,239,191,189,99,239,191,189,72,36,201,163,9,239,191,189,6,227,180,146,239,191,189,9,26,126,239,191,189,239,191,189,239,191,189,75,97,25,3,239,191,189,239,191,189,96,239,191,189,66,219,187,239,191,189,91,239,191,189,210,139,68,13,239,191,189,239,191,189,239,191,189,96,18,239,191,189,54,239,191,189,239,191,189,9,95,122,73,239,191,189,239,191,189,41,239,191,189,239,191,189,74,239,191,189,95,78,104,34,239,191,189,239,191,189,75,76,89,239,191,189,239,191,189,125,239,191,189,112,70,239,191,189,239,191,189,239,191,189,78,44,239,191,189,239,191,189,239,191,189,87,34,200,145,239,191,189,239,191,189,49,239,191,189,61,64,92,239,191,189,97,239,191,189,239,191,189,239,191,189,72,239,191,189,239,191,189,239,191,189,20,239,191,189,217,129,34,105,239,191,189,70,30,26,99,85,17,0,239,191,189,56,88,239,191,189,39,239,191,189,239,191,189,61,121,239,191,189,239,191,189,38,18,82,6,239,191,189,239,191,189,104,2,67,65,35,239,191,189,113,239,191,189,239,191,189,24,239,191,189,34,65,74,12,117,239,191,189,239,191,189,15,72,99,107,239,191,189,93,239,191,189,43,22,239,191,189,239,191,189,87,239,191,189,63,239,191,189,54,239,191,189,82,205,191,218,128,239,191,189,239,191,189,95,239,191,189,27,55,120,215,177,100,239,191,189,239,191,189,66,239,191,189,239,191,189,6,239,191,189,239,191,189,239,191,189,211,167,112,239,191,189,239,191,189,239,191,189,11,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,97,239,191,189,12,26,239,191,189,239,191,189,239,191,189,239,191,189,74,239,191,189,239,191,189,72,80,239,191,189,239,191,189,75,239,191,189,33,239,191,189,239,191,189,19,58,239,191,189,75,7,239,191,189,44,41,29,10,118,239,191,189,104,239,191,189,0,239,191,189,239,191,189,71,21,5,3,14,93,126,239,191,189,112,62,86,80,110,239,191,189,239,191,189,222,176,77,70,28,207,150,239,191,189,239,191,189,117,239,191,189,64,124,239,191,189,239,191,189,112,239,191,189,14,95,239,191,189,11,239,191,189,239,191,189,5,239,191,189,113,127,239,191,189,78,239,191,189,216,175,75,239,191,189,24,239,191,189,239,191,189,239,191,189,239,191,189,29,239,191,189,25,61,239,191,189,102,28,1,239,191,189,239,191,189,206,162,65,14,30,239,191,189,1,239,191,189,72,104,239,191,189,79,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,210,187,38,239,191,189,239,191,189,59,66,239,191,189,239,191,189,77,239,191,189,239,191,189,111,239,191,189,6,127,51,239,191,189,239,191,189,44,239,191,189,23,239,191,189,74,81,39,205,177,107,75,239,191,189,110,38,47,61,105,239,191,189,6,239,191,189,46,239,191,189,97,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,45,239,191,189,5,87,239,191,189,239,191,189,67,239,191,189,239,191,189,19,116,62,239,191,189,84,91,48,239,191,189,63,74,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,25,239,191,189,91,239,191,189,239,191,189,239,191,189,5,239,191,189,62,239,191,189,239,191,189,23,93,68,239,191,189,37,95,239,191,189,239,191,189,87,239,191,189,72,13,44,121,12,239,191,189,125,92,239,191,189,51,116,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,40,111,239,191,189,72,239,191,189,111,24,61,239,191,189,239,191,189,119,47,239,191,189,239,191,189,124,14,208,168,46,40,239,191,189,239,191,189,91,239,191,189,89,119,239,191,189,239,191,189,115,239,191,189,61,110,239,191,189,239,191,189,239,191,189,105,0,69,239,191,189,96,239,191,189,1,239,191,189,239,191,189,111,239,191,189,239,191,189,6,239,191,189,0,69,239,191,189,239,191,189,98,58,239,191,189,42,239,191,189,110,239,191,189,239,191,189,239,191,189,239,191,189,5,57,239,191,189,239,191,189,211,147,239,191,189,239,191,189,98,113,239,191,189,239,191,189,239,191,189,118,46,239,191,189,239,191,189,239,191,189,239,191,189,114,102,239,191,189,239,191,189,239,191,189,239,191,189,1,62,86,239,191,189,239,191,189,239,191,189,36,122,199,171,239,191,189,26,2,115,24,48,239,191,189,72,239,191,189,239,191,189,79,44,239,191,189,122,239,191,189,86,239,191,189,239,191,189,20,239,191,189,239,191,189,25,239,191,189,68,239,191,189,101,121,239,191,189,239,191,189,239,191,189,113,239,191,189,239,191,189,127,239,191,189,239,191,189,26,239,191,189,66,239,191,189,58,239,191,189,8,64,212,138,239,191,189,26,111,239,191,189,78,101,40,239,191,189,239,191,189,43,239,191,189,224,178,183,86,239,191,189,20,239,191,189,239,191,189,57,239,191,189,239,191,189,36,239,191,189,239,191,189,25,239,191,189,26,123,114,239,191,189,4,239,191,189,219,157,113,60,4,90,12,239,191,189,239,191,189,239,191,189,109,239,191,189,58,10,239,191,189,45,239,191,189,239,191,189,28,98,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,53,239,191,189,13,121,34,68,239,191,189,34,239,191,189,25,239,191,189,96,15,239,191,189,239,191,189,111,18,17,239,191,189,215,160,15,71,239,191,189,239,191,189,239,191,189,202,161,35,56,239,191,189,122,239,191,189,239,191,189,37,121,239,191,189,92,239,191,189,41,38,23,50,113,72,62,239,191,189,239,191,189,239,191,189,42,239,191,189,239,191,189,63,239,191,189,107,37,75,32,239,191,189,66,121,24,239,191,189,239,191,189,93,106,239,191,189,23,108,87,239,191,189,239,191,189,74,239,191,189,239,191,189,239,191,189,239,191,189,213,164,239,191,189,94,64,15,239,191,189,239,191,189,239,191,189,58,239,191,189,239,191,189,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,13,25,239,191,189,19,239,191,189,98,107,30,57,120,218,132,239,191,189,48,239,191,189,72,117,123,239,191,189,239,191,189,56,8,5,239,191,189,112,47,56,239,191,189,108,42,22,239,191,189,239,191,189,221,162,112,73,239,191,189,239,191,189,60,239,191,189,34,213,128,239,191,189,104,239,191,189,115,239,191,189,239,191,189,239,191,189,32,239,191,189,239,191,189,119,5,19,239,191,189,239,191,189,239,191,189,41,239,191,189,15,97,239,191,189,212,141,113,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,21,51,239,191,189,39,7,239,191,189,239,191,189,222,181,115,239,191,189,52,36,102,239,191,189,92,239,191,189,29,23,18,17,113,239,191,189,30,234,169,180,239,191,189,57,239,191,189,3,107,0,239,191,189,97,209,143,117,239,191,189,7,101,2,239,191,189,239,191,189,108,239,191,189,239,191,189,110,239,191,189,21,83,239,191,189,239,191,189,239,191,189,223,164,109,101,60,94,239,191,189,222,165,239,191,189,111,239,191,189,51,117,4,239,191,189,239,191,189,54,239,191,189,15,239,191,189,15,117,41,239,191,189,59,15,70,239,191,189,35,100,109,239,191,189,82,208,189,100,41,57,61,22,239,191,189,93,239,191,189,44,239,191,189,124,36,105,35,72,29,20,239,191,189,0,239,191,189,47,67,239,191,189,1,79,239,191,189,231,129,154,2,239,191,189,239,191,189,70,103,239,191,189,239,191,189,67,239,191,189,38,239,191,189,119,239,191,189,208,190,239,191,189,239,191,189,239,191,189,239,191,189,70,88,64,81,0,239,191,189,33,119,55,239,191,189,107,239,191,189,239,191,189,99,42,37,239,191,189,127,35,239,191,189,239,191,189,32,208,147,239,191,189,30,239,191,189,70,239,191,189,66,101,239,191,189,19,239,191,189,83,239,191,189,123,239,191,189,239,191,189,239,191,189,69,44,239,191,189,85,239,191,189,239,191,189,239,191,189,19,210,170,35,106,239,191,189,23,54,38,239,191,189,239,191,189,119,239,191,189,239,191,189,218,148,239,191,189,239,191,189,239,191,189,239,191,189,54,16,239,191,189,239,191,189,11,239,191,189,105,118,120,91,123,5,82,73,239,191,189,116,55,30,239,191,189,20,239,191,189,111,44,33,239,191,189,24,239,191,189,239,191,189,106,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,3,81,0,23,239,191,189,79,239,191,189,239,191,189,239,191,189,12,239,191,189,36,239,191,189,48,102,93,214,142,239,191,189,239,191,189,239,191,189,239,191,189,95,239,191,189,239,191,189,26,239,191,189,11,225,139,175,20,87,239,191,189,239,191,189,35,54,6,108,239,191,189,92,239,191,189,97,20,38,239,191,189,40,239,191,189,4,57,239,191,189,60,103,108,239,191,189,31,239,191,189,36,36,116,201,148,239,191,189,64,92,239,191,189,239,191,189,239,191,189,67,38,239,191,189,34,239,191,189,50,20,239,191,189,75,239,191,189,0,239,191,189,239,191,189,7,239,191,189,239,191,189,114,239,191,189,239,191,189,211,129,50,18,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,33,239,191,189,239,191,189,38,57,35,239,191,189,19,42,26,239,191,189,57,194,157,239,191,189,110,35,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,239,191,189,239,191,189,27,13,17,19,239,191,189,43,239,191,189,107,62,96,239,191,189,34,218,184,239,191,189,70,239,191,189,103,88,12,239,191,189,17,227,140,164,239,191,189,116,3,57,239,191,189,115,205,174,67,29,21,239,191,189,239,191,189,61,239,191,189,239,191,189,206,131,61,17,76,73,239,191,189,71,71,239,191,189,70,239,191,189,239,191,189,50,10,42,239,191,189,111,45,239,191,189,239,191,189,49,239,191,189,239,191,189,239,191,189,115,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,41,105,52,225,141,166,122,88,117,239,191,189,239,191,189,239,191,189,3,44,59,239,191,189,16,19,239,191,189,43,239,191,189,15,57,15,239,191,189,239,191,189,79,75,216,178,46,239,191,189,239,191,189,9,28,40,239,191,189,80,125,239,191,189,10,22,239,191,189,10,11,62,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,107,5,25,48,37,69,239,191,189,86,47,127,239,191,189,124,12,66,239,191,189,15,19,50,239,191,189,239,191,189,104,32,121,87,46,4,93,80,239,191,189,239,191,189,59,44,239,191,189,1,69,3,2,239,191,189,126,11,239,191,189,44,219,150,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,118,107,239,191,189,239,191,189,69,74,239,191,189,239,191,189,2,33,239,191,189,84,239,191,189,110,68,239,191,189,239,191,189,11,239,191,189,239,191,189,12,28,239,191,189,239,191,189,239,191,189,59,69,239,191,189,97,239,191,189,5,96,239,191,189,239,191,189,73,239,191,189,100,239,191,189,239,191,189,239,191,189,119,64,239,191,189,93,35,239,191,189,100,108,82,95,239,191,189,239,191,189,0,239,191,189,239,191,189,90,239,191,189,19,53,9,4,239,191,189,97,97,27,239,191,189,239,191,189,239,191,189,37,116,49,35,79,1,126,239,191,189,38,85,239,191,189,57,239,191,189,217,143,1,239,191,189,17,96,11,56,239,191,189,24,81,126,239,191,189,239,191,189,239,191,189,223,148,65,239,191,189,239,191,189,121,71,239,191,189,46,239,191,189,239,191,189,239,191,189,40,239,191,189,52,98,239,191,189,239,191,189,50,43,25,95,119,10,38,239,191,189,239,191,189,53,91,223,165,239,191,189,11,239,191,189,239,191,189,19,239,191,189,87,93,239,191,189,239,191,189,239,191,189,86,109,97,239,191,189,96,239,191,189,239,191,189,207,130,239,191,189,202,180,127,28,55,117,75,239,191,189,17,239,191,189,78,239,191,189,7,239,191,189,120,239,191,189,78,239,191,189,239,191,189,213,153,104,239,191,189,33,239,191,189,197,180,80,122,239,191,189,16,34,28,65,239,191,189,109,118,239,191,189,126,12,239,191,189,239,191,189,46,239,191,189,103,102,109,106,117,25,104,64,222,171,48,76,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,119,239,191,189,239,191,189,61,239,191,189,239,191,189,124,125,43,113,16,239,191,189,64,25,57,6,239,191,189,53,87,73,239,191,189,97,60,239,191,189,68,113,16,239,191,189,121,123,65,239,191,189,117,29,239,191,189,80,71,239,191,189,124,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,47,70,107,22,18,239,191,189,64,101,89,77,239,191,189,52,239,191,189,108,239,191,189,121,239,191,189,239,191,189,4,239,191,189,48,66,34,34,47,239,191,189,29,239,191,189,239,191,189,91,239,191,189,116,70,239,191,189,239,191,189,6,239,191,189,239,191,189,239,191,189,58,239,191,189,116,39,239,191,189,239,191,189,239,191,189,239,191,189,21,3,26,32,239,191,189,61,239,191,189,239,191,189,36,72,239,191,189,41,46,35,239,191,189,239,191,189,239,191,189,239,191,189,90,204,137,114,239,191,189,48,121,117,84,239,191,189,239,191,189,239,191,189,122,56,239,191,189,8,239,191,189,239,191,189,59,239,191,189,55,239,191,189,239,191,189,217,189,19,115,93,23,47,239,191,189,54,239,191,189,239,191,189,85,14,239,191,189,239,191,189,114,239,191,189,121,239,191,189,113,31,42,239,191,189,108,239,191,189,74,27,239,191,189,60,239,191,189,198,136,239,191,189,25,239,191,189,239,191,189,239,191,189,239,191,189,27,93,36,22,239,191,189,215,133,239,191,189,239,191,189,123,37,14,74,119,111,15,239,191,189,239,191,189,21,239,191,189,239,191,189,19,239,191,189,57,123,127,2,108,123,239,191,189,239,191,189,239,191,189,239,191,189,51,94,106,76,9,102,239,191,189,239,191,189,13,116,239,191,189,239,191,189,45,108,79,25,202,134,1,239,191,189,239,191,189,58,8,97,239,191,189,68,239,191,189,24,103,239,191,189,74,47,23,25,4,194,138,72,69,239,191,189,117,239,191,189,93,105,77,19,239,191,189,82,239,191,189,110,239,191,189,59,239,191,189,239,191,189,85,9,97,110,33,239,191,189,206,165,239,191,189,239,191,189,239,191,189,239,191,189,84,53,21,8,239,191,189,239,191,189,90,46,239,191,189,105,3,239,191,189,77,49,32,197,182,114,239,191,189,15,62,29,239,191,189,239,191,189,97,28,38,72,239,191,189,239,191,189,11,93,239,191,189,79,239,191,189,126,61,239,191,189,115,34,239,191,189,239,191,189,52,239,191,189,5,239,191,189,32,239,191,189,239,191,189,8,239,191,189,33,58,118,239,191,189,54,113,26,239,191,189,223,145,17,62,239,191,189,94,239,191,189,239,191,189,239,191,189,114,239,191,189,239,191,189,14,239,191,189,239,191,189,46,124,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,108,239,191,189,239,191,189,239,191,189,34,109,239,191,189,239,191,189,13,35,1,239,191,189,239,191,189,207,131,64,239,191,189,95,66,35,125,58,239,191,189,239,191,189,34,239,191,189,72,66,77,239,191,189,36,37,239,191,189,91,239,191,189,87,20,116,239,191,189,47,109,239,191,189,100,12,107,17,95,239,191,189,239,191,189,74,239,191,189,62,216,184,50,102,239,191,189,199,137,37,77,58,116,239,191,189,220,175,53,42,43,43,25,239,191,189,18,239,191,189,239,191,189,239,191,189,28,212,183,239,191,189,239,191,189,72,239,191,189,78,239,191,189,239,191,189,11,239,191,189,113,239,191,189,21,239,191,189,239,191,189,10,31,239,191,189,32,101,48,239,191,189,239,191,189,52,239,191,189,125,49,239,191,189,43,34,37,239,191,189,74,42,16,2,60,5,239,191,189,37,112,239,191,189,239,191,189,239,191,189,58,22,108,239,191,189,8,239,191,189,226,133,182,239,191,189,239,191,189,239,191,189,239,191,189,122,39,29,211,187,239,191,189,126,239,191,189,239,191,189,239,191,189,239,191,189,26,26,239,191,189,239,191,189,59,24,74,124,239,191,189,102,239,191,189,239,191,189,35,239,191,189,66,8,239,191,189,239,191,189,21,88,239,191,189,239,191,189,110,8,239,191,189,57,239,191,189,19,211,146,44,239,191,189,239,191,189,57,124,199,138,239,191,189,104,239,191,189,95,55,239,191,189,239,191,189,87,239,191,189,239,191,189,93,59,239,191,189,20,99,239,191,189,239,191,189,70,239,191,189,239,191,189,239,191,189,89,1,93,55,239,191,189,1,58,239,191,189,239,191,189,239,191,189,15,123,125,239,191,189,29,50,239,191,189,81,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,93,239,191,189,239,191,189,126,239,191,189,72,75,239,191,189,239,191,189,27,239,191,189,104,102,239,191,189,40,239,191,189,239,191,189,97,11,239,191,189,78,239,191,189,94,66,70,84,239,191,189,239,191,189,239,191,189,239,191,189,65,239,191,189,96,0,94,239,191,189,239,191,189,114,239,191,189,239,191,189,239,191,189,34,96,239,191,189,105,239,191,189,239,191,189,239,191,189,194,191,40,78,239,191,189,239,191,189,14,24,239,191,189,60,239,191,189,239,191,189,239,191,189,1,29,86,239,191,189,6,239,191,189,239,191,189,239,191,189,98,19,239,191,189,104,239,191,189,43,95,121,216,142,239,191,189,239,191,189,50,44,239,191,189,239,191,189,33,108,239,191,189,70,25,70,239,191,189,239,191,189,239,191,189,33,67,239,191,189,239,191,189,239,191,189,41,5,239,191,189,93,21,239,191,189,45,59,239,191,189,30,100,239,191,189,77,239,191,189,239,191,189,239,191,189,71,98,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,27,35,239,191,189,106,239,191,189,10,28,239,191,189,31,239,191,189,124,239,191,189,76,206,191,88,239,191,189,49,15,239,191,189,239,191,189,239,191,189,239,191,189,108,46,42,75,239,191,189,44,42,23,239,191,189,239,191,189,35,65,239,191,189,239,191,189,122,216,157,53,68,21,239,191,189,239,191,189,127,6,239,191,189,10,239,191,189,103,239,191,189,239,191,189,239,191,189,57,39,239,191,189,59,239,191,189,239,191,189,32,239,191,189,239,191,189,239,191,189,239,191,189,78,41,239,191,189,205,185,47,239,191,189,55,239,191,189,197,157,239,191,189,48,239,191,189,69,115,34,239,191,189,239,191,189,21,239,191,189,91,7,239,191,189,17,239,191,189,239,191,189,25,124,121,79,77,239,191,189,86,121,239,191,189,80,107,239,191,189,75,6,2,239,191,189,63,239,191,189,10,239,191,189,121,239,191,189,239,191,189,101,24,239,191,189,239,191,189,205,133,3,239,191,189,239,191,189,239,191,189,29,115,75,77,239,191,189,239,191,189,239,191,189,83,203,185,239,191,189,35,239,191,189,201,132,88,107,239,191,189,31,125,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,53,26,239,191,189,239,191,189,239,191,189,239,191,189,45,239,191,189,239,191,189,79,239,191,189,64,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,66,25,6,62,117,26,120,239,191,189,41,239,191,189,126,239,191,189,107,99,100,239,191,189,239,191,189,239,191,189,239,191,189,3,42,95,34,239,191,189,239,191,189,28,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,24,239,191,189,28,20,239,191,189,19,239,191,189,62,30,239,191,189,0,239,191,189,239,191,189,74,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,107,77,239,191,189,239,191,189,239,191,189,239,191,189,54,123,239,191,189,239,191,189,83,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,34,239,191,189,239,191,189,86,48,239,191,189,52,239,191,189,239,191,189,27,239,191,189,123,239,191,189,37,239,191,189,97,63,218,171,115,100,239,191,189,34,42,239,191,189,47,239,191,189,40,20,20,239,191,189,43,239,191,189,31,239,191,189,127,77,124,239,191,189,239,191,189,118,59,239,191,189,113,239,191,189,239,191,189,239,191,189,34,217,130,119,36,24,239,191,189,96,239,191,189,239,191,189,239,191,189,95,1,239,191,189,12,239,191,189,126,69,239,191,189,239,191,189,80,41,19,239,191,189,13,239,191,189,239,191,189,40,239,191,189,239,191,189,82,32,54,239,191,189,79,239,191,189,239,191,189,239,191,189,18,239,191,189,239,191,189,55,239,191,189,120,29,239,191,189,68,106,85,104,43,22,239,191,189,83,210,175,110,239,191,189,23,92,239,191,189,55,0,24,239,191,189,63,239,191,189,211,188,84,225,146,175,239,191,189,239,191,189,25,116,239,191,189,239,191,189,64,119,239,191,189,239,191,189,52,239,191,189,59,51,239,191,189,4,239,191,189,35,232,155,182,93,239,191,189,55,239,191,189,239,191,189,239,191,189,1,113,239,191,189,0,239,191,189,239,191,189,103,239,191,189,110,239,191,189,59,239,191,189,15,239,191,189,239,191,189,9,100,204,146,71,11,239,191,189,239,191,189,29,48,239,191,189,239,191,189,239,191,189,239,191,189,94,239,191,189,215,165,239,191,189,63,6,239,191,189,210,173,239,191,189,239,191,189,56,117,75,100,80,239,191,189,239,191,189,239,191,189,84,34,107,10,239,191,189,239,191,189,26,239,191,189,239,191,189,207,141,239,191,189,111,103,15,239,191,189,99,44,72,239,191,189,239,191,189,36,239,191,189,30,239,191,189,115,239,191,189,114,239,191,189,239,191,189,239,191,189,32,50,38,63,59,119,239,191,189,239,191,189,239,191,189,36,99,83,3,31,74,100,239,191,189,101,116,0,35,239,191,189,45,239,191,189,47,239,191,189,76,99,58,239,191,189,239,191,189,31,239,191,189,239,191,189,109,111,72,39,239,191,189,95,239,191,189,53,85,114,122,208,142,239,191,189,92,14,2,13,14,239,191,189,239,191,189,239,191,189,4,50,15,239,191,189,42,105,239,191,189,239,191,189,124,68,124,19,239,191,189,239,191,189,27,239,191,189,239,191,189,21,106,239,191,189,58,239,191,189,121,94,2,76,7,43,239,191,189,239,191,189,16,32,51,239,191,189,107,22,23,42,52,45,119,97,239,191,189,53,84,123,77,239,191,189,239,191,189,89,124,239,191,189,77,239,191,189,85,72,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,51,91,239,191,189,239,191,189,111,5,239,191,189,101,239,191,189,61,118,239,191,189,239,191,189,67,10,239,191,189,239,191,189,239,191,189,57,239,191,189,29,23,239,191,189,102,239,191,189,34,93,103,239,191,189,86,239,191,189,239,191,189,105,19,2,239,191,189,239,191,189,120,18,239,191,189,239,191,189,23,24,16,86,123,239,191,189,117,239,191,189,32,239,191,189,239,191,189,88,85,239,191,189,28,239,191,189,121,77,76,239,191,189,42,239,191,189,114,239,191,189,112,239,191,189,65,17,239,191,189,115,75,239,191,189,6,239,191,189,239,191,189,16,12,239,191,189,239,191,189,239,191,189,99,120,239,191,189,20,79,239,191,189,111,34,43,239,191,189,69,239,191,189,53,239,191,189,239,191,189,239,191,189,11,239,191,189,52,239,191,189,52,87,105,12,122,239,191,189,28,239,191,189,104,65,239,191,189,239,191,189,105,126,17,239,191,189,1,92,97,91,239,191,189,239,191,189,92,239,191,189,5,60,239,191,189,112,35,74,1,205,180,43,46,33,239,191,189,239,191,189,239,191,189,239,191,189,200,167,239,191,189,239,191,189,24,239,191,189,52,239,191,189,125,26,196,174,111,239,191,189,239,191,189,107,239,191,189,239,191,189,6,62,239,191,189,239,191,189,30,64,239,191,189,10,62,79,239,191,189,239,191,189,239,191,189,239,191,189,208,146,239,191,189,14,114,239,191,189,127,7,24,239,191,189,9,239,191,189,82,94,239,191,189,56,239,191,189,38,239,191,189,123,90,239,191,189,28,2,239,191,189,239,191,189,57,123,239,191,189,103,239,191,189,27,67,239,191,189,70,239,191,189,93,239,191,189,38,239,191,189,54,213,184,239,191,189,239,191,189,239,191,189,47,6,239,191,189,239,191,189,53,4,104,44,117,239,191,189,115,239,191,189,91,4,17,239,191,189,102,239,191,189,66,103,239,191,189,239,191,189,63,101,239,191,189,239,191,189,239,191,189,35,239,191,189,99,103,2,239,191,189,239,191,189,76,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,115,239,191,189,0,239,191,189,239,191,189,202,130,37,36,82,239,191,189,86,239,191,189,194,153,239,191,189,39,44,239,191,189,16,68,93,18,239,191,189,113,11,239,191,189,239,191,189,33,214,163,7,2,239,191,189,75,239,191,189,63,124,239,191,189,239,191,189,113,239,191,189,239,191,189,16,239,191,189,239,191,189,54,239,191,189,239,191,189,41,239,191,189,239,191,189,84,46,62,21,239,191,189,111,120,239,191,189,38,239,191,189,3,77,239,191,189,239,191,189,83,239,191,189,118,212,134,239,191,189,80,239,191,189,239,191,189,69,239,191,189,1,239,191,189,239,191,189,213,174,5,239,191,189,34,12,239,191,189,212,165,54,7,239,191,189,4,39,239,191,189,239,191,189,239,191,189,92,97,20,88,239,191,189,126,222,162,8,70,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,239,191,189,120,239,191,189,11,43,239,191,189,239,191,189,127,239,191,189,64,204,182,239,191,189,40,6,239,191,189,74,85,239,191,189,239,191,189,107,66,47,38,86,25,239,191,189,24,68,239,191,189,239,191,189,74,54,80,73,57,239,191,189,239,191,189,49,239,191,189,34,217,151,61,17,239,191,189,98,30,239,191,189,239,191,189,239,191,189,13,29,239,191,189,71,239,191,189,72,239,191,189,239,191,189,17,239,191,189,239,191,189,59,80,109,239,191,189,239,191,189,86,239,191,189,239,191,189,23,90,36})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff5575e914",
                        container: "containersa62ca518070c48d78c2dfe694e7d7aa2",
                        blob: "Blobe529120c9ba24b6d882e63fe663f0c69_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=25088-67071",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06665 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06665_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06665_s.txt", Encoding.UTF8);

    public Test06665() : base(recordedRequest, recordedResponse, "accounts8d439ff51b86529")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,239,191,189,199,145,239,191,189,88,239,191,189,239,191,189,239,191,189,16,239,191,189,52,239,191,189,239,191,189,239,191,189,104,239,191,189,112,59,123,116,36,4,239,191,189,67,239,191,189,0,74,239,191,189,83,239,191,189,52,5,239,191,189,42,109,239,191,189,124,239,191,189,239,191,189,104,31,100,202,131,29,239,191,189,63,199,132,239,191,189,239,191,189,5,91,239,191,189,111,239,191,189,7,77,239,191,189,87,60,53,119,58,239,191,189,47,239,191,189,112,112,239,191,189,120,239,191,189,61,18,84,239,191,189,57,60,38,67,239,191,189,239,191,189,29,239,191,189,239,191,189,47,239,191,189,99,239,191,189,239,191,189,239,191,189,46,239,191,189,44,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,86,239,191,189,81,95,239,191,189,72,63,239,191,189,99,239,191,189,39,239,191,189,239,191,189,239,191,189,24,239,191,189,89,112,239,191,189,94,239,191,189,239,191,189,239,191,189,74,239,191,189,239,191,189,239,191,189,107,211,170,89,55,99,239,191,189,43,29,56,239,191,189,104,97,36,13,108,18,6,46,15,114,239,191,189,239,191,189,54,114,105,239,191,189,25,239,191,189,87,7,239,191,189,47,98,239,191,189,219,185,113,239,191,189,81,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,7,35,58,239,191,189,51,239,191,189,67,239,191,189,239,191,189,115,239,191,189,239,191,189,116,239,191,189,239,191,189,239,191,189,239,191,189,117,239,191,189,48,239,191,189,57,239,191,189,80,49,239,191,189,239,191,189,22,239,191,189,108,239,191,189,239,191,189,75,94,106,69,71,113,239,191,189,239,191,189,239,191,189,42,239,191,189,239,191,189,57,8,69,239,191,189,32,112,239,191,189,24,53,239,191,189,2,239,191,189,36,239,191,189,118,239,191,189,239,191,189,44,239,191,189,28,239,191,189,196,136,21,124,239,191,189,239,191,189,103,239,191,189,3,108,239,191,189,239,191,189,16,22,40,109,22,239,191,189,109,239,191,189,203,159,239,191,189,92,239,191,189,33,93,239,191,189,1,204,151,239,191,189,239,191,189,94,117,239,191,189,48,14,239,191,189,239,191,189,97,38,50,23,88,60,19,239,191,189,77,19,239,191,189,54,56,121,239,191,189,36,239,191,189,239,191,189,239,191,189,104,59,108,239,191,189,55,239,191,189,37,7,239,191,189,239,191,189,239,191,189,60,8,94,239,191,189,65,239,191,189,109,239,191,189,4,95,14,239,191,189,239,191,189,239,191,189,239,191,189,96,76,17,239,191,189,81,239,191,189,119,46,47,239,191,189,239,191,189,53,239,191,189,65,51,53,97,51,239,191,189,239,191,189,239,191,189,215,162,56,31,239,191,189,17,239,191,189,239,191,189,89,239,191,189,239,191,189,3,72,116,239,191,189,239,191,189,23,79,239,191,189,239,191,189,239,191,189,47,239,191,189,75,111,114,110,239,191,189,42,239,191,189,86,8,23,24,239,191,189,239,191,189,239,191,189,123,239,191,189,239,191,189,194,173,239,191,189,239,191,189,54,49,239,191,189,239,191,189,90,62,73,239,191,189,17,239,191,189,239,191,189,239,191,189,239,191,189,68,239,191,189,239,191,189,86,239,191,189,91,239,191,189,239,191,189,48,239,191,189,46,28,239,191,189,239,191,189,58,2,45,89,17,20,62,239,191,189,239,191,189,118,239,191,189,99,114,75,5,28,239,191,189,3,239,191,189,239,191,189,86,11,239,191,189,86,40,239,191,189,239,191,189,69,239,191,189,239,191,189,44,34,239,191,189,46,239,191,189,14,239,191,189,78,239,191,189,239,191,189,113,239,191,189,1,109,107,73,239,191,189,106,239,191,189,19,10,43,47,239,191,189,95,46,35,239,191,189,49,239,191,189,239,191,189,239,191,189,62,239,191,189,74,201,182,68,239,191,189,239,191,189,78,239,191,189,109,21,90,239,191,189,9,113,239,191,189,223,165,22,95,110,239,191,189,0,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,28})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff51b86529",
                        container: "containers6de0c8d29fa6436eaf038e0fa62a4892",
                        blob: Encoding.UTF8.GetString(new byte[]{66,108,111,98,56,53,48,99,53,53,100,52,57,53,52,54,52,50,102,101,56,53,52,52,54,97,98,52,102,97,51,100,55,48,97,51,95,76,105,110,107,66,108,111,98,207,168}),
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06473 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06473_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06473_s.txt", Encoding.UTF8);

    public Test06473() : base(recordedRequest, recordedResponse, "accounts8d439ff45ecbfee")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,57,100,38,16,51,66,239,191,189,239,191,189,239,191,189,35,239,191,189,58,239,191,189,239,191,189,209,130,65,239,191,189,126,239,191,189,100,239,191,189,5,239,191,189,0,86,239,191,189,239,191,189,82,107,93,239,191,189,239,191,189,14,125,239,191,189,239,191,189,40,239,191,189,106,239,191,189,239,191,189,59,39,26,239,191,189,63,93,53,47,45,239,191,189,195,169,45,239,191,189,94,40,15,239,191,189,118,239,191,189,119,103,239,191,189,92,94,126,118,219,148,25,11,20,60,239,191,189,108,239,191,189,239,191,189,44,23,110,239,191,189,35,61,239,191,189,239,191,189,49,239,191,189,239,191,189,239,191,189,24,239,191,189,239,191,189,239,191,189,53,239,191,189,97,239,191,189,118,239,191,189,239,191,189,89,239,191,189,19,239,191,189,239,191,189,109,117,36,239,191,189,68,239,191,189,239,191,189,8,83,83,41,239,191,189,239,191,189,44,239,191,189,239,191,189,69,239,191,189,0,103,32,112,239,191,189,239,191,189,124,38,239,191,189,86,239,191,189,69,239,191,189,42,73,34,239,191,189,107,239,191,189,21,239,191,189,53,239,191,189,239,191,189,120,239,191,189,105,50,73,35,92,20,239,191,189,18,28,239,191,189,239,191,189,239,191,189,3,30,45,110,239,191,189,13,239,191,189,239,191,189,239,191,189,104,104,49,239,191,189,47,79,203,136,52,239,191,189,239,191,189,239,191,189,19,239,191,189,108,51,42,49,239,191,189,23,45,239,191,189,239,191,189,120,59,18,97,7,112,106,106,22,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,123,70,239,191,189,89,3,81,239,191,189,239,191,189,42,239,191,189,59,86,239,191,189,12,239,191,189,213,159,239,191,189,239,191,189,29,239,191,189,239,191,189,23,201,142,239,191,189,64,87,42,239,191,189,65,239,191,189,76,66,208,153,57,239,191,189,39,239,191,189,33,54,71,53,20,239,191,189,9,239,191,189,58,239,191,189,65,56,20,199,140,239,191,189,124,239,191,189,117,239,191,189,94,239,191,189,0,52,239,191,189,198,143,239,191,189,22,239,191,189,218,146,239,191,189,239,191,189,239,191,189,124,239,191,189,0,239,191,189,123,28,53,74,9,123,239,191,189,239,191,189,77,28,239,191,189,79,96,62,239,191,189,53,18,60,78,239,191,189,63,239,191,189,82,88,102,239,191,189,42,239,191,189,239,191,189,6,239,191,189,239,191,189,116,69,239,191,189,124,239,191,189,239,191,189,239,191,189,74,9,19,239,191,189,239,191,189,239,191,189,49,239,191,189,115,239,191,189,105,239,191,189,103,2,65,239,191,189,239,191,189,239,191,189,239,191,189,99,81,239,191,189,239,191,189,71,239,191,189,239,191,189,239,191,189,27,91,11,106,39,76,3,239,191,189,43,239,191,189,102,239,191,189,116,126,87,83,239,191,189,239,191,189,115,113,3,21,239,191,189,239,191,189,7,239,191,189,239,191,189,78,50,239,191,189,72,35,239,191,189,22,79,103,22,65,89,99,13,21,239,191,189,66,118,6,239,191,189,239,191,189,99,239,191,189,239,191,189,239,191,189,91,105,23,70,89,124,32,239,191,189,11,239,191,189,239,191,189,100,62,66,45,94,46,239,191,189,60,90,239,191,189,15,100,239,191,189,45,112,120,0,239,191,189,37,239,191,189,214,186,239,191,189,69,239,191,189,9,14,239,191,189,33,239,191,189,88,104,28,239,191,189,3,51,217,145,239,191,189,115,81,79,239,191,189,75,5,41,25,239,191,189,4,31,35,239,191,189,84,239,191,189,239,191,189,122,239,191,189,95,37,239,191,189,57,0,239,191,189,239,191,189,209,170,108,68,39,11,239,191,189,120,83,239,191,189,239,191,189,124,63,239,191,189,239,191,189,37,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff45ecbfee",
                        container: "containers17739abe296e45808e1fcc953bc819e9",
                        blob: "Blobd3b6b7dcb4994257baa4cf29725c556d_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06523 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06523_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06523_s.txt", Encoding.UTF8);

    public Test06523() : base(recordedRequest, recordedResponse, "accounts8d439ff4781e1e2")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,51,239,191,189,117,73,239,191,189,239,191,189,45,239,191,189,239,191,189,109,239,191,189,239,191,189,81,45,239,191,189,64,100,112,239,191,189,239,191,189,51,119,36,239,191,189,76,239,191,189,31,239,191,189,106,239,191,189,13,239,191,189,239,191,189,239,191,189,52,56,33,74,61,63,13,239,191,189,239,191,189,205,132,111,42,100,107,67,114,56,239,191,189,40,115,239,191,189,112,239,191,189,239,191,189,48,239,191,189,107,239,191,189,84,95,51,239,191,189,97,239,191,189,117,31,25,51,239,191,189,208,160,239,191,189,87,1,239,191,189,97,239,191,189,86,39,32,239,191,189,239,191,189,239,191,189,124,119,239,191,189,50,77,12,103,239,191,189,0,239,191,189,110,80,239,191,189,239,191,189,106,239,191,189,36,88,5,239,191,189,88,239,191,189,49,25,239,191,189,31,239,191,189,28,20,106,51,239,191,189,66,19,229,129,173,239,191,189,239,191,189,38,59,46,239,191,189,239,191,189,239,191,189,80,239,191,189,80,95,3,239,191,189,239,191,189,239,191,189,118,239,191,189,69,239,191,189,69,46,60,75,239,191,189,239,191,189,100,239,191,189,14,120,239,191,189,239,191,189,72,55,239,191,189,222,187,42,50,64,48,60,239,191,189,55,204,180,102,108,239,191,189,71,239,191,189,59,59,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,4,239,191,189,215,179,103,23,239,191,189,58,239,191,189,63,75,118,5,125,9,95,4,126,239,191,189,46,239,191,189,41,239,191,189,220,168,239,191,189,73,239,191,189,239,191,189,239,191,189,203,137,39,239,191,189,43,239,191,189,239,191,189,239,191,189,100,239,191,189,239,191,189,50,239,191,189,7,81,239,191,189,54,239,191,189,239,191,189,62,239,191,189,113,239,191,189,220,148,239,191,189,239,191,189,239,191,189,11,239,191,189,239,191,189,59,74,239,191,189,116,239,191,189,79,82,82,112,104,239,191,189,26,58,239,191,189,239,191,189,97,239,191,189,239,191,189,239,191,189,118,239,191,189,239,191,189,13,89,239,191,189,74,30,80,239,191,189,239,191,189,120,239,191,189,239,191,189,95,239,191,189,202,147,239,191,189,117,239,191,189,47,45,239,191,189,101,87,239,191,189,73,239,191,189,121,28,112,40,67,5,72,239,191,189,239,191,189,26,2,5,51,1,239,191,189,109,7,111,105,52,221,151,43,239,191,189,110,239,191,189,239,191,189,239,191,189,218,167,2,49,1,79,215,161,239,191,189,80,103,239,191,189,22,78,239,191,189,121,239,191,189,111,239,191,189,46,122,105,94,239,191,189,36,20,239,191,189,239,191,189,239,191,189,116,239,191,189,239,191,189,109,239,191,189,239,191,189,72,23,239,191,189,4,239,191,189,42,17,239,191,189,8,239,191,189,29,239,191,189,239,191,189,239,191,189,111,239,191,189,239,191,189,105,74,113,73,26,12,239,191,189,93,239,191,189,239,191,189,21,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,97,239,191,189,107,239,191,189,4,105,239,191,189,239,191,189,223,134,239,191,189,99,36,62,4,239,191,189,239,191,189,3,56,77,239,191,189,239,191,189,239,191,189,23,239,191,189,52,97,239,191,189,33,82,64,239,191,189,239,191,189,44,80,239,191,189,239,191,189,20,101,239,191,189,239,191,189,59,239,191,189,239,191,189,239,191,189,239,191,189,113,17,239,191,189,239,191,189,90,91,66,239,191,189,101,239,191,189,83,70,239,191,189,8,239,191,189,239,191,189,239,191,189,69,110,101,239,191,189,239,191,189,80,40,239,191,189,239,191,189,87,97,92,239,191,189,61,34,239,191,189,100,239,191,189,71,107,239,191,189,45,239,191,189,239,191,189,239,191,189,63,206,150,239,191,189,49,30,239,191,189,65,239,191,189,239,191,189,217,131,239,191,189,239,191,189,43,239,191,189,4,239,191,189,52,239,191,189,239,191,189,49,239,191,189,107,25})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff4781e1e2",
                        container: "containers997f513525fa4311b34441f08a39696f",
                        blob: "Blob0e98e52d63504365aa4499c37c54dbe4_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06758 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06758_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06758_s.txt", Encoding.UTF8);

    public Test06758() : base(recordedRequest, recordedResponse, "accounts8d439ff55b9d060")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,14,111,239,191,189,3,239,191,189,69,239,191,189,239,191,189,21,239,191,189,83,50,8,239,191,189,105,32,239,191,189,25,45,65,239,191,189,72,239,191,189,218,131,9,121,104,61,239,191,189,14,239,191,189,44,82,65,86,89,117,117,239,191,189,239,191,189,84,91,239,191,189,239,191,189,57,38,93,45,51,93,239,191,189,239,191,189,239,191,189,197,185,233,128,169,239,191,189,41,239,191,189,105,200,152,5,239,191,189,89,19,239,191,189,82,239,191,189,239,191,189,91,77,239,191,189,90,75,239,191,189,239,191,189,82,11,15,119,239,191,189,3,127,239,191,189,123,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,0,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,73,103,239,191,189,23,82,93,239,191,189,95,239,191,189,239,191,189,239,191,189,120,30,239,191,189,239,191,189,22,239,191,189,239,191,189,15,239,191,189,118,86,93,239,191,189,222,158,77,10,239,191,189,84,104,76,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,45,73,239,191,189,60,239,191,189,104,239,191,189,72,239,191,189,118,239,191,189,124,98,5,115,239,191,189,239,191,189,17,239,191,189,239,191,189,56,239,191,189,16,199,152,73,36,239,191,189,239,191,189,93,239,191,189,92,30,239,191,189,88,239,191,189,51,57,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,18,74,239,191,189,98,216,149,239,191,189,17,21,239,191,189,121,56,226,164,137,67,101,84,64,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,77,87,194,181,94,111,74,74,8,239,191,189,223,141,81,239,191,189,239,191,189,239,191,189,127,65,239,191,189,66,118,239,191,189,55,239,191,189,42,239,191,189,84,8,239,191,189,24,18,239,191,189,239,191,189,44,86,49,239,191,189,239,191,189,239,191,189,239,191,189,73,80,84,239,191,189,239,191,189,32,106,3,239,191,189,239,191,189,126,95,239,191,189,239,191,189,62,96,32,11,239,191,189,239,191,189,26,66,239,191,189,239,191,189,239,191,189,26,239,191,189,36,62,239,191,189,47,239,191,189,75,239,191,189,239,191,189,37,239,191,189,112,239,191,189,9,110,80,116,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,239,191,189,17,117,36,113,239,191,189,7,239,191,189,100,229,179,146,70,239,191,189,204,174,239,191,189,20,7,239,191,189,25,201,176,34,239,191,189,22,239,191,189,239,191,189,37,86,46,74,239,191,189,54,72,239,191,189,239,191,189,239,191,189,239,191,189,55,239,191,189,51,239,191,189,54,119,39,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,44,97,82,239,191,189,91,239,191,189,58,98,13,239,191,189,104,10,15,124,22,239,191,189,4,59,239,191,189,15,123,239,191,189,36,239,191,189,10,239,191,189,63,38,48,107,239,191,189,239,191,189,239,191,189,98,27,85,103,7,125,75,239,191,189,58,37,239,191,189,239,191,189,108,24,14,239,191,189,0,239,191,189,98,239,191,189,239,191,189,88,239,191,189,60,102,239,191,189,109,239,191,189,19,50,239,191,189,39,229,137,173,96,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,89,65,111,80,31,239,191,189,239,191,189,48,239,191,189,48,239,191,189,45,239,191,189,239,191,189,9,239,191,189,24,0,110,16,239,191,189,239,191,189,8,239,191,189,239,191,189,239,191,189,239,191,189,107,239,191,189,239,191,189,115,239,191,189,113,239,191,189,23,40,239,191,189,71,239,191,189,239,191,189,123,126,1,30,239,191,189,90,0,239,191,189,220,167,239,191,189,239,191,189,239,191,189,239,191,189,56,239,191,189,55,239,191,189,107,239,191,189,196,188,239,191,189,239,191,189,26,239,191,189,239,191,189,92,45,239,191,189,115,121,34,35,6,100,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,40,239,191,189,91,239,191,189,239,191,189,239,191,189,239,191,189,59,71,15,64,43,239,191,189,239,191,189,68,239,191,189,113,64,21,239,191,189,127,122,239,191,189,26,51,197,147,50,239,191,189,239,191,189,215,163,239,191,189,239,191,189,239,191,189,62,239,191,189,239,191,189,3,18,32,239,191,189,51,77,41,105,239,191,189,239,191,189,65,76,239,191,189,21,81,239,191,189,20,64,239,191,189,239,191,189,84,239,191,189,239,191,189,86,101,104,239,191,189,70,29,111,70,239,191,189,17,239,191,189,95,239,191,189,40,239,191,189,239,191,189,41,112,239,191,189,239,191,189,93,10,239,191,189,97,239,191,189,239,191,189,239,191,189,239,191,189,203,175,102,108,239,191,189,68,239,191,189,239,191,189,239,191,189,76,82,239,191,189,96,239,191,189,239,191,189,118,239,191,189,25,239,191,189,89,239,191,189,40,42,60,11,239,191,189,7,94,239,191,189,239,191,189,47,239,191,189,73,19,239,191,189,98,56,239,191,189,5,239,191,189,27,31,239,191,189,239,191,189,29,16,78,239,191,189,77,24,111,239,191,189,213,163,239,163,132,41,97,239,191,189,60,109,239,191,189,239,191,189,28,239,191,189,79,77,239,191,189,90,61,239,191,189,19,7,61,239,191,189,112,77,30,239,191,189,88,70,16,239,191,189,117,89,216,165,35,65,239,191,189,15,239,191,189,29,239,191,189,239,191,189,83,239,191,189,239,191,189,120,239,191,189,1,9,239,191,189,239,191,189,112,239,191,189,239,191,189,101,49,50,55,10,102,239,191,189,239,191,189,93,239,191,189,239,191,189,204,169,42,118,124,46,110,239,191,189,95,239,191,189,106,239,191,189,239,191,189,239,191,189,58,86,61,28,6,5,239,191,189,9,64,239,191,189,14,239,191,189,5,41,239,191,189,239,191,189,81,103,49,239,191,189,239,191,189,23,214,146,118,239,191,189,1,239,191,189,111,239,191,189,239,191,189,124,239,191,189,100,44,57,239,191,189,64,239,191,189,43,239,191,189,105,56,104,239,191,189,41,68,105,239,191,189,62,2,239,191,189,239,191,189,239,191,189,34,127,239,191,189,239,191,189,90,3,204,154,105,42,239,191,189,239,191,189,239,191,189,239,191,189,83,239,191,189,16,239,191,189,239,191,189,239,191,189,234,173,158,41,239,191,189,239,191,189,239,191,189,97,239,191,189,239,191,189,239,191,189,239,191,189,26,107,9,239,191,189,13,239,191,189,239,191,189,127,94,39,239,191,189,13,239,191,189,217,136,71,21,239,191,189,46,127,215,189,15,116,239,191,189,4,239,191,189,70,106,239,191,189,239,191,189,101,239,191,189,239,191,189,53,239,191,189,239,191,189,117,239,191,189,45,115,194,174,239,191,189,83,239,191,189,239,191,189,117,76,12,105,69,31,93,92,239,191,189,215,139,239,191,189,239,191,189,57,239,191,189,77,45,239,191,189,59,239,191,189,83,83,123,202,185,239,191,189,239,191,189,73,76,239,191,189,80,46,61,239,191,189,239,191,189,30,239,191,189,105,32,123,239,191,189,239,191,189,94,239,191,189,95,239,191,189,68,239,191,189,117,239,191,189,239,191,189,23,207,167,33,239,191,189,65,239,191,189,239,191,189,117,19,16,206,135,93,88,239,191,189,103,239,191,189,127,195,135,239,191,189,114,122,239,191,189,239,191,189,107,239,191,189,66,239,191,189,239,191,189,239,191,189,69,103,22,109,52,239,191,189,78,239,191,189,239,191,189,98,5,113,201,144,58,1,239,191,189,107,239,191,189,239,191,189,239,191,189,239,191,189,97,87,93,45,44,22,239,191,189,239,191,189,123,239,191,189,74,57,239,191,189,31,70,234,163,184,239,191,189,239,191,189,11,37,239,191,189,0,239,191,189,100,127,105,84,239,191,189,40,30,239,191,189,6,239,191,189,16,7,239,191,189,56,239,191,189,239,191,189,239,191,189,69,39,239,191,189,7,27,239,191,189,239,191,189,239,191,189,239,191,189,36,1,239,191,189,59,239,191,189,92,124,200,151,109,239,191,189,239,191,189,239,191,189,44,87,1,25,239,191,189,218,156,53,78,62,40,62,116,239,191,189,33,93,100,239,191,189,239,191,189,14,84,239,191,189,239,191,189,239,191,189,239,191,189,34,239,191,189,239,191,189,239,191,189,239,191,189,72,98,66,239,191,189,239,191,189,55,5,1,52,239,191,189,43,239,191,189,239,191,189,194,138,239,191,189,40,239,191,189,90,106,51,239,191,189,198,149,66,50,119,44,78,100,38,17,122,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,87,98,122,239,191,189,239,191,189,35,28,75,239,191,189,239,191,189,49,48,80,110,239,191,189,239,191,189,239,191,189,108,199,191,217,179,208,154,25,35,41,239,191,189,239,191,189,0,98,239,191,189,113,19,239,191,189,68,204,178,239,191,189,15,90,239,191,189,105,239,191,189,239,191,189,42,63,108,42,79,89,23,41,125,239,191,189,239,191,189,95,201,146,239,191,189,80,239,191,189,205,152,239,191,189,239,191,189,60,239,191,189,69,239,191,189,239,191,189,223,184,101,239,191,189,50,102,239,191,189,56,239,191,189,239,191,189,96,239,191,189,239,191,189,8,239,191,189,71,239,191,189,34,239,191,189,108,239,191,189,239,191,189,21,10,89,239,191,189,239,191,189,103,34,239,191,189,39,90,85,122,94,196,132,124,67,239,191,189,239,191,189,239,191,189,15,239,191,189,239,191,189,29,239,191,189,0,119,239,191,189,122,239,191,189,98,18,239,191,189,90,239,191,189,127,239,191,189,62,21,11,72,57,63,90,239,191,189,46,239,191,189,17,239,191,189,86,239,191,189,86,97,5,26,108,239,191,189,64,102,239,191,189,70,39,124,239,191,189,67,239,191,189,239,191,189,106,239,191,189,239,191,189,239,191,189,124,124,239,191,189,199,182,239,191,189,239,191,189,2,239,191,189,239,191,189,239,191,189,84,239,191,189,239,191,189,239,191,189,239,191,189,63,51,239,191,189,85,239,191,189,106,239,191,189,32,239,191,189,70,23,239,191,189,114,24,44,239,191,189,239,191,189,54,239,191,189,239,191,189,61,99,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,82,39,72,239,191,189,16,30,42,239,191,189,20,88,239,191,189,17,201,166,239,191,189,103,239,191,189,8,96,239,191,189,105,43,239,191,189,121,239,191,189,95,239,191,189,117,20,23,67,239,191,189,19,206,149,239,191,189,239,191,189,239,191,189,84,239,191,189,123,239,191,189,79,239,191,189,239,191,189,9,239,191,189,105,87,42,53,51,239,191,189,71,39,123,206,166,95,239,191,189,78,59,0,65,97,93,239,191,189,239,191,189,100,104,25,31,11,239,191,189,239,191,189,92,239,191,189,24,239,191,189,239,191,189,113,30,239,191,189,239,191,189,15,239,191,189,204,166,25,47,234,137,149,239,191,189,64,239,191,189,14,48,106,83,239,191,189,5,239,191,189,16,22,40,239,191,189,89,239,191,189,31,230,141,184,239,191,189,239,191,189,29,21,96,81,239,191,189,239,191,189,50,75,57,47,239,191,189,117,78,239,191,189,1,77,239,191,189,239,191,189,83,10,108,48,239,191,189,239,191,189,239,191,189,239,191,189,115,21,239,191,189,73,92,208,159,239,191,189,35,126,239,191,189,239,191,189,239,191,189,105,239,191,189,239,191,189,239,191,189,239,191,189,127,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,45,239,191,189,100,239,191,189,112,239,191,189,59,239,191,189,105,239,191,189,118,28,81,239,191,189,239,191,189,239,191,189,214,140,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,126,239,191,189,122,239,191,189,75,53,75,200,134,40,27,124,107,239,191,189,81,54,66,25,117,75,239,191,189,111,105,239,191,189,14,239,191,189,239,191,189,19,31,12,49,84,24,122,109,239,191,189,114,67,72,52,78,239,191,189,239,191,189,40,239,191,189,85,90,34,58,84,64,239,191,189,99,124,239,191,189,14,73,239,191,189,239,191,189,89,56,239,191,189,121,239,191,189,239,191,189,99,239,191,189,69,239,191,189,239,191,189,239,191,189,239,191,189,65,239,191,189,67,239,191,189,64,239,191,189,95,239,191,189,239,191,189,239,191,189,204,171,239,191,189,94,115,239,191,189,89,239,191,189,239,191,189,21,6,28,50,11,239,191,189,104,220,165,239,191,189,64,239,191,189,34,126,239,191,189,54,9,239,191,189,49,50,239,191,189,95,221,173,74,239,191,189,239,191,189,111,239,191,189,32,6,239,191,189,26,102,239,191,189,61,239,191,189,14,239,191,189,239,191,189,239,191,189,239,191,189,51,58,239,191,189,239,191,189,239,191,189,29,239,191,189,40,106,239,191,189,39,239,191,189,59,239,191,189,40,110,239,191,189,53,42,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,118,121,239,191,189,239,191,189,106,58,239,191,189,44,239,191,189,34,84,8,239,191,189,239,191,189,239,191,189,239,191,189,11,126,239,191,189,42,48,21,77,38,239,191,189,239,191,189,239,191,189,231,173,175,239,191,189,91,17,239,191,189,87,239,191,189,111,32,239,191,189,73,120,239,191,189,239,191,189,76,239,191,189,44,239,191,189,86,54,239,191,189,126,27,5,239,191,189,102,97,44,239,191,189,41,239,191,189,60,239,191,189,126,239,191,189,48,239,191,189,239,191,189,36,74,15,69,239,191,189,239,191,189,75,239,191,189,239,191,189,239,191,189,0,239,191,189,239,191,189,28,239,191,189,239,191,189,239,191,189,48,239,191,189,85,239,191,189,31,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,239,191,189,11,239,191,189,28,239,191,189,53,92,12,39,239,191,189,239,191,189,90,239,191,189,222,191,239,191,189,43,64,239,191,189,239,191,189,239,191,189,42,239,191,189,239,191,189,89,239,191,189,118,5,84,239,191,189,239,191,189,239,191,189,239,191,189,61,21,239,191,189,239,191,189,239,191,189,239,191,189,79,239,191,189,239,191,189,239,191,189,83,239,191,189,124,239,191,189,239,191,189,95,36,87,90,83,61,121,114,106,239,191,189,239,191,189,239,191,189,239,191,189,86,239,191,189,239,191,189,223,159,239,191,189,124,239,191,189,36,239,191,189,71,71,83,239,191,189,239,191,189,239,191,189,76,38,239,191,189,9,212,165,48,53,79,239,191,189,239,191,189,196,163,48,47,33,2,239,191,189,105,239,191,189,239,191,189,115,239,191,189,239,191,189,30,239,191,189,58,80,15,18,239,191,189,76,239,191,189,239,191,189,30,239,191,189,239,191,189,239,191,189,234,177,134,100,239,191,189,239,191,189,239,191,189,239,191,189,37,239,191,189,37,69,195,136,20,239,191,189,239,191,189,40,239,191,189,239,191,189,239,191,189,107,239,191,189,37,60,239,191,189,71,68,239,191,189,18,239,191,189,61,21,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,239,191,189,102,239,191,189,69,239,191,189,239,191,189,239,191,189,60,239,191,189,107,29,68,239,191,189,239,191,189,2,239,191,189,69,239,191,189,62,83,92,239,191,189,115,83,239,191,189,30,239,191,189,47,29,208,183,40,239,191,189,40,239,191,189,73,37,52,59,111,101,239,191,189,217,180,239,191,189,6,67,19,239,191,189,114,239,191,189,75,239,191,189,239,191,189,79,239,191,189,95,99,239,191,189,2,239,191,189,30,239,191,189,239,191,189,79,87,12,125,239,191,189,32,113,3,239,191,189,239,191,189,43,239,191,189,239,191,189,21,24,239,191,189,28,102,93,1,239,191,189,100,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,71,239,191,189,37,239,191,189,125,239,191,189,54,239,191,189,17,82,68,72,239,191,189,239,191,189,36,88,239,191,189,78,116,93,239,191,189,239,191,189,239,191,189,239,191,189,23,239,191,189,239,191,189,111,239,191,189,94,239,191,189,239,191,189,18,239,191,189,239,191,189,117,223,151,105,110,239,191,189,84,11,239,191,189,239,191,189,239,191,189,239,191,189,120,57,42,115,51,239,191,189,79,239,191,189,239,191,189,114,239,191,189,239,191,189,239,191,189,198,169,87,239,191,189,122,126,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,51,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,31,239,191,189,2,56,5,239,191,189,239,191,189,239,191,189,239,191,189,22,66,23,29,239,191,189,239,191,189,86,73,239,191,189,39,239,191,189,85,45,110,125,36,94,239,191,189,239,191,189,239,191,189,239,191,189,9,239,191,189,239,191,189,239,191,189,239,191,189,224,168,177,127,71,28,100,115,239,191,189,107,21,27,6,91,71,45,111,1,108,239,191,189,50,239,191,189,19,239,191,189,239,191,189,239,191,189,239,191,189,55,12,94,239,191,189,70,239,191,189,8,117,239,191,189,11,239,191,189,239,191,189,57,239,191,189,239,191,189,201,184,73,239,191,189,201,155,127,239,191,189,116,239,191,189,106,239,191,189,92,239,191,189,10,239,191,189,112,54,45,103,84,239,191,189,239,191,189,27,239,191,189,239,191,189,33,239,191,189,93,51,41,55,239,191,189,90,93,239,191,189,13,74,239,191,189,48,239,191,189,239,191,189,239,191,189,19,84,25,11,1,239,191,189,52,3,239,191,189,239,191,189,117,239,191,189,122,239,191,189,203,181,216,186,239,191,189,48,54,239,191,189,124,239,191,189,58,239,191,189,239,191,189,98,239,191,189,118,54,106,239,191,189,239,191,189,8,239,191,189,204,155,32,239,191,189,41,48,239,191,189,239,191,189,69,239,191,189,239,191,189,45,66,239,191,189,239,191,189,118,60,200,165,82,239,191,189,120,239,191,189,83,239,191,189,239,191,189,23,36,93,10,232,136,166,34,239,191,189,61,239,191,189,239,191,189,7,6,51,239,191,189,91,239,191,189,239,191,189,239,191,189,32,87,239,191,189,239,191,189,45,35,76,239,191,189,239,191,189,84,239,191,189,239,191,189,36,87,25,105,70,58,239,191,189,89,239,191,189,31,239,191,189,239,191,189,220,134,239,191,189,239,191,189,30,0,28,29,239,191,189,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,59,239,191,189,82,239,191,189,115,204,146,239,191,189,239,191,189,201,145,32,21,113,70,0,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,55,239,191,189,69,31,239,191,189,89,220,170,93,239,191,189,30,239,191,189,239,191,189,21,44,16,239,191,189,17,239,191,189,84,111,239,191,189,8,22,239,191,189,239,191,189,18,239,191,189,239,191,189,53,99,239,191,189,88,239,191,189,93,199,135,114,8,239,191,189,239,191,189,239,191,189,239,191,189,61,83,239,191,189,51,239,191,189,239,191,189,211,179,81,239,191,189,66,96,59,239,191,189,46,98,239,191,189,71,70,239,191,189,40,117,239,191,189,62,74,239,191,189,100,239,191,189,239,191,189,8,30,103,239,191,189,57,239,191,189,239,191,189,13,124,122,239,191,189,239,191,189,17,239,191,189,22,34,34,35,88,16,18,75,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,112,239,191,189,239,191,189,101,74,50,73,239,191,189,239,191,189,239,191,189,2,239,191,189,107,84,122,239,191,189,122,11,239,191,189,99,239,191,189,40,39,239,191,189,65,48,113,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,239,191,189,102,239,191,189,79,200,180,58,74,32,74,239,191,189,239,191,189,126,44,239,191,189,239,191,189,100,239,191,189,71,239,191,189,74,36,26,239,191,189,82,10,27,70,99,239,191,189,107,239,191,189,239,191,189,49,20,112,87,239,191,189,73,239,191,189,239,191,189,117,239,191,189,67,239,191,189,94,83,239,191,189,239,191,189,239,191,189,239,191,189,58,85,239,191,189,81,66,239,191,189,239,191,189,117,239,191,189,31,4,239,191,189,116,239,191,189,4,239,191,189,77,24,121,239,191,189,239,191,189,124,89,239,191,189,239,191,189,45,239,191,189,12,239,191,189,239,191,189,239,191,189,239,191,189,54,49,97,20,239,191,189,239,191,189,239,191,189,239,191,189,36,239,191,189,239,191,189,217,184,239,191,189,239,191,189,239,191,189,239,191,189,6,123,45,15,213,189,239,191,189,239,191,189,124,21,239,191,189,239,191,189,239,191,189,239,191,189,101,4,62,79,239,191,189,239,191,189,108,70,239,191,189,209,164,221,139,10,28,239,191,189,21,91,72,239,191,189,12,113,239,191,189,96,116,101,38,100,239,191,189,69,72,239,191,189,239,191,189,54,115,239,191,189,68,113,13,15,239,191,189,52,239,191,189,62,49,239,191,189,112,239,191,189,95,106,239,191,189,37,56,67,239,191,189,239,191,189,92,239,191,189,239,191,189,61,119,7,239,191,189,67,239,191,189,0,49,85,239,191,189,105,102,239,191,189,78,57,21,239,191,189,239,191,189,105,47,239,191,189,239,191,189,67,4,82,239,191,189,35,107,105,239,191,189,127,86,102,239,191,189,207,152,239,191,189,239,191,189,95,239,191,189,48,239,191,189,26,76,239,191,189,3,239,191,189,239,191,189,239,191,189,45,239,191,189,38,239,191,189,71,71,51,2,54,239,191,189,100,239,191,189,200,170,23,18,0,12,126,239,191,189,239,191,189,44,109,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,14,79,239,191,189,76,108,59,239,191,189,88,99,239,191,189,79,239,191,189,100,239,191,189,116,239,191,189,81,239,191,189,239,191,189,112,53,239,191,189,3,239,191,189,88,93,239,191,189,239,191,189,239,191,189,62,239,191,189,97,108,61,239,191,189,239,191,189,239,191,189,24,40,239,191,189,239,191,189,239,191,189,239,191,189,71,239,191,189,239,191,189,61,239,191,189,98,99,239,191,189,107,239,191,189,42,76,239,191,189,239,191,189,14,239,191,189,112,239,191,189,37,10,239,191,189,28,38,239,191,189,239,191,189,239,191,189,56,115,90,239,191,189,118,53,239,191,189,39,98,32,239,191,189,239,191,189,25,239,191,189,74,99,1,123,201,154,239,191,189,36,25,239,191,189,67,31,239,191,189,60,239,191,189,239,191,189,22,87,43,239,191,189,42,239,191,189,74,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,161,239,191,189,72,239,191,189,239,191,189,26,239,191,189,239,191,189,239,191,189,2,19,90,94,120,87,239,191,189,127,87,239,191,189,10,95,239,191,189,115,239,191,189,90,239,191,189,82,48,239,191,189,10,68,239,191,189,43,34,239,191,189,239,191,189,64,123,69,239,191,189,106,239,191,189,56,239,191,189,22,239,191,189,68,53,239,191,189,73,16,92,10,239,191,189,121,239,191,189,18,239,191,189,101,239,191,189,239,191,189,122,239,191,189,232,189,128,47,60,214,190,107,4,17,200,159,239,191,189,106,207,154,239,191,189,122,28,61,239,191,189,239,191,189,239,191,189,71,239,191,189,239,191,189,239,191,189,239,191,189,21,123,239,191,189,239,191,189,80,239,191,189,103,8,95,52,239,191,189,12,74,65,67,239,191,189,239,191,189,66,239,191,189,239,191,189,79,239,191,189,60,113,239,191,189,239,191,189,239,191,189,239,191,189,50,55,239,191,189,239,191,189,209,175,79,26,239,191,189,4,93,114,239,191,189,9,239,191,189,239,191,189,71,3,7,16,68,239,191,189,116,43,75,239,191,189,24,97,16,239,191,189,127,116,44,239,191,189,27,30,239,191,189,112,239,191,189,81,121,89,239,191,189,68,239,191,189,239,191,189,51,239,191,189,2,56,239,191,189,239,191,189,34,239,191,189,21,121,106,239,191,189,239,191,189,55,239,191,189,239,191,189,102,239,191,189,239,191,189,239,191,189,12,239,191,189,239,191,189,239,191,189,239,191,189,111,239,191,189,239,191,189,239,191,189,48,78,92,127,84,94,239,191,189,239,191,189,239,191,189,9,9,6,239,191,189,74,239,191,189,26,239,191,189,239,191,189,239,191,189,102,239,191,189,93,39,49,52,79,239,191,189,116,213,140,8,96,73,28,40,124,239,191,189,90,0,119,66,21,239,191,189,2,239,191,189,40,239,191,189,239,191,189,215,156,239,191,189,105,35,239,191,189,110,239,191,189,88,34,41,239,191,189,20,39,19,125,1,239,191,189,91,45,239,191,189,26,55,102,127,25,36,239,191,189,239,191,189,36,239,191,189,11,239,191,189,239,191,189,56,239,191,189,239,191,189,60,127,239,191,189,41,36,239,191,189,48,120,99,27,2,8,1,239,191,189,239,191,189,113,42,239,191,189,101,111,239,191,189,9,239,191,189,239,191,189,40,51,123,30,239,191,189,39,239,191,189,239,191,189,239,191,189,98,105,239,191,189,127,239,191,189,239,191,189,118,53,7,239,191,189,8,239,191,189,239,191,189,35,239,191,189,63,63,239,191,189,239,191,189,239,191,189,70,239,191,189,51,239,191,189,10,1,239,191,189,68,18,239,191,189,59,239,191,189,39,65,239,191,189,124,239,191,189,239,191,189,239,191,189,239,191,189,58,239,191,189,82,239,191,189,239,191,189,90,15,239,191,189,222,152,101,239,191,189,6,239,191,189,239,191,189,54,3,116,239,191,189,5,49,35,102,123,120,239,191,189,239,191,189,239,191,189,68,79,77,47,25,239,191,189,11,239,191,189,239,191,189,59,47,239,191,189,239,191,189,51,8,239,191,189,239,191,189,32,239,191,189,239,191,189,70,239,191,189,125,239,191,189,239,191,189,239,191,189,23,123,239,191,189,37,58,205,138,119,239,191,189,74,54,239,191,189,34,117,239,191,189,85,239,191,189,69,239,191,189,36,239,191,189,239,191,189,94,239,191,189,239,191,189,127,204,148,239,191,189,98,239,191,189,51,89,38,239,191,189,86,9,22,239,191,189,239,191,189,86,18,239,191,189,239,191,189,239,191,189,84,239,191,189,74,20,239,191,189,36,55,12,239,191,189,21,39,29,49,239,191,189,239,191,189,0,239,191,189,121,44,121,3,55,239,191,189,239,191,189,239,191,189,76,239,191,189,80,21,205,149,75,239,191,189,7,61,239,191,189,239,191,189,239,191,189,13,62,239,191,189,38,239,191,189,17,239,191,189,56,215,132,58,239,191,189,97,239,191,189,119,68,239,191,189,28,3,201,141,239,191,189,115,239,191,189,239,191,189,205,128,239,191,189,125,41,84,57,126,116,108,239,191,189,239,191,189,239,191,189,122,239,191,189,77,116,44,22,60,108,239,191,189,239,191,189,91,107,33,125,239,191,189,239,191,189,104,203,177,46,239,191,189,239,191,189,47,0,90,239,191,189,45,239,191,189,99,239,191,189,239,191,189,25,20,63,47,70,209,186,97,239,191,189,7,34,239,191,189,51,239,191,189,197,129,3,35,48,239,191,189,239,191,189,89,196,147,239,191,189,239,191,189,21,239,191,189,127,239,191,189,75,239,191,189,239,191,189,127,100,239,191,189,239,191,189,57,239,191,189,239,191,189,115,239,191,189,11,239,191,189,239,191,189,239,191,189,68,239,191,189,107,42,101,51,16,24,239,191,189,79,239,191,189,105,73,239,191,189,239,191,189,225,182,187,42,18,239,191,189,87,33,239,191,189,202,158,79,58,239,191,189,78,239,191,189,239,191,189,239,191,189,0,239,191,189,78,20,239,191,189,239,191,189,197,155,102,239,191,189,84,6,239,191,189,58,36,239,191,189,239,191,189,85,45,109,239,191,189,71,239,191,189,115,239,191,189,96,239,191,189,239,191,189,239,191,189,30,113,115,239,191,189,239,191,189,72,239,191,189,239,191,189,17,239,191,189,101,118,77,239,191,189,239,191,189,239,191,189,239,191,189,100,43,239,191,189,76,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,119,68,31,239,191,189,239,191,189,72,52,239,191,189,86,61,239,191,189,58,17,239,191,189,67,87,8,102,239,191,189,59,239,191,189,239,191,189,101,98,239,191,189,56,239,191,189,120,239,191,189,33,239,191,189,239,191,189,7,239,191,189,85,205,182,239,191,189,239,191,189,5,125,239,191,189,113,239,191,189,115,239,191,189,107,239,191,189,87,239,191,189,239,191,189,239,191,189,239,191,189,52,239,191,189,222,188,42,239,191,189,118,239,191,189,27,52,239,191,189,97,50,98,239,191,189,118,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,239,191,189,198,171,102,239,191,189,109,239,191,189,5,239,191,189,95,122,239,191,189,239,191,189,239,191,189,88,38,239,191,189,239,191,189,239,191,189,60,23,17,239,191,189,41,239,191,189,62,239,191,189,0,239,191,189,239,191,189,239,191,189,120,63,52,239,191,189,99,239,191,189,16,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,217,135,239,191,189,44,239,191,189,101,239,191,189,239,191,189,39,239,191,189,239,191,189,8,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,38,7,118,1,115,239,191,189,43,239,191,189,69,126,239,191,189,33,239,191,189,119,239,191,189,239,191,189,65,6,239,191,189,15,239,191,189,80,100,239,191,189,24,239,191,189,239,191,189,91,94,239,191,189,114,239,191,189,239,191,189,121,239,191,189,92,239,191,189,102,239,191,189,123,56,72,239,191,189,50,203,130,27,92,29,64,239,191,189,206,167,239,191,189,213,162,239,191,189,117,90,23,59,239,191,189,239,191,189,239,191,189,87,41,239,191,189,239,191,189,239,191,189,239,191,189,90,239,191,189,234,148,155,8,125,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,62,29,9,239,191,189,80,52,239,191,189,239,191,189,239,191,189,113,11,239,191,189,63,239,191,189,96,239,191,189,218,161,239,191,189,29,100,239,191,189,239,191,189,239,191,189,239,191,189,18,45,239,191,189,36,207,179,197,144,239,191,189,90,239,191,189,239,191,189,239,191,189,115,89,17,239,191,189,239,191,189,52,84,239,191,189,239,191,189,239,191,189,239,191,189,31,239,191,189,105,47,239,191,189,55,40,239,191,189,61,6,239,191,189,239,191,189,2,239,191,189,70,37,239,191,189,68,239,191,189,5,38,239,191,189,103,239,191,189,82,239,191,189,239,191,189,76,239,191,189,239,191,189,48,38,239,191,189,239,191,189,11,38,120,239,191,189,239,191,189,239,191,189,239,191,189,108,239,191,189,79,239,191,189,42,77,15,239,191,189,239,191,189,16,239,191,189,239,191,189,87,82,239,191,189,239,191,189,239,191,189,58,239,191,189,16,127,214,176,41,18,42,58,239,191,189,31,239,191,189,4,65,50,44,239,191,189,65,3,25,239,191,189,239,191,189,239,191,189,1,120,21,17,54,60,239,191,189,239,191,189,239,191,189,239,191,189,87,239,191,189,239,191,189,27,239,191,189,239,191,189,38,239,191,189,0,19,16,239,191,189,31,12,69,239,191,189,42,86,100,239,191,189,239,191,189,103,239,191,189,111,126,93,239,191,189,23,239,191,189,239,191,189,125,239,191,189,202,172,89,78,17,101,110,239,191,189,114,239,191,189,239,191,189,100,89,9,204,175,17,98,28,239,191,189,10,239,191,189,12,115,239,191,189,56,55,15,239,191,189,18,239,191,189,239,191,189,24,84,95,239,191,189,55,25,239,191,189,239,191,189,239,191,189,80,239,191,189,239,191,189,239,191,189,26,4,239,191,189,74,44,239,191,189,30,96,239,191,189,239,191,189,239,191,189,76,239,191,189,116,44,55,206,168,239,191,189,90,239,191,189,75,4,239,191,189,239,191,189,120,239,191,189,113,39,198,185,90,28,239,191,189,239,191,189,52,239,191,189,196,158,55,115,49,87,239,191,189,239,191,189,239,191,189,92,239,191,189,196,189,46,239,191,189,215,150,239,191,189,239,191,189,239,191,189,239,191,189,105,239,191,189,239,191,189,57,239,191,189,6,98,48,70,239,191,189,239,191,189,239,191,189,9,9,239,191,189,239,191,189,239,191,189,239,191,189,112,6,65,27,83,239,191,189,105,239,191,189,16,239,191,189,239,191,189,239,191,189,239,191,189,52,239,191,189,91,239,191,189,84,239,191,189,239,191,189,91,239,191,189,64,110,22,239,191,189,239,191,189,44,36,239,191,189,79,239,191,189,23,219,142,239,191,189,39,239,191,189,239,191,189,0,239,191,189,99,239,191,189,223,170,239,191,189,61,239,191,189,213,173,30,51,32,211,152,239,191,189,239,191,189,239,191,189,4,239,191,189,239,191,189,61,115,113,51,214,154,216,166,239,191,189,51,81,239,191,189,239,191,189,40,239,191,189,239,191,189,97,196,128,118,9,87,119,239,191,189,27,239,191,189,67,66,239,191,189,29,85,239,191,189,239,191,189,32,239,191,189,239,132,171,239,191,189,239,191,189,100,29,239,191,189,122,239,191,189,111,90,239,191,189,239,191,189,76,100,14,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,24,70,86,239,191,189,239,191,189,239,191,189,222,189,211,165,239,191,189,8,18,239,191,189,239,191,189,17,239,191,189,92,239,191,189,239,191,189,239,191,189,52,239,191,189,239,191,189,94,239,191,189,70,15,239,191,189,73,239,191,189,243,147,147,141,239,191,189,239,191,189,34,61,239,191,189,16,239,191,189,239,191,189,20,239,191,189,58,239,191,189,30,239,191,189,23,239,191,189,239,191,189,62,108,18,239,191,189,239,191,189,3,239,191,189,239,191,189,11,91,239,191,189,21,126,34,98,239,191,189,66,239,191,189,30,97,239,191,189,15,127,239,191,189,12,36,10,40,16,239,191,189,94,33,239,191,189,85,38,123,239,191,189,220,133,58,4,98,239,191,189,89,41,239,191,189,239,191,189,239,191,189,239,191,189,30,239,191,189,33,107,239,191,189,239,191,189,92,239,191,189,56,239,191,189,120,239,191,189,110,239,191,189,91,239,191,189,239,191,189,33,40,239,191,189,239,191,189,239,191,189,102,68,239,191,189,93,64,127,38,91,239,191,189,104,127,108,239,191,189,239,191,189,60,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,12,65,239,191,189,239,191,189,52,91,96,96,239,191,189,239,191,189,239,191,189,36,110,221,135,64,90,239,191,189,107,239,191,189,92,16,121,2,239,191,189,127,239,191,189,18,239,191,189,110,49,239,191,189,75,113,55,239,191,189,239,191,189,123,74,239,191,189,239,191,189,42,239,191,189,239,191,189,239,191,189,109,94,46,22,96,239,191,189,125,209,153,239,191,189,199,146,25,239,191,189,239,191,189,78,239,191,189,36,95,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,120,222,146,239,191,189,239,191,189,49,58,239,191,189,105,239,191,189,18,98,239,191,189,14,67,239,191,189,122,239,191,189,59,239,191,189,53,98,239,191,189,48,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,112,239,191,189,74,239,191,189,239,191,189,90,239,191,189,239,191,189,103,239,191,189,60,40,60,239,191,189,55,106,239,191,189,21,27,86,95,36,106,8,66,124,239,191,189,112,54,239,191,189,239,191,189,239,191,189,239,191,189,233,161,170,239,191,189,22,239,191,189,233,163,139,112,121,239,191,189,12,38,239,191,189,239,191,189,65,239,191,189,239,191,189,116,107,239,191,189,76,77,66,91,5,93,107,239,191,189,239,191,189,57,65,239,191,189,83,1,239,191,189,239,191,189,202,136,50,239,191,189,211,179,239,191,189,105,54,86,10,120,239,191,189,239,191,189,239,191,189,61,83,85,93,86,239,191,189,239,191,189,239,191,189,56,211,165,64,93,239,191,189,239,191,189,239,191,189,107,111,239,191,189,18,65,239,191,189,239,191,189,239,191,189,91,239,191,189,37,239,191,189,82,239,191,189,239,191,189,239,191,189,76,239,191,189,67,239,191,189,239,191,189,47,123,14,1,239,191,189,121,239,191,189,14,239,191,189,12,239,191,189,239,191,189,26,13,239,191,189,239,191,189,239,191,189,69,239,191,189,239,191,189,239,191,189,1,126,239,191,189,239,191,189,56,69,17,239,191,189,239,191,189,72,239,191,189,68,59,239,191,189,239,191,189,17,239,191,189,63,239,191,189,239,191,189,239,191,189,239,191,189,122,43,56,239,191,189,59,239,191,189,115,116,239,191,189,109,239,191,189,45,239,191,189,120,39,110,52,239,191,189,76,239,191,189,104,98,239,191,189,239,191,189,209,146,33,199,170,68,239,191,189,50,86,239,191,189,27,239,191,189,0,95,239,191,189,218,128,47,239,191,189,102,84,13,239,191,189,98,239,191,189,44,10,239,191,189,60,239,191,189,99,24,123,98,19,239,191,189,197,171,239,191,189,122,239,191,189,239,191,189,239,191,189,74,93,121,109,239,191,189,23,114,60,56,239,191,189,73,239,191,189,196,155,239,191,189,239,191,189,126,57,239,191,189,239,191,189,105,78,2,51,239,191,189,76,44,21,239,191,189,102,14,201,152,54,239,191,189,5,112,239,191,189,53,239,191,189,202,176,43,63,49,239,191,189,79,13,6,239,191,189,75,64,239,191,189,239,191,189,109,239,191,189,90,70,208,136,239,191,189,93,103,239,191,189,239,191,189,127,239,191,189,239,191,189,109,239,191,189,3,64,43,239,191,189,34,239,191,189,1,239,191,189,239,191,189,31,14,7,27,239,191,189,42,239,191,189,200,176,239,191,189,41,239,191,189,239,191,189,109,72,89,116,239,191,189,239,191,189,239,191,189,30,77,95,239,191,189,60,95,239,191,189,239,191,189,217,151,69,21,239,191,189,239,191,189,78,96,239,191,189,239,191,189,85,22,239,191,189,62,15,68,239,191,189,86,111,239,191,189,112,239,191,189,79,78,239,191,189,58,1,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,54,19,239,191,189,19,239,191,189,239,191,189,33,5,30,239,191,189,118,92,239,191,189,239,191,189,239,191,189,61,27,239,191,189,239,191,189,239,191,189,239,191,189,69,15,71,239,191,189,83,81,202,141,239,191,189,38,109,239,191,189,223,177,103,239,191,189,95,239,191,189,53,105,239,191,189,239,191,189,37,239,191,189,239,191,189,239,191,189,62,33,239,191,189,239,191,189,213,169,239,191,189,89,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,59,239,191,189,47,125,8,239,191,189,4,74,119,65,239,191,189,194,176,239,191,189,62,239,191,189,239,191,189,109,4,117,19,239,191,189,11,45,80,195,176,239,191,189,239,191,189,48,114,115,101,46,13,88,239,191,189,239,191,189,31,239,191,189,239,191,189,65,239,191,189,19,239,191,189,84,26,16,239,191,189,93,239,191,189,15,239,191,189,239,191,189,239,191,189,2,44,68,34,126,103,239,191,189,16,73,78,74,87,49,101,65,239,191,189,239,191,189,31,239,191,189,239,191,189,93,61,239,191,189,91,107,239,191,189,239,191,189,211,137,99,239,191,189,239,191,189,239,191,189,85,124,239,191,189,239,191,189,91,239,191,189,239,191,189,48,239,191,189,196,174,239,191,189,233,171,155,239,191,189,3,115,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,121,239,191,189,18,239,191,189,20,61,239,191,189,234,161,187,239,191,189,15,239,191,189,15,239,191,189,63,239,191,189,44,239,191,189,239,191,189,120,28,94,239,191,189,38,39,18,239,191,189,239,191,189,12,8,203,176,239,191,189,19,54,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,65,64,239,191,189,214,177,28,51,8,103,34,239,191,189,118,93,104,239,191,189,110,239,191,189,43,57,239,191,189,239,191,189,239,191,189,239,191,189,94,56,239,191,189,239,191,189,239,191,189,239,191,189,109,239,191,189,16,239,191,189,14,29,65,239,191,189,80,96,105,239,191,189,3,239,191,189,239,191,189,239,191,189,22,239,191,189,206,183,239,191,189,239,191,189,199,140,239,191,189,121,239,191,189,99,61,239,191,189,239,191,189,107,60,107,239,191,189,124,239,191,189,239,191,189,78,74,79,239,191,189,239,191,189,239,191,189,62,239,191,189,18,52,123,33,70,239,191,189,63,19,239,191,189,222,131,239,191,189,239,191,189,239,191,189,239,191,189,77,239,191,189,239,191,189,239,191,189,127,239,191,189,239,191,189,44,38,63,102,239,191,189,103,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,122,46,239,191,189,124,111,239,191,189,239,191,189,88,94,239,191,189,56,22,239,191,189,239,191,189,113,239,191,189,239,191,189,31,209,191,239,191,189,107,8,84,239,191,189,239,191,189,94,239,191,189,110,101,239,191,189,239,191,189,32,239,191,189,21,239,191,189,239,191,189,54,60,116,239,191,189,63,72,239,191,189,239,191,189,40,239,191,189,239,191,189,239,191,189,15,77,239,191,189,239,191,189,239,191,189,239,191,189,15,38,110,239,191,189,239,191,189,43,37,239,191,189,239,191,189,239,191,189,113,239,191,189,12,239,191,189,239,191,189,11,239,191,189,239,191,189,92,61,239,191,189,34,122,102,239,191,189,50,239,191,189,239,191,189,95,24,4,239,191,189,64,239,191,189,6,239,191,189,28,239,191,189,239,191,189,73,93,86,80,239,191,189,124,50,239,191,189,36,52,3,239,191,189,239,191,189,239,191,189,239,191,189,55,239,191,189,8,239,191,189,93,239,191,189,68,239,191,189,224,184,150,239,191,189,79,239,191,189,57,239,191,189,22,54,19,239,191,189,98,210,169,234,135,145,111,239,191,189,91,125,11,76,239,191,189,239,191,189,25,239,191,189,20,239,191,189,79,239,191,189,24,239,191,189,111,24,239,191,189,123,81,239,191,189,239,191,189,19,239,191,189,239,191,189,123,239,191,189,239,191,189,25,2,29,90,239,191,189,39,239,191,189,47,99,239,191,189,73,25,202,133,93,239,191,189,92,239,191,189,96,199,150,99,239,191,189,4,11,63,239,191,189,71,239,191,189,72,239,191,189,218,175,239,191,189,239,191,189,239,191,189,96,239,191,189,239,191,189,239,191,189,239,191,189,11,107,239,191,189,98,239,191,189,0,239,191,189,56,39,239,191,189,26,239,191,189,63,239,191,189,113,25,78,239,191,189,61,239,191,189,239,191,189,106,100,119,62,27,239,191,189,239,191,189,239,191,189,239,191,189,99,239,191,189,69,239,191,189,87,37,104,239,191,189,239,191,189,239,191,189,20,15,239,191,189,109,239,191,189,239,191,189,112,73,104,239,191,189,17,239,191,189,78,239,191,189,239,191,189,239,191,189,7,36,35,107,123,26,82,42,119,68,239,191,189,68,94,76,239,191,189,239,191,189,239,191,189,83,239,191,189,216,151,239,191,189,239,191,189,96,239,191,189,60,27,8,239,191,189,108,239,191,189,239,191,189,69,239,191,189,29,68,239,191,189,77,110,239,191,189,239,191,189,239,191,189,239,191,189,114,41,43,239,191,189,27,43,107,34,239,191,189,239,191,189,239,191,189,9,17,99,195,191,62,239,191,189,74,63,10,239,191,189,11,239,191,189,239,191,189,46,109,32,239,191,189,239,191,189,239,191,189,28,239,191,189,239,191,189,77,54,239,191,189,81,239,191,189,239,191,189,127,74,239,191,189,239,191,189,106,239,191,189,12,239,191,189,194,142,47,239,191,189,113,104,239,191,189,30,44,65,239,191,189,75,239,191,189,21,239,191,189,25,17,22,239,191,189,63,239,191,189,239,191,189,109,239,191,189,239,191,189,47,43,239,191,189,239,191,189,33,239,191,189,93,239,191,189,239,191,189,220,170,239,191,189,19,239,191,189,24,83,16,17,30,51,239,191,189,119,239,191,189,239,191,189,239,191,189,239,191,189,53,78,66,239,191,189,4,239,191,189,43,239,191,189,239,191,189,68,239,191,189,49,239,191,189,96,22,20,239,191,189,239,191,189,127,115,239,191,189,239,191,189,239,191,189,78,239,191,189,18,239,191,189,62,239,191,189,106,37,239,191,189,40,239,191,189,114,239,191,189,239,191,189,239,191,189,15,38,239,191,189,239,191,189,69,239,191,189,69,9,22,214,151,239,191,189,239,191,189,74,239,191,189,98,102,13,239,191,189,29,24,207,180,239,191,189,218,166,110,239,191,189,239,191,189,239,191,189,53,110,239,191,189,21,111,77,48,16,239,191,189,97,70,9,239,191,189,103,80,106,39,120,103,70,12,239,191,189,239,191,189,239,191,189,239,191,189,64,113,10,239,191,189,125,239,191,189,15,39,239,191,189,41,74,239,191,189,239,191,189,115,49,85,100,84,239,191,189,15,45,77,94,111,127,239,191,189,94,239,191,189,239,191,189,97,126,239,191,189,70,46,239,191,189,38,30,10,239,191,189,239,191,189,239,191,189,121,239,191,189,39,32,62,239,191,189,239,191,189,21,239,191,189,111,239,191,189,239,191,189,19,36,239,191,189,239,191,189,30,239,191,189,34,92,69,63,239,191,189,85,239,191,189,239,191,189,239,191,189,11,54,90,112,17,22,239,191,189,239,191,189,55,78,65,89,106,239,191,189,43,239,191,189,239,191,189,11,239,191,189,27,239,191,189,122,239,191,189,239,191,189,92,239,191,189,239,191,189,52,239,191,189,124,203,155,239,191,189,92,9,239,191,189,20,42,216,168,95,239,191,189,116,51,239,191,189,45,239,191,189,239,191,189,26,77,239,191,189,73,27,239,191,189,223,145,239,191,189,110,19,109,120,127,1,239,191,189,239,191,189,239,191,189,105,14,239,191,189,239,191,189,221,184,51,222,187,27,5,104,14,47,239,191,189,239,191,189,25,56,239,191,189,239,191,189,127,94,125,119,239,191,189,22,106,47,239,191,189,239,191,189,239,191,189,55,195,169,40,111,111,14,22,61,239,191,189,195,140,50,96,228,129,153,101,239,191,189,5,2,38,11,239,191,189,29,239,191,189,55,239,191,189,200,174,219,128,76,239,191,189,239,191,189,107,66,239,191,189,239,191,189,201,166,106,66,239,191,189,239,191,189,239,191,189,69,50,239,191,189,122,210,179,239,191,189,17,239,191,189,24,11,239,191,189,55,109,78,239,191,189,239,191,189,67,64,122,239,191,189,120,62,239,191,189,239,191,189,95,239,191,189,239,191,189,239,191,189,50,16,239,191,189,111,239,191,189,23,96,239,191,189,239,191,189,9,197,179,42,239,191,189,239,191,189,239,191,189,57,28,239,191,189,239,191,189,118,239,191,189,57,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,83,23,45,53,65,217,154,70,239,191,189,111,119,239,191,189,239,191,189,239,191,189,113,239,191,189,239,191,189,20,55,239,191,189,109,38,123,48,239,191,189,96,239,191,189,239,191,189,53,239,191,189,51,99,239,191,189,239,191,189,68,239,191,189,125,239,191,189,239,191,189,101,75,59,239,191,189,60,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,125,3,101,45,239,191,189,239,191,189,65,239,191,189,82,239,191,189,17,72,60,19,239,191,189,239,191,189,98,126,43,72,44,101,86,34,239,191,189,239,191,189,239,191,189,239,191,189,126,239,191,189,14,60,239,191,189,239,191,189,239,191,189,117,23,85,239,191,189,59,6,127,239,191,189,57,239,191,189,111,40,239,191,189,39,239,191,189,73,205,172,106,23,239,191,189,66,66,239,191,189,8,66,99,207,181,212,136,239,191,189,45,90,68,75,40,239,191,189,12,37,239,191,189,239,191,189,239,191,189,94,239,191,189,2,86,239,191,189,239,191,189,111,20,50,239,191,189,239,191,189,51,212,136,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,101,106,239,191,189,239,191,189,239,191,189,239,191,189,85,32,61,239,191,189,68,50,239,191,189,89,74,110,61,63,13,239,191,189,239,191,189,100,115,109,94,105,17,118,239,191,189,239,191,189,18,239,191,189,53,201,131,239,191,189,239,191,189,239,191,189,97,114,239,191,189,239,191,189,49,115,239,191,189,239,191,189,217,138,26,86,239,191,189,239,191,189,239,191,189,239,191,189,0,239,191,189,97,239,191,189,56,239,191,189,223,128,66,239,191,189,239,191,189,239,191,189,46,214,188,239,191,189,109,222,154,96,77,50,239,191,189,239,191,189,239,191,189,111,55,235,134,165,88,239,191,189,114,206,130,239,191,189,45,50,40,239,191,189,239,191,189,34,239,191,189,239,191,189,43,239,191,189,239,191,189,2,239,191,189,58,239,191,189,239,191,189,239,191,189,97,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,200,154,239,191,189,239,191,189,239,191,189,52,214,138,95,83,37,239,191,189,58,239,191,189,239,191,189,239,191,189,43,67,25,85,34,239,191,189,53,29,75,239,191,189,125,239,191,189,16,33,239,191,189,239,191,189,75,87,95,5,239,191,189,40,82,239,191,189,84,21,107,239,191,189,239,191,189,239,191,189,239,191,189,37,1,239,191,189,239,191,189,239,191,189,221,140,239,191,189,36,101,214,174,239,191,189,239,191,189,121,62,239,191,189,239,191,189,102,239,191,189,85,239,191,189,239,191,189,2,239,191,189,102,0,12,56,239,191,189,116,239,191,189,13,87,239,191,189,98,239,191,189,42,194,191,239,191,189,59,239,191,189,239,191,189,122,113,239,191,189,111,239,191,189,45,16,35,33,239,191,189,239,191,189,13,239,191,189,127,239,191,189,118,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,95,239,191,189,22,239,191,189,116,194,167,69,26,83,24,239,191,189,126,107,239,191,189,111,10,117,80,239,191,189,67,239,191,189,239,191,189,33,239,191,189,75,51,239,191,189,78,239,191,189,127,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,239,191,189,97,122,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,27,11,239,191,189,60,239,191,189,106,18,73,239,191,189,239,191,189,21,102,125,239,191,189,119,115,84,204,146,239,191,189,239,191,189,239,191,189,239,191,189,24,239,191,189,122,239,191,189,239,191,189,39,239,191,189,239,191,189,39,21,42,116,64,56,239,191,189,108,87,109,70,14,239,191,189,99,30,18,239,191,189,239,191,189,7,48,239,191,189,38,0,239,191,189,58,59,239,191,189,82,103,239,191,189,35,33,239,191,189,6,239,191,189,81,82,111,55,58,239,191,189,95,59,44,239,191,189,239,191,189,12,239,191,189,239,191,189,103,32,5,32,239,191,189,239,191,189,0,21,44,57,4,86,97,4,239,191,189,73,36,60,239,191,189,117,205,191,72,239,191,189,204,143,239,191,189,239,191,189,239,191,189,75,104,47,45,239,191,189,0,112,30,1,67,28,239,191,189,59,38,54,50,239,191,189,63,91,117,226,141,150,79,64,239,191,189,239,191,189,239,191,189,82,83,239,191,189,96,21,64,239,191,189,239,191,189,239,191,189,41,239,191,189,4,85,43,34,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,17,127,239,191,189,80,45,117,239,191,189,239,191,189,239,191,189,239,191,189,88,239,191,189,203,174,68,239,191,189,239,191,189,239,191,189,70,101,93,239,191,189,100,87,31,239,191,189,107,239,191,189,239,191,189,239,191,189,107,14,239,191,189,239,191,189,108,239,191,189,50,239,191,189,77,34,239,191,189,239,191,189,60,80,239,191,189,239,191,189,96,116,239,191,189,227,176,150,82,239,191,189,34,44,239,191,189,239,191,189,85,59,82,53,47,53,29,74,239,191,189,239,191,189,65,239,191,189,239,191,189,56,239,191,189,35,102,103,127,19,239,191,189,98,86,239,191,189,239,191,189,239,191,189,6,213,187,26,239,191,189,64,239,191,189,92,73,18,239,191,189,239,191,189,239,191,189,6,51,97,239,191,189,102,50,29,89,120,239,191,189,46,69,239,191,189,239,191,189,239,191,189,42,239,191,189,239,191,189,91,76,98,46,71,239,191,189,239,191,189,72,1,239,191,189,45,239,191,189,84,239,191,189,239,191,189,120,239,191,189,74,117,239,191,189,239,191,189,239,191,189,115,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,49,85,44,115,125,100,239,191,189,239,191,189,239,191,189,54,30,49,72,43,239,191,189,77,218,167,24,52,239,191,189,239,191,189,126,239,191,189,239,191,189,239,191,189,239,191,189,90,2,239,191,189,82,110,239,191,189,239,191,189,239,191,189,110,239,191,189,31,60,239,191,189,239,191,189,120,62,209,146,239,191,189,72,4,239,191,189,239,191,189,45,239,191,189,94,239,191,189,81,239,191,189,54,239,191,189,239,191,189,118,56,239,191,189,239,191,189,85,239,191,189,239,191,189,93,47,239,191,189,239,191,189,239,191,189,239,191,189,220,148,2,104,63,36,4,239,191,189,239,191,189,239,191,189,239,191,189,80,239,191,189,117,15,239,191,189,239,191,189,239,191,189,55,4,34,239,191,189,103,99,239,191,189,239,191,189,5,239,191,189,38,25,18,239,191,189,239,191,189,239,191,189,0,239,191,189,239,191,189,239,191,189,18,239,191,189,1,208,156,239,191,189,127,239,191,189,86,239,191,189,101,239,191,189,47,239,191,189,239,191,189,101,21,45,239,191,189,239,191,189,86,30,52,213,140,239,191,189,239,191,189,239,191,189,14,116,69,7,239,191,189,42,37,45,33,239,191,189,202,140,41,72,239,191,189,28,239,191,189,239,191,189,239,191,189,27,239,191,189,63,239,191,189,82,40,65,239,191,189,43,67,19,239,191,189,239,191,189,239,191,189,110,94,239,191,189,4,239,191,189,239,191,189,67,31,98,17,239,191,189,14,111,24,20,239,191,189,239,191,189,239,191,189,239,191,189,206,137,239,191,189,239,191,189,239,191,189,239,191,189,49,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,67,239,191,189,205,174,98,239,191,189,222,154,239,191,189,239,191,189,239,191,189,58,64,239,191,189,51,239,191,189,239,191,189,22,76,110,1,13,239,191,189,88,197,168,40,27,79,62,77,108,239,191,189,100,82,88,239,191,189,105,239,191,189,35,239,191,189,66,239,191,189,210,190,109,117,6,239,191,189,239,191,189,1,239,191,189,102,72,239,191,189,54,239,191,189,117,232,185,171,239,191,189,75,239,191,189,239,191,189,94,239,191,189,239,191,189,63,239,191,189,239,191,189,32,99,40,239,191,189,239,191,189,44,239,191,189,88,51,33,100,239,191,189,61,109,6,98,239,191,189,28,102,43,239,191,189,239,191,189,120,2,239,191,189,38,36,95,221,153,239,191,189,239,191,189,239,191,189,239,191,189,124,61,239,191,189,239,191,189,9,0,219,144,239,191,189,239,191,189,94,239,191,189,124,65,87,45,36,35,115,239,191,189,239,191,189,107,239,191,189,239,191,189,239,191,189,6,239,191,189,58,122,239,191,189,89,239,191,189,239,191,189,92,239,191,189,239,191,189,239,191,189,239,191,189,18,102,80,239,191,189,114,239,191,189,78,239,191,189,239,191,189,7,239,191,189,116,239,191,189,104,18,64,16,239,191,189,239,191,189,37,3,51,239,191,189,22,239,191,189,47,239,191,189,239,191,189,32,80,239,191,189,107,89,16,13,103,239,191,189,239,191,189,239,191,189,2,120,92,239,191,189,50,239,191,189,37,239,191,189,32,239,191,189,27,239,191,189,60,198,165,15,50,239,191,189,217,135,239,191,189,239,191,189,125,239,191,189,239,191,189,121,69,27,239,191,189,91,239,191,189,239,191,189,23,239,191,189,239,191,189,239,191,189,239,191,189,74,109,76,239,191,189,122,239,191,189,10,4,112,81,239,191,189,239,191,189,1,218,184,239,191,189,114,3,52,239,191,189,239,191,189,87,239,191,189,239,191,189,10,33,239,191,189,27,239,191,189,239,191,189,114,239,191,189,239,191,189,104,239,191,189,65,239,191,189,239,191,189,67,23,114,239,191,189,33,39,239,191,189,104,239,191,189,239,191,189,239,191,189,239,191,189,196,177,239,191,189,239,191,189,200,187,89,239,191,189,239,191,189,122,239,191,189,239,191,189,215,186,239,191,189,239,191,189,119,73,239,191,189,239,191,189,28,239,191,189,79,53,239,191,189,228,161,142,68,42,239,191,189,35,239,191,189,9,71,239,191,189,239,191,189,239,191,189,239,191,189,6,239,191,189,38,239,191,189,9,121,71,200,173,239,191,189,239,191,189,122,113,239,191,189,7,239,191,189,40,239,191,189,239,191,189,33,239,191,189,25,202,172,196,170,239,191,189,52,239,191,189,115,4,239,191,189,234,132,170,239,191,189,239,191,189,5,69,239,191,189,75,28,239,191,189,239,191,189,239,191,189,94,47,239,191,189,97,30,17,57,107,239,191,189,239,191,189,31,122,239,191,189,95,239,191,189,19,239,191,189,57,239,191,189,239,191,189,239,191,189,239,191,189,74,49,239,191,189,35,62,0,239,191,189,239,191,189,36,53,239,191,189,20,76,85,239,191,189,108,84,239,191,189,239,191,189,126,239,191,189,239,191,189,239,191,189,123,70,239,191,189,239,191,189,55,35,239,191,189,239,191,189,33,32,113,239,191,189,114,239,191,189,239,191,189,239,191,189,57,239,191,189,26,239,191,189,234,130,170,19,239,191,189,239,191,189,239,191,189,239,191,189,2,239,191,189,17,72,239,191,189,124,53,239,191,189,88,57,239,191,189,239,191,189,105,239,191,189,239,191,189,239,191,189,239,191,189,112,29,239,191,189,89,32,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,39,239,191,189,239,191,189,213,157,80,14,41,87,239,191,189,122,31,121,239,191,189,239,191,189,118,94,85,239,191,189,239,191,189,56,47,102,208,139,239,191,189,72,41,239,191,189,239,191,189,239,191,189,60,64,239,191,189,18,239,191,189,12,239,191,189,239,191,189,239,191,189,239,191,189,24,39,65,58,239,191,189,239,191,189,239,191,189,18,239,191,189,117,76,239,191,189,239,191,189,77,239,191,189,74,239,191,189,7,239,191,189,106,239,191,189,68,62,239,191,189,239,191,189,239,191,189,12,105,239,191,189,93,37,208,135,22,62,239,191,189,81,60,239,191,189,56,239,191,189,1,59,239,191,189,90,239,191,189,26,239,191,189,70,73,61,126,0,70,89,239,191,189,3,91,239,191,189,239,191,189,239,191,189,239,191,189,24,39,21,18,239,191,189,14,55,239,191,189,126,71,239,191,189,239,191,189,239,191,189,8,78,239,191,189,7,239,191,189,111,35,239,191,189,31,239,191,189,239,191,189,64,239,191,189,91,239,191,189,239,191,189,239,191,189,36,82,2,53,35,239,191,189,68,239,191,189,57,239,191,189,15,81,239,191,189,55,83,239,191,189,239,191,189,219,181,214,170,239,191,189,118,239,191,189,75,239,191,189,239,191,189,70,239,191,189,35,239,191,189,239,191,189,1,239,191,189,35,90,239,191,189,239,191,189,239,191,189,64,46,239,191,189,239,191,189,19,46,97,111,123,239,191,189,34,127,239,191,189,31,239,191,189,93,239,191,189,124,239,191,189,42,72,239,191,189,8,22,239,191,189,98,79,239,191,189,19,239,191,189,239,191,189,18,239,191,189,47,239,191,189,124,45,239,191,189,114,28,239,191,189,16,239,191,189,24,0,52,239,191,189,239,191,189,20,239,191,189,125,62,239,191,189,239,191,189,61,66,37,239,191,189,6,239,191,189,222,150,92,239,191,189,239,191,189,15,239,191,189,239,191,189,239,191,189,99,47,71,10,205,146,55,51,239,191,189,22,239,191,189,239,191,189,109,239,191,189,77,124,239,191,189,116,59,239,191,189,84,86,239,191,189,239,191,189,239,191,189,61,1,239,191,189,72,44,239,191,189,47,89,239,191,189,239,191,189,54,52,239,191,189,40,5,14,54,109,96,36,113,239,191,189,14,5,94,239,191,189,77,239,191,189,51,13,239,191,189,239,191,189,72,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,37,239,191,189,92,19,5,239,191,189,70,89,239,191,189,19,239,191,189,69,32,60,46,239,191,189,239,191,189,32,239,191,189,66,239,191,189,85,93,122,37,239,191,189,16,125,239,191,189,66,239,191,189,239,191,189,35,115,71,101,239,191,189,93,239,191,189,87,239,191,189,5,239,191,189,58,239,191,189,239,191,189,239,191,189,73,239,191,189,239,191,189,239,191,189,112,222,168,239,191,189,208,158,239,191,189,239,191,189,97,239,191,189,239,191,189,109,96,125,106,34,239,191,189,239,191,189,239,191,189,239,191,189,111,70,78,239,191,189,239,191,189,92,35,239,191,189,56,239,191,189,239,191,189,239,191,189,63,239,191,189,38,239,191,189,123,126,119,239,191,189,239,191,189,111,121,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,94,239,191,189,63,85,239,191,189,239,191,189,82,42,239,191,189,37,43,116,123,47,239,191,189,239,191,189,239,191,189,239,191,189,46,239,191,189,86,198,166,47,124,2,239,191,189,0,205,158,239,191,189,49,239,191,189,102,83,108,119,113,50,103,45,239,191,189,19,85,82,3,75,239,191,189,239,191,189,239,191,189,239,191,189,33,105,239,191,189,102,239,191,189,37,16,216,190,239,191,189,82,93,239,191,189,239,191,189,239,191,189,21,239,191,189,73,51,110,239,191,189,198,179,91,239,191,189,81,239,191,189,121,239,191,189,54,71,239,191,189,239,191,189,105,239,191,189,11,0,239,191,189,71,103,239,191,189,116,125,218,158,34,239,191,189,88,82,54,239,191,189,111,239,191,189,97,126,239,191,189,5,10,239,191,189,239,191,189,52,94,7,239,191,189,11,94,34,48,50,239,191,189,21,32,2,239,191,189,239,191,189,46,73,216,189,239,191,189,239,191,189,239,191,189,39,127,91,239,191,189,99,109,239,191,189,36,6,239,191,189,239,191,189,115,51,59,108,239,191,189,239,191,189,63,0,239,191,189,38,239,191,189,33,239,191,189,108,207,140,79,89,44,77,84,61,239,191,189,55,239,191,189,87,51,239,191,189,239,191,189,68,13,239,191,189,31,73,239,191,189,239,191,189,239,191,189,239,191,189,127,8,125,239,191,189,11,92,121,94,239,191,189,106,239,191,189,239,191,189,239,191,189,217,167,239,191,189,53,239,191,189,4,239,191,189,114,239,191,189,69,76,69,25,14,2,112,239,191,189,55,239,191,189,239,191,189,36,239,191,189,239,191,189,50,84,239,191,189,41,239,191,189,239,191,189,102,211,169,65,239,191,189,120,239,191,189,89,21,239,191,189,239,191,189,13,108,56,67,239,191,189,67,106,92,48,239,191,189,92,239,191,189,14,239,191,189,215,189,3,46,70,239,191,189,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,73,239,191,189,239,191,189,239,191,189,33,94,239,191,189,204,184,239,191,189,239,191,189,109,17,83,205,133,59,9,239,191,189,79,16,239,191,189,10,86,239,191,189,78,35,81,239,191,189,89,239,191,189,40,107,33,210,135,9,58,239,191,189,95,37,239,191,189,62,59,239,191,189,29,239,191,189,239,191,189,54,239,191,189,213,146,2,239,191,189,57,239,191,189,45,58,15,239,191,189,122,31,63,239,191,189,68,239,191,189,50,239,191,189,239,191,189,49,239,191,189,86,58,42,19,98,239,191,189,239,191,189,239,191,189,91,53,27,239,191,189,239,191,189,55,38,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,127,211,171,239,191,189,239,191,189,239,191,189,81,119,239,191,189,239,191,189,56,103,6,59,239,191,189,93,37,239,191,189,239,191,189,108,113,239,191,189,86,94,32,239,191,189,127,29,239,191,189,74,18,20,85,239,191,189,239,191,189,103,126,55,98,75,110,81,239,191,189,68,239,191,189,124,239,191,189,95,239,191,189,239,191,189,98,25,111,239,191,189,239,191,189,124,77,239,191,189,68,4,52,239,191,189,119,239,191,189,36,17,56,100,95,239,191,189,239,191,189,36,239,191,189,239,191,189,31,26,18,123,239,191,189,62,239,191,189,239,191,189,59,239,191,189,239,191,189,239,191,189,239,191,189,64,12,239,191,189,49,122,30,71,58,239,191,189,34,100,239,191,189,239,191,189,68,239,191,189,239,191,189,239,191,189,239,191,189,62,239,191,189,114,110,239,191,189,106,239,191,189,52,5,239,191,189,117,122,239,191,189,47,41,44,239,191,189,88,117,239,191,189,115,5,60,194,132,239,191,189,239,191,189,239,191,189,1,239,191,189,236,191,147,239,191,189,113,100,115,239,191,189,92,127,95,70,24,239,191,189,239,191,189,32,51,53,239,191,189,90,76,63,239,191,189,239,191,189,96,56,89,239,191,189,234,184,189,20,50,12,239,191,189,239,191,189,239,191,189,59,239,191,189,196,184,38,239,191,189,239,191,189,77,44,239,191,189,118,239,191,189,99,239,191,189,119,39,239,191,189,239,191,189,239,191,189,53,239,191,189,82,57,11,239,191,189,239,191,189,239,191,189,75,20,12,49,14,58,239,191,189,119,208,162,37,67,239,191,189,239,191,189,52,74,227,177,134,239,191,189,70,239,191,189,94,239,191,189,77,232,132,185,239,191,189,63,87,51,2,24,239,191,189,68,239,191,189,41,239,191,189,239,191,189,87,5,239,191,189,105,239,191,189,239,191,189,30,239,191,189,40,19,96,239,191,189,123,93,239,191,189,239,191,189,74,239,191,189,239,191,189,14,239,191,189,23,239,191,189,239,191,189,239,191,189,96,239,191,189,28,105,239,191,189,239,191,189,92,38,70,239,191,189,239,191,189,239,191,189,125,239,191,189,96,202,150,239,191,189,239,191,189,222,166,239,191,189,239,191,189,239,191,189,51,239,191,189,96,60,239,191,189,12,64,86,239,191,189,126,65,65,2,239,191,189,239,191,189,81,3,239,191,189,53,239,191,189,2,239,191,189,204,175,239,191,189,68,92,239,191,189,239,191,189,6,68,239,191,189,6,239,191,189,53,239,191,189,97,32,104,57,85,47,52,239,191,189,239,191,189,30,239,191,189,17,7,239,191,189,239,191,189,28,239,191,189,220,140,92,45,239,191,189,239,191,189,121,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,59,117,79,239,191,189,239,191,189,239,191,189,34,239,191,189,114,210,162,239,191,189,18,110,124,75,126,62,43,40,37,42,0,239,191,189,120,239,191,189,112,238,137,155,239,191,189,239,191,189,239,191,189,3,239,191,189,82,239,191,189,35,239,191,189,239,191,189,239,191,189,239,191,189,105,239,191,189,239,191,189,96,239,191,189,65,239,191,189,100,59,74,111,16,116,17,117,118,107,62,114,51,114,239,191,189,43,9,6,14,239,191,189,42,239,191,189,90,239,191,189,52,46,239,191,189,239,191,189,70,30,23,18,47,239,191,189,36,95,92,41,239,191,189,239,191,189,239,191,189,239,191,189,75,239,191,189,97,239,191,189,239,191,189,19,239,191,189,239,191,189,239,191,189,89,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,59,239,191,189,239,191,189,81,47,88,84,43,67,65,78,119,239,191,189,239,191,189,81,126,239,191,189,76,61,239,191,189,60,239,191,189,104,239,191,189,45,239,191,189,109,239,191,189,239,191,189,121,32,73,126,239,191,189,239,191,189,211,186,239,191,189,239,191,189,239,191,189,99,54,65,239,191,189,239,191,189,27,239,191,189,239,191,189,8,17,239,191,189,239,191,189,239,191,189,61,110,239,191,189,121,74,35,118,234,149,169,239,191,189,33,5,239,191,189,30,239,191,189,125,239,191,189,57,239,191,189,73,63,6,110,239,191,189,239,191,189,18,239,191,189,239,191,189,239,191,189,112,124,239,191,189,239,191,189,64,66,98,90,112,93,55,8,205,140,118,99,239,191,189,35,239,191,189,223,138,77,239,191,189,239,191,189,83,239,191,189,103,29,239,191,189,239,191,189,17,125,78,239,191,189,56,77,239,191,189,89,239,191,189,220,142,35,83,239,191,189,103,64,113,121,239,191,189,239,191,189,6,239,191,189,89,239,191,189,43,35,239,191,189,239,191,189,87,66,239,191,189,69,239,191,189,239,191,189,75,239,191,189,239,191,189,239,191,189,84,41,239,191,189,101,107,239,191,189,81,102,239,191,189,239,191,189,127,19,239,191,189,239,191,189,37,21,125,34,35,239,191,189,239,191,189,21,239,191,189,239,191,189,2,117,2,72,95,103,239,191,189,239,191,189,239,191,189,239,191,189,37,206,162,239,191,189,239,191,189,239,191,189,106,239,191,189,41,239,191,189,52,68,239,191,189,239,191,189,31,239,191,189,111,41,239,191,189,39,57,63,239,191,189,10,99,239,191,189,239,191,189,8,7,239,191,189,86,209,140,9,239,191,189,87,114,221,159,239,191,189,39,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,22,40,239,191,189,239,191,189,103,23,95,73,239,191,189,56,239,191,189,61,239,191,189,239,191,189,97,239,191,189,239,191,189,124,98,239,191,189,239,191,189,34,239,191,189,59,239,191,189,239,191,189,8,239,191,189,74,84,239,191,189,109,239,191,189,54,239,191,189,239,191,189,86,239,191,189,239,191,189,45,239,191,189,239,191,189,31,218,159,18,239,191,189,239,191,189,49,84,68,58,6,19,239,191,189,96,116,102,239,191,189,14,95,239,191,189,239,191,189,99,42,239,191,189,85,42,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,97,239,191,189,119,80,57,25,239,191,189,239,191,189,50,239,191,189,35,239,191,189,127,239,191,189,52,18,239,191,189,239,191,189,239,191,189,82,239,191,189,239,191,189,8,239,191,189,239,191,189,68,239,191,189,88,239,191,189,239,191,189,123,39,239,191,189,239,191,189,19,116,101,239,191,189,37,239,191,189,239,191,189,239,191,189,239,191,189,50,115,2,239,191,189,239,191,189,122,239,191,189,239,191,189,43,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,78,239,191,189,216,159,35,239,191,189,2,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,15,239,191,189,25,66,69,239,191,189,61,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,239,191,189,239,191,189,48,239,191,189,239,191,189,239,191,189,89,239,191,189,55,113,57,239,191,189,7,239,191,189,14,20,81,44,5,239,191,189,239,191,189,48,239,191,189,239,191,189,9,21,239,191,189,8,100,0,58,239,191,189,108,53,0,239,191,189,119,67,239,191,189,239,191,189,94,58,83,239,191,189,8,239,191,189,239,191,189,112,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,104,239,191,189,123,82,125,239,191,189,239,191,189,96,80,112,55,55,58,73,239,191,189,239,191,189,29,239,191,189,14,87,23,239,191,189,239,191,189,239,191,189,1,239,191,189,121,239,191,189,42,239,191,189,239,191,189,85,239,191,189,59,4,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,13,239,191,189,27,111,239,191,189,69,239,191,189,239,191,189,106,12,239,191,189,68,239,191,189,239,191,189,16,239,191,189,80,239,191,189,19,72,53,207,181,239,191,189,239,191,189,69,75,71,125,239,191,189,88,87,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,51,213,134,22,239,191,189,239,191,189,89,239,191,189,55,117,239,191,189,78,38,239,191,189,239,191,189,87,62,20,58,239,191,189,239,191,189,0,107,92,239,191,189,104,67,239,191,189,34,62,58,220,191,239,191,189,239,191,189,114,239,191,189,239,191,189,7,39,64,110,13,239,191,189,96,47,125,239,191,189,239,191,189,50,79,239,191,189,239,191,189,239,191,189,11,51,106,42,41,69,118,108,109,239,191,189,58,10,239,191,189,47,239,191,189,68,239,191,189,239,191,189,12,19,239,191,189,97,239,191,189,239,191,189,239,191,189,239,191,189,76,239,191,189,239,191,189,121,86,3,239,191,189,7,239,191,189,239,191,189,194,177,239,191,189,1,20,239,191,189,85,239,191,189,78,239,191,189,91,239,191,189,203,180,115,36,239,191,189,64,239,191,189,46,107,90,239,191,189,31,125,10,239,191,189,239,191,189,239,191,189,67,21,61,35,239,191,189,73,98,239,191,189,96,239,191,189,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,101,35,239,191,189,239,191,189,239,191,189,64,108,49,86,36,104,200,179,239,191,189,10,218,161,20,10,239,191,189,30,102,239,191,189,107,16,97,74,97,220,135,78,239,191,189,79,46,24,239,191,189,239,191,189,208,172,3,239,191,189,11,239,191,189,239,191,189,239,191,189,14,239,191,189,239,191,189,31,4,8,239,191,189,239,191,189,239,191,189,239,191,189,75,89,239,191,189,125,239,191,189,10,85,239,191,189,214,169,120,239,191,189,106,35,239,191,189,239,191,189,104,7,53,18,239,191,189,8,239,191,189,118,82,109,239,191,189,239,191,189,239,191,189,69,45,239,191,189,91,26,239,191,189,239,191,189,239,191,189,46,13,239,191,189,239,191,189,239,191,189,239,191,189,55,33,239,191,189,113,239,191,189,66,51,239,191,189,239,191,189,239,191,189,239,191,189,100,66,239,191,189,91,42,239,191,189,124,239,191,189,75,239,191,189,124,239,191,189,41,80,239,191,189,58,239,191,189,57,239,191,189,239,191,189,92,239,191,189,16,81,85,239,191,189,239,191,189,239,191,189,122,80,239,191,189,239,191,189,16,239,191,189,239,191,189,88,210,162,4,239,191,189,33,29,239,191,189,103,239,191,189,62,95,32,39,7,95,101,239,191,189,239,191,189,100,239,191,189,50,126,6,96,239,191,189,239,191,189,29,239,191,189,239,191,189,239,191,189,210,143,239,191,189,48,103,48,53,117,117,62,234,168,150,23,105,219,183,115,239,191,189,64,19,35,54,239,191,189,37,84,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,125,239,191,189,107,208,134,239,191,189,239,191,189,46,48,26,119,37,222,138,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,11,239,191,189,198,175,88,239,191,189,10,19,239,191,189,239,191,189,124,239,191,189,62,51,43,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,239,191,189,15,239,191,189,239,191,189,17,15,239,191,189,108,239,191,189,239,191,189,71,239,191,189,85,239,191,189,239,191,189,27,239,191,189,120,239,191,189,236,140,154,239,191,189,239,191,189,239,191,189,239,191,189,95,52,66,94,91,38,239,191,189,73,239,191,189,239,191,189,4,70,239,191,189,110,239,191,189,239,191,189,239,191,189,53,85,239,191,189,87,239,191,189,239,191,189,32,123,239,191,189,70,39,111,91,37,42,101,59,55,107,78,239,191,189,117,126,97,56,78,239,191,189,49,60,126,229,179,187,104,48,239,191,189,33,7,239,191,189,82,61,239,191,189,83,239,191,189,34,42,113,239,191,189,27,55,50,111,123,239,191,189,73,239,191,189,106,39,31,73,57,239,191,189,63,85,96,115,239,191,189,239,191,189,239,191,189,45,67,52,239,191,189,24,17,12,33,239,191,189,62,13,239,191,189,239,191,189,21,4,75,118,55,37,31,80,239,191,189,239,191,189,239,191,189,82,24,78,239,191,189,239,191,189,48,239,191,189,118,125,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,98,239,191,189,60,239,191,189,125,239,191,189,18,108,98,239,191,189,59,10,239,191,189,59,239,191,189,212,164,239,191,189,73,76,73,0,239,191,189,107,35,239,191,189,239,191,189,239,191,189,96,239,191,189,39,16,76,239,191,189,212,161,239,191,189,20,16,239,191,189,239,191,189,117,100,239,191,189,71,115,239,191,189,70,82,239,191,189,239,191,189,239,191,189,98,239,191,189,208,154,239,191,189,90,123,11,117,239,191,189,43,239,191,189,69,103,239,191,189,239,191,189,16,239,191,189,57,119,99,74,77,7,46,117,28,239,191,189,239,191,189,239,191,189,239,191,189,101,239,191,189,26,114,239,191,189,17,239,191,189,84,239,191,189,90,239,191,189,65,239,191,189,57,55,1,12,239,191,189,239,191,189,53,239,191,189,113,58,37,23,114,239,191,189,108,75,62,239,191,189,84,239,191,189,239,191,189,239,191,189,34,43,239,191,189,12,239,191,189,24,50,239,191,189,29,239,191,189,9,239,191,189,239,191,189,239,191,189,115,16,239,191,189,1,113,9,239,191,189,97,239,191,189,90,109,71,239,191,189,8,120,239,191,189,239,191,189,114,239,191,189,115,21,239,191,189,23,239,191,189,239,191,189,28,239,191,189,239,191,189,28,239,191,189,14,239,191,189,239,191,189,117,239,191,189,46,22,82,93,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,239,191,189,239,191,189,41,10,239,191,189,2,239,191,189,239,191,189,90,239,191,189,239,191,189,239,191,189,45,84,112,6,68,88,76,239,191,189,75,23,49,74,119,52,21,22,239,191,189,84,239,191,189,126,79,58,239,191,189,111,227,142,153,119,71,239,191,189,239,191,189,57,53,80,37,8,98,239,191,189,124,239,191,189,76,25,78,116,239,191,189,239,191,189,22,206,128,239,191,189,239,191,189,239,191,189,239,191,189,121,118,239,191,189,239,191,189,0,34,239,191,189,239,191,189,239,191,189,60,239,191,189,239,191,189,239,191,189,20,39,15,13,239,191,189,239,191,189,239,191,189,239,191,189,49,54,239,191,189,27,119,35,119,239,191,189,239,191,189,239,191,189,239,191,189,5,60,239,191,189,239,191,189,50,69,98,239,191,189,239,191,189,31,120,220,164,239,191,189,0,239,191,189,239,191,189,115,239,191,189,222,182,60,71,64,6,239,191,189,239,191,189,239,191,189,62,239,191,189,221,128,239,191,189,126,239,191,189,88,78,239,191,189,239,191,189,81,48,16,239,191,189,239,191,189,89,71,42,118,119,239,191,189,11,239,191,189,239,191,189,12,78,239,191,189,116,239,191,189,43,239,191,189,217,169,239,191,189,44,239,191,189,92,239,191,189,114,69,83,239,191,189,226,171,133,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,124,17,239,191,189,239,191,189,239,191,189,90,239,191,189,239,191,189,47,239,191,189,228,181,177,42,120,239,191,189,239,191,189,117,31,239,191,189,97,239,191,189,49,36,239,191,189,40,239,191,189,95,94,239,191,189,101,239,191,189,107,32,239,191,189,34,239,191,189,68,63,239,191,189,50,66,239,191,189,111,239,191,189,49,239,191,189,13,38,29,37,110,239,191,189,93,239,191,189,239,191,189,98,204,191,239,191,189,60,84,239,191,189,86,239,191,189,3,69,10,239,191,189,100,239,191,189,49,239,191,189,60,47,117,239,191,189,239,191,189,239,191,189,239,191,189,86,82,55,239,191,189,63,118,239,191,189,14,91,239,191,189,239,191,189,5,239,191,189,239,191,189,239,191,189,222,188,50,112,239,191,189,239,191,189,118,92,239,191,189,103,239,191,189,46,79,55,239,191,189,239,191,189,239,191,189,44,239,191,189,29,239,191,189,22,239,191,189,59,55,239,191,189,200,164,239,191,189,239,191,189,34,239,191,189,80,239,191,189,117,68,23,11,239,191,189,239,191,189,116,35,75,239,191,189,26,239,191,189,11,239,191,189,19,54,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,28,233,171,180,200,148,30,239,191,189,70,108,239,191,189,221,150,239,191,189,104,239,191,189,239,191,189,77,239,191,189,239,191,189,203,159,32,87,239,191,189,24,239,191,189,121,239,191,189,28,239,191,189,239,191,189,89,90,108,87,23,97,86,107,4,122,36,2,117,239,191,189,127,239,191,189,66,239,191,189,23,239,191,189,80,73,239,191,189,92,37,123,239,191,189,62,85,239,191,189,239,191,189,77,239,191,189,105,14,75,101,53,239,191,189,82,109,239,191,189,37,239,191,189,85,45,42,239,191,189,239,191,189,239,191,189,79,118,120,16,8,17,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,44,239,191,189,239,191,189,75,239,191,189,215,133,239,191,189,52,239,191,189,13,19,239,191,189,122,239,191,189,36,239,191,189,7,239,191,189,81,239,191,189,69,98,239,191,189,99,213,140,96,239,191,189,105,105,67,239,191,189,239,191,189,64,23,239,191,189,239,191,189,239,191,189,85,239,191,189,74,239,191,189,88,66,99,239,191,189,239,191,189,126,239,191,189,83,239,191,189,239,191,189,239,191,189,34,239,191,189,76,22,239,191,189,239,191,189,74,36,239,191,189,239,191,189,48,239,191,189,101,60,58,114,239,191,189,239,191,189,102,239,191,189,239,191,189,92,127,9,71,239,191,189,34,239,191,189,239,191,189,16,21,117,73,25,102,89,239,191,189,110,239,191,189,239,191,189,10,239,191,189,239,191,189,239,191,189,40,120,239,191,189,118,91,11,76,118,239,191,189,87,239,191,189,239,191,189,103,66,239,191,189,239,191,189,84,66,239,191,189,239,191,189,239,191,189,239,191,189,76,239,191,189,239,191,189,50,20,239,191,189,239,191,189,43,239,191,189,239,191,189,239,191,189,239,191,189,2,239,191,189,239,191,189,239,191,189,196,158,239,191,189,239,191,189,48,239,191,189,239,191,189,239,191,189,2,239,191,189,62,27,69,110,239,191,189,239,191,189,239,191,189,123,100,26,98,230,191,189,20,239,191,189,97,239,191,189,239,191,189,17,239,191,189,108,239,191,189,22,210,142,27,52,239,191,189,30,239,191,189,51,239,191,189,239,191,189,239,191,189,62,114,239,191,189,81,10,31,113,239,191,189,59,1,49,115,239,191,189,14,38,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,81,47,239,191,189,105,239,191,189,108,239,191,189,69,239,191,189,46,66,239,191,189,239,191,189,126,239,191,189,239,191,189,41,239,191,189,7,239,191,189,239,191,189,32,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,57,239,191,189,239,191,189,26,68,15,239,191,189,108,239,191,189,239,191,189,239,191,189,43,34,12,239,191,189,83,239,191,189,13,107,55,118,101,239,191,189,99,239,191,189,48,84,239,191,189,12,239,191,189,197,172,77,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,58,239,191,189,24,239,191,189,239,191,189,105,6,239,191,189,239,191,189,239,191,189,18,9,5,239,191,189,116,239,191,189,124,239,191,189,201,128,66,20,239,191,189,12,96,239,191,189,239,191,189,239,191,189,222,141,23,46,90,239,191,189,239,191,189,239,191,189,31,239,191,189,239,191,189,239,191,189,93,8,49,239,191,189,239,191,189,2,239,191,189,43,55,239,191,189,23,32,239,191,189,120,115,37,239,191,189,12,92,10,239,191,189,31,239,191,189,112,239,191,189,239,191,189,24,197,158,239,191,189,239,191,189,72,72,35,58,239,191,189,51,84,93,231,172,175,81,117,239,191,189,103,239,191,189,121,239,191,189,239,191,189,19,92,239,191,189,239,191,189,61,23,239,191,189,239,191,189,239,191,189,83,239,191,189,101,239,191,189,239,191,189,84,239,191,189,126,84,57,67,239,191,189,239,191,189,239,191,189,35,239,191,189,112,239,191,189,239,191,189,239,191,189,124,205,159,23,239,191,189,239,191,189,102,239,191,189,87,239,191,189,34,33,98,239,191,189,9,23,70,21,101,33,31,239,191,189,63,106,87,90,93,94,12,239,191,189,120,239,191,189,18,86,239,191,189,48,78,239,191,189,92,239,191,189,16,38,110})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff55b9d060",
                        container: "containersd72919278bfa4917b48fc37304e3213e",
                        blob: "Blob250bbfe19cf3432b9f34958be57fa504_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=98304-109055",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06680 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06680_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06680_s.txt", Encoding.UTF8);

    public Test06680() : base(recordedRequest, recordedResponse, "accounts8d439ff51ff80c0")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{86,239,191,189,198,138,239,191,189,239,191,189,239,191,189,73,12,106,37,239,191,189,239,191,189,66,48,239,191,189,18,9,239,191,189,83,239,191,189,239,191,189,239,191,189,66,239,191,189,78,239,191,189,239,191,189,75,239,191,189,239,191,189,25,90,36,239,191,189,108,31,73,239,191,189,75,239,191,189,5,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,103,86,119,27,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,53,117,239,191,189,239,191,189,239,191,189,239,191,189,12,72,110,239,191,189,196,139,239,191,189,71,122,239,191,189,239,191,189,2,239,191,189,239,191,189,239,191,189,239,191,189,118,239,191,189,11,239,191,189,72,120,60,239,191,189,127,239,191,189,114,239,191,189,213,187,8,9,100,80,239,191,189,26,208,163,202,174,239,191,189,85,48,90,239,191,189,28,239,191,189,34,112,118,111,8,125,239,191,189,239,191,189,239,191,189,49,239,191,189,68,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,107,239,191,189,239,191,189,239,191,189,46,239,191,189,42,92,239,191,189,239,191,189,72,239,191,189,13,99,239,191,189,79,27,95,76,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,94,239,191,189,88,26,239,191,189,58,239,191,189,199,176,9,37,239,191,189,72,239,191,189,239,191,189,32,239,191,189,209,135,80,239,191,189,239,191,189,239,191,189,7,239,191,189,69,239,191,189,239,191,189,109,239,191,189,8,22,239,191,189,67,115,80,4,239,191,189,65,13,12,70,239,191,189,239,191,189,42,85,22,239,191,189,33,106,239,191,189,239,191,189,96,239,191,189,19,125,239,191,189,81,123,107,239,191,189,79,90,239,191,189,0,15,5,4,41,239,191,189,28,33,239,191,189,121,67,239,191,189,46,1,239,191,189,73,46,239,191,189,99,2,61,78,239,191,189,40,47,239,191,189,106,239,191,189,82,239,191,189,125,239,191,189,239,191,189,239,191,189,239,191,189,27,79,18,239,191,189,239,191,189,78,126,43,239,191,189,85,239,191,189,78,239,191,189,116,49,60,239,191,189,239,191,189,87,239,191,189,239,191,189,89,239,191,189,239,191,189,50,35,104,206,184,239,191,189,239,191,189,239,191,189,78,15,239,191,189,239,191,189,28,116,207,179,239,191,189,34,239,191,189,210,173,239,191,189,239,191,189,63,32,239,191,189,239,191,189,209,148,74,63,239,191,189,114,61,83,112,239,191,189,114,239,191,189,239,191,189,239,191,189,0,212,178,56,31,33,28,239,191,189,214,143,239,191,189,10,39,239,191,189,239,191,189,41,239,191,189,30,20,239,191,189,15,3,239,191,189,239,191,189,239,191,189,239,191,189,32,94,239,191,189,14,239,191,189,239,191,189,3,207,167,239,191,189,239,191,189,239,191,189,123,197,181,239,191,189,116,239,191,189,55,104,21,239,191,189,211,189,1,84,239,191,189,25,239,191,189,239,191,189,3,239,191,189,239,191,189,63,1,239,191,189,239,191,189,239,191,189,223,166,6,88,239,191,189,239,191,189,197,163,79,239,191,189,31,239,191,189,32,239,191,189,31,239,191,189,88,239,191,189,15,12,91,13,239,191,189,0,239,191,189,239,191,189,239,191,189,55,59,239,191,189,239,191,189,24,239,191,189,208,144,97,239,191,189,239,191,189,239,191,189,32,60,239,191,189,239,191,189,26,239,191,189,109,239,191,189,239,191,189,117,239,191,189,49,199,186,239,191,189,239,191,189,29,87,57,61,194,142,103,239,191,189,7,7,239,191,189,80,55,239,191,189,12,116,239,191,189,239,191,189,208,170,239,191,189,239,191,189,81,61,239,191,189,239,191,189,239,191,189,27,239,191,189,80,239,191,189,77,239,191,189,67,102,239,191,189,239,191,189,93,239,191,189,73,239,191,189,18,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,105,51,239,191,189,239,191,189,239,191,189,239,191,189,18,77,5,239,191,189,115,239,191,189,239,191,189,112,65,239,191,189,239,191,189,3,64})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff51ff80c0",
                        container: "containers36f17c06683e407f99e1918f1ada7e05",
                        blob: "Blob05d8cf78b9234c70bd43a70dab381bf2_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test06137 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06137_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\06137_s.txt", Encoding.UTF8);

    public Test06137() : base(recordedRequest, recordedResponse, "accounts8d439ff31833bbb")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{0,239,191,189,239,191,189,58,239,191,189,23,22,239,191,189,38,200,170,60,239,191,189,239,191,189,239,191,189,239,191,189,15,239,191,189,239,191,189,97,239,191,189,30,239,191,189,79,71,3,239,191,189,211,150,239,191,189,239,191,189,222,154,239,191,189,24,239,191,189,123,9,239,191,189,103,78,239,191,189,32,31,74,239,191,189,51,42,239,191,189,12,73,239,191,189,18,82,31,239,191,189,84,124,239,191,189,44,66,62,239,191,189,239,191,189,204,162,239,191,189,239,191,189,17,6,239,191,189,63,18,3,239,191,189,108,4,239,191,189,239,191,189,239,191,189,26,239,191,189,78,79,239,191,189,71,239,191,189,53,239,191,189,239,191,189,23,71,58,12,239,191,189,239,191,189,61,126,239,191,189,79,239,191,189,239,191,189,239,191,189,67,239,191,189,239,191,189,63,28,239,191,189,239,191,189,119,73,239,191,189,108,39,239,191,189,65,239,191,189,0,90,84,80,87,17,239,191,189,84,5,6,69,107,46,239,191,189,239,191,189,239,191,189,27,60,239,191,189,10,84,239,191,189,8,114,80,239,191,189,239,191,189,239,191,189,97,239,191,189,239,191,189,9,80,239,191,189,125,239,191,189,239,191,189,84,239,191,189,239,191,189,84,239,191,189,239,191,189,57,239,191,189,121,239,191,189,239,191,189,101,80,239,191,189,36,54,62,8,82,239,191,189,0,239,191,189,239,191,189,32,239,191,189,54,34,59,27,239,191,189,7,11,239,191,189,199,181,239,191,189,239,191,189,239,191,189,42,207,155,239,191,189,239,191,189,50,239,191,189,126,239,191,189,239,191,189,25,108,117,79,24,83,239,191,189,95,51,239,191,189,239,191,189,22,239,191,189,93,53,239,191,189,222,137,53,127,127,239,191,189,221,130,70,42,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,41,86,1,22,239,191,189,239,191,189,109,116,239,191,189,70,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,120,239,191,189,239,191,189,239,191,189,29,239,191,189,239,191,189,101,239,191,189,221,152,239,191,189,239,191,189,41,239,191,189,106,68,239,191,189,239,191,189,239,191,189,68,92,30,87,239,191,189,113,20,74,56,239,191,189,239,191,189,74,239,191,189,71,239,191,189,44,73,77,239,191,189,239,191,189,101,239,191,189,104,57,239,191,189,239,191,189,75,239,191,189,239,191,189,62,62,239,191,189,202,187,28,239,191,189,83,203,172,239,191,189,121,45,239,191,189,72,77,2,239,191,189,119,239,191,189,33,239,191,189,239,191,189,27,239,191,189,83,239,191,189,239,191,189,93,239,191,189,239,191,189,239,191,189,81,92,239,191,189,85,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,45,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,17,239,191,189,51,239,191,189,71,92,239,191,189,66,103,40,239,191,189,239,191,189,239,191,189,239,191,189,22,39,239,191,189,239,191,189,239,191,189,3,239,191,189,239,191,189,39,44,116,239,191,189,56,239,191,189,239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,29,239,191,189,118,239,191,189,239,191,189,239,191,189,36,108,239,191,189,239,191,189,239,191,189,86,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,20,239,191,189,12,239,191,189,210,167,95,239,191,189,239,191,189,239,191,189,239,191,189,68,239,191,189,20,31,10,48,104,239,191,189,239,191,189,71,239,191,189,118,52,44,239,191,189,95,107,215,157,60,239,191,189,21,239,191,189,5,17,18,239,191,189,82,239,191,189,21,76,108,59,239,191,189,239,191,189,65,239,191,189,239,191,189,194,132,5,63,239,191,189,58,122,239,191,189,97,239,191,189,71,239,191,189,239,191,189,58,239,191,189,195,137,239,191,189,101,26,239,191,189,29,195,166,22,49,239,191,189,9,239,191,189,114,30,29,239,191,189,29,219,184,239,191,189,123,117,116,239,191,189,57,239,191,189,239,191,189,10,239,191,189,70,18,239,191,189,120,48})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d439ff31833bbb",
                        container: "containers31ce27ca3cb04656b52ed5678c35617f",
                        blob: "Blob6ff568dc508d46699ad1e4ee6c23942b_LinkBlob",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test17659 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17659_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17659_s.txt", Encoding.UTF8);

    public Test17659() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers1dbc83070dfc4b13843543783d3dbb72",
                        blob: "PageBlob4d8e8b80c94846eca17af9f8d0007e39",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        leaseId: "6c14ea7d-6088-46c2-8096-3899f21a1170",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test17635 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17635_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17635_s.txt", Encoding.UTF8);

    public Test17635() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers7e7079fcccea4fc28c1bb269d01b3779",
                        blob: "PageBlob882826c1744b467ea0adf3355ddab2ec",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test18372 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\18372_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\18372_s.txt", Encoding.UTF8);

    public Test18372() : base(recordedRequest, recordedResponse, "accounts8d43a0243c1fb9e")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,40,239,191,189,239,191,189,239,191,189,239,191,189,115,239,191,189,117,239,191,189,239,191,189,239,191,189,4,48,239,191,189,75,239,191,189,55,239,191,189,82,124,98,39,61,239,191,189,239,191,189,239,191,189,239,191,189,8,239,191,189,91,239,191,189,239,191,189,239,191,189,40,51,110,239,191,189,1,239,191,189,239,191,189,239,191,189,94,239,191,189,239,191,189,31,239,191,189,239,191,189,85,239,191,189,28,239,191,189,239,191,189,52,239,191,189,239,191,189,105,35,70,236,165,188,239,191,189,67,239,191,189,239,191,189,16,120,239,191,189,24,114,239,191,189,239,191,189,239,191,189,124,200,140,239,191,189,122,29,239,191,189,85,63,29,52,239,191,189,239,191,189,104,239,191,189,75,89,21,6,239,191,189,88,26,239,191,189,239,191,189,15,69,93,61,30,239,191,189,239,191,189,239,191,189,76,73,239,191,189,239,191,189,37,239,191,189,206,191,10,56,4,207,150,80,239,191,189,34,78,39,60,222,161,17,35,239,191,189,239,191,189,40,107,216,136,116,55,239,191,189,115,57,115,239,191,189,113,239,191,189,37,239,191,189,70,70,239,191,189,31,22,239,191,189,62,239,191,189,239,191,189,58,239,191,189,239,191,189,72,239,191,189,89,58,37,73,21,239,191,189,97,239,191,189,54,239,191,189,1,74,92,92,239,191,189,221,177,97,2,239,191,189,239,191,189,90,67,3,239,191,189,239,191,189,239,191,189,25,78,239,191,189,65,113,239,191,189,239,191,189,56,239,191,189,39,239,191,189,40,43,80,16,55,30,204,152,239,191,189,239,191,189,225,136,142,239,191,189,52,239,191,189,239,191,189,34,239,191,189,66,19,239,191,189,239,191,189,239,191,189,16,239,191,189,216,181,124,239,191,189,89,239,191,189,239,191,189,217,132,71,74,11,239,191,189,239,191,189,59,7,239,191,189,55,239,191,189,239,191,189,77,239,191,189,114,239,191,189,65,96,117,239,191,189,21,117,114,39,38,94,239,191,189,239,191,189,101,63,239,191,189,239,191,189,4,27,20,239,191,189,239,191,189,61,239,191,189,6,11,239,191,189,34,26,114,239,191,189,67,239,191,189,97,239,191,189,20,239,191,189,239,191,189,14,239,191,189,34,239,191,189,239,191,189,88,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,49,196,133,44,85,35,239,191,189,239,191,189,10,239,191,189,239,191,189,5,12,239,191,189,239,191,189,239,191,189,221,142,239,191,189,16,88,5,24,239,191,189,6,239,191,189,17,239,191,189,105,98,239,191,189,91,41,64,59,239,191,189,109,12,213,134,102,239,191,189,239,191,189,7,28,216,153,239,191,189,215,172,32,239,191,189,239,191,189,217,191,108,239,191,189,78,108,124,223,161,39,213,169,226,171,184,239,191,189,93,209,185,99,239,191,189,239,191,189,239,191,189,17,117,46,29,46,239,191,189,239,191,189,239,191,189,239,191,189,126,72,103,123,81,211,189,105,9,239,191,189,23,93,49,114,239,191,189,239,191,189,41,239,191,189,121,239,191,189,102,122,55,58,62,91,36,32,78,78,239,191,189,15,113,239,191,189,43,239,191,189,68,61,239,191,189,239,191,189,19,80,89,35,239,191,189,34,239,191,189,2,56,47,5,30,24,239,191,189,111,4,17,44,61,239,191,189,239,191,189,239,191,189,26,239,191,189,239,191,189,7,239,191,189,50,71,91,239,191,189,239,191,189,71,239,191,189,239,191,189,22,33,19,239,191,189,28,124,33,239,191,189,30,72,239,191,189,239,191,189,239,191,189,239,191,189,39,239,191,189,23,239,191,189,239,191,189,239,191,189,119,53,239,191,189,239,191,189,239,191,189,54,239,191,189,239,191,189,220,133,24,239,191,189,40,18,88,239,191,189,239,191,189,122,32,122,239,191,189,239,191,189,239,191,189,114})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a0243c1fb9e",
                        container: "containersf1ff37c07c034bf2b76a1f8ba412b05c",
                        blob: "PageBlob97b6e1b2861f4886ad62949f14d42054",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        leaseId: "3d517022-7b36-453e-aae9-a32a3556393a",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test17614 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17614_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17614_s.txt", Encoding.UTF8);

    public Test17614() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers7b4a3a79fcfe47d2ab28794007ef16d7",
                        blob: "PageBlobc9e92d72ee3941b9b4fd807410c5d121",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test17642 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17642_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17642_s.txt", Encoding.UTF8);

    public Test17642() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers752030dd5ace4c248b782fa01671b641",
                        blob: "PageBlob8b816eae279745cabf3af1be9da3f21f",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        leaseId: "f0d9ffe6-74e8-490e-a038-13a3418037fa",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test21563 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21563_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21563_s.txt", Encoding.UTF8);

    public Test21563() : base(recordedRequest, recordedResponse, "accounts8d43a03f9a30a6c")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a03f9a30a6c",
                        container: "containersb9d399ef084744788521b905326913fc",
                        blob: "PageBlob439ec03585f44a20848d93104871c097",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test18382 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\18382_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\18382_s.txt", Encoding.UTF8);

    public Test18382() : base(recordedRequest, recordedResponse, "accounts8d43a0243e7ac44")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a0243e7ac44",
                        container: "containersa06b6a5d9ee04e07bc9b4831456e857b",
                        blob: "PageBlob960799388d8e42cdbc3c7b56d5af52ff",
                        pageWrite: "Clear".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Clear"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        leaseId: "18f4030f-fca2-4761-ac5d-763935e89eb1",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test17649 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17649_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17649_s.txt", Encoding.UTF8);

    public Test17649() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers2afecf409d244469b8f60d1cf8a0062e",
                        blob: "PageBlob9f0196cbb02b481a84f2503bc878a4d9",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test17621 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17621_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\17621_s.txt", Encoding.UTF8);

    public Test17621() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers0610bd368c1242b1a1483715a98daee8",
                        blob: "PageBlobde549a6926234c809c5ccdf1aad75ed5",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        leaseId: "51914471-cc6a-48dc-9929-79d150c8007b",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test21766 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21766_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21766_s.txt", Encoding.UTF8);

    public Test21766() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" +
    "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containersfcf61cbd503f48aba509e8c729770af6",
                        blob: "Blob6611cc037d504d43bcf5bae98624f537",
                        pageWrite: "".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), ""),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test22313 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\22313_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\22313_s.txt", Encoding.UTF8);

    public Test22313() : base(recordedRequest, recordedResponse, "accounts8d43a0488e099f9")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a0488e099f9",
                        container: "containers319001eb33814703a65814166380d949",
                        blob: "Bloba18907787dee4a81a5034dfb0cd751d1",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=249856-313855",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test21799 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21799_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21799_s.txt", Encoding.UTF8);

    public Test21799() : base(recordedRequest, recordedResponse, "accounts8d43a03fdfa5e75")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,239,191,189,88,79,65,26,49,239,191,189,206,137,239,191,189,239,191,189,239,191,189,239,191,189,63,28,48,239,191,189,92,56,92,239,191,189,92,239,191,189,6,68,64,239,191,189,99,239,191,189,239,191,189,90,239,191,189,239,191,189,7,230,128,131,58,239,191,189,17,239,191,189,239,191,189,18,87,87,37,239,191,189,239,191,189,13,90,111,81,239,191,189,239,191,189,12,92,239,191,189,73,239,191,189,218,144,81,209,166,51,239,191,189,239,191,189,239,191,189,88,239,191,189,239,191,189,105,239,191,189,38,239,191,189,239,191,189,74,113,239,191,189,30,239,191,189,13,85,239,191,189,114,8,5,239,191,189,239,191,189,239,191,189,239,191,189,58,62,239,191,189,239,191,189,49,239,191,189,107,36,239,191,189,56,239,191,189,58,113,239,191,189,5,239,191,189,239,191,189,9,48,17,29,239,191,189,239,191,189,57,239,191,189,239,191,189,46,52,42,239,191,189,46,239,191,189,206,170,113,43,32,239,191,189,239,191,189,239,191,189,239,191,189,77,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,108,239,191,189,58,239,191,189,239,191,189,120,212,160,96,119,239,191,189,54,239,191,189,55,239,191,189,18,9,239,191,189,108,239,191,189,59,239,191,189,95,37,98,55,50,207,157,239,191,189,82,239,191,189,23,57,199,162,100,122,31,85,239,191,189,239,191,189,202,168,239,191,189,113,70,239,191,189,83,239,191,189,239,191,189,22,102,29,239,191,189,239,191,189,40,21,82,239,191,189,69,4,2,104,37,76,30,121,111,87,239,191,189,239,191,189,239,191,189,23,239,191,189,105,15,239,191,189,124,239,191,189,239,191,189,124,239,191,189,27,59,74,239,191,189,239,191,189,53,121,79,40,239,191,189,15,239,191,189,239,191,189,98,239,191,189,92,82,239,191,189,55,239,191,189,61,76,101,79,46,79,239,191,189,113,239,191,189,96,239,191,189,239,191,189,239,191,189,79,77,239,191,189,1,37,239,191,189,58,239,191,189,94,103,37,7,28,239,191,189,239,191,189,51,31,239,191,189,36,83,239,191,189,117,239,191,189,239,191,189,239,191,189,239,191,189,48,239,191,189,7,239,191,189,239,191,189,239,191,189,85,74,127,20,239,191,189,91,45,239,191,189,239,191,189,29,239,191,189,239,191,189,64,71,17,239,191,189,239,191,189,61,121,239,191,189,125,103,6,239,191,189,126,20,5,89,200,136,214,167,239,191,189,59,239,191,189,239,191,189,26,239,191,189,239,191,189,239,191,189,113,81,86,99,239,191,189,233,149,180,239,191,189,123,239,191,189,239,191,189,60,5,108,239,191,189,68,239,191,189,239,191,189,239,191,189,85,239,191,189,10,116,70,55,69,4,239,191,189,63,239,191,189,60,239,191,189,239,191,189,80,43,16,239,191,189,66,239,191,189,126,81,239,191,189,76,239,191,189,12,106,239,191,189,239,191,189,196,141,116,2,21,111,239,191,189,71,239,191,189,29,95,239,191,189,239,191,189,30,123,239,191,189,38,239,191,189,239,191,189,65,221,160,99,1,6,4,52,239,191,189,239,191,189,57,204,172,53,209,177,38,57,239,191,189,69,239,191,189,239,191,189,47,239,191,189,239,191,189,239,191,189,239,191,189,51,35,107,10,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,16,1,15,106,104,239,191,189,24,239,191,189,239,191,189,91,76,202,187,103,239,191,189,66,2,93,239,191,189,26,239,191,189,15,25,239,191,189,17,82,239,191,189,83,239,191,189,199,167,239,191,189,239,191,189,21,55,126,239,191,189,74,90,22,239,191,189,80,239,191,189,239,191,189,239,191,189,89,239,191,189,239,191,189,77,239,191,189,239,191,189,48,56,210,144,239,191,189,239,191,189,239,191,189,87,54,89,239,191,189,239,191,189,47,239,191,189,98,6,239,191,189,47,26,103,239,191,189,2,239,191,189,120,48})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a03fdfa5e75",
                        container: "containers136d005b78ff49758ccf6d362aa9dcd8",
                        blob: "Blobcd6ffe24b8634af58e63faadd09bb8b8",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test21803 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21803_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21803_s.txt", Encoding.UTF8);

    public Test21803() : base(recordedRequest, recordedResponse, "accounts8d43a03fe0f1f19")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,83,9,114,51,56,41,46,239,191,189,89,95,239,191,189,110,239,191,189,239,191,189,239,191,189,60,239,191,189,94,73,60,239,191,189,20,32,239,191,189,39,239,191,189,239,191,189,239,191,189,102,239,191,189,76,239,191,189,102,100,239,191,189,239,191,189,239,191,189,18,239,191,189,73,16,239,191,189,37,106,25,239,191,189,83,239,191,189,239,191,189,239,191,189,73,239,191,189,239,191,189,239,191,189,62,232,136,160,16,100,80,239,191,189,239,191,189,214,143,239,191,189,73,58,239,191,189,239,191,189,239,191,189,76,239,191,189,239,191,189,124,239,191,189,126,120,239,191,189,113,77,89,239,191,189,63,239,191,189,10,239,191,189,38,239,191,189,33,49,1,87,239,191,189,73,239,191,189,78,239,191,189,86,72,25,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,53,239,191,189,239,191,189,10,40,123,239,191,189,3,109,18,239,191,189,195,185,239,191,189,20,74,112,239,191,189,74,53,239,191,189,85,215,173,239,191,189,34,77,87,239,191,189,105,19,67,239,191,189,92,92,99,239,191,189,23,9,239,191,189,100,239,191,189,220,146,239,191,189,24,239,191,189,239,191,189,5,75,126,68,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,63,102,5,45,239,191,189,76,3,239,191,189,84,239,191,189,92,90,239,191,189,239,191,189,88,127,239,191,189,239,191,189,4,121,68,239,191,189,239,191,189,239,191,189,239,191,189,82,106,239,191,189,206,145,27,239,191,189,124,120,239,191,189,239,191,189,3,88,201,169,216,147,99,45,64,55,84,239,191,189,38,239,191,189,239,191,189,239,191,189,103,239,191,189,74,239,191,189,127,113,73,239,191,189,24,48,239,191,189,207,178,239,191,189,56,3,239,191,189,123,108,7,91,239,191,189,239,191,189,239,191,189,93,69,239,191,189,239,191,189,239,191,189,239,191,189,8,239,191,189,46,239,191,189,21,239,191,189,57,212,132,239,191,189,127,199,191,99,239,191,189,94,239,191,189,89,27,239,191,189,126,74,239,191,189,239,191,189,82,239,191,189,239,191,189,239,191,189,125,57,239,191,189,75,59,84,39,30,239,191,189,239,191,189,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,77,239,191,189,239,191,189,239,191,189,43,239,191,189,239,191,189,70,239,191,189,35,74,239,191,189,79,219,129,86,74,239,191,189,52,239,191,189,107,59,239,191,189,239,191,189,214,146,239,191,189,239,191,189,239,191,189,82,239,191,189,92,239,191,189,239,191,189,239,191,189,126,239,191,189,239,191,189,104,86,13,104,239,191,189,85,14,120,239,191,189,73,124,239,191,189,239,191,189,83,7,117,17,111,65,239,191,189,45,239,191,189,108,39,239,191,189,239,191,189,106,50,239,191,189,239,191,189,239,191,189,58,239,191,189,54,93,211,134,104,239,191,189,26,40,239,191,189,46,239,191,189,115,9,239,191,189,111,239,191,189,85,61,239,191,189,39,59,103,113,239,191,189,239,191,189,104,37,13,89,239,191,189,239,191,189,239,191,189,78,239,191,189,239,191,189,23,62,239,191,189,239,191,189,26,126,4,66,109,197,180,239,191,189,49,239,191,189,239,191,189,102,239,191,189,43,19,239,191,189,239,191,189,239,191,189,214,179,0,239,191,189,12,239,191,189,31,239,191,189,239,191,189,36,239,191,189,239,191,189,87,88,108,100,239,191,189,239,191,189,55,37,4,54,31,239,191,189,239,191,189,18,239,191,189,39,8,239,191,189,59,239,191,189,2,43,103,53,239,191,189,120,114,53,34,239,191,189,1,239,191,189,97,74,239,191,189,66,239,191,189,54,239,191,189,106,89,239,191,189,231,159,147,124,239,191,189,239,191,189,16,239,191,189,239,191,189,12,239,191,189,239,191,189,43,239,191,189,55,239,191,189,11,55,1,2,33,53,239,191,189,34,239,191,189,110,123,46})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a03fe0f1f19",
                        container: "containers47390ed6353d43e991ff47f4df3cd572",
                        blob: "Blobe3286cf9e0d54cfd9b6d2765ffcbaefd",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=512-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test21807 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21807_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21807_s.txt", Encoding.UTF8);

    public Test21807() : base(recordedRequest, recordedResponse, "accounts8d43a03fe25dbad")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{87,239,191,189,239,191,189,106,3,89,4,239,191,189,239,191,189,202,176,239,191,189,24,239,191,189,239,191,189,41,239,191,189,46,64,239,191,189,239,191,189,239,191,189,239,191,189,63,239,191,189,76,66,239,191,189,42,108,38,117,239,191,189,70,239,191,189,125,93,239,191,189,2,239,191,189,239,191,189,95,239,191,189,239,191,189,239,191,189,239,191,189,219,144,40,44,124,91,116,122,239,191,189,4,43,25,13,194,147,107,94,239,191,189,239,191,189,123,239,191,189,239,191,189,106,239,191,189,239,191,189,44,122,239,191,189,77,120,17,69,93,100,102,102,2,63,239,191,189,25,41,239,191,189,239,191,189,121,49,239,191,189,239,191,189,3,89,36,1,37,115,17,65,0,38,91,53,80,239,191,189,45,86,239,191,189,229,187,169,91,45,105,30,239,191,189,108,81,239,191,189,239,191,189,239,191,189,115,54,118,119,40,118,239,191,189,239,191,189,76,34,101,64,239,191,189,10,89,56,239,191,189,239,191,189,239,191,189,239,191,189,76,239,191,189,76,239,191,189,44,239,191,189,239,191,189,69,6,239,191,189,101,8,53,239,191,189,239,191,189,26,106,43,4,239,191,189,7,19,111,239,191,189,239,191,189,239,191,189,239,191,189,20,239,191,189,52,239,191,189,61,107,106,78,239,191,189,239,191,189,239,191,189,75,108,239,191,189,239,191,189,203,139,239,191,189,92,11,239,191,189,71,63,239,191,189,91,239,191,189,239,191,189,126,56,88,198,178,64,239,191,189,206,191,239,191,189,239,191,189,40,239,191,189,239,191,189,114,23,48,239,191,189,239,191,189,75,98,71,239,191,189,200,152,239,191,189,239,191,189,239,191,189,70,102,111,239,191,189,239,191,189,239,191,189,21,81,35,27,10,115,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,64,114,48,15,48,122,1,96,28,239,191,189,116,239,191,189,26,95,27,1,120,107,239,191,189,239,191,189,239,191,189,239,191,189,93,239,191,189,13,239,191,189,239,191,189,36,239,191,189,124,78,77,51,216,160,107,239,191,189,55,54,239,191,189,94,239,191,189,36,239,191,189,37,1,239,191,189,88,239,191,189,108,239,191,189,16,15,239,191,189,97,20,106,1,239,191,189,239,191,189,239,191,189,219,160,239,191,189,38,239,191,189,65,239,191,189,239,191,189,100,65,53,239,191,189,239,191,189,126,15,57,239,191,189,239,191,189,127,41,239,191,189,239,191,189,15,239,191,189,60,36,239,191,189,63,86,49,53,239,191,189,79,196,131,46,239,191,189,239,191,189,91,239,191,189,239,191,189,95,43,88,239,191,189,44,100,81,219,130,25,47,124,17,25,239,191,189,239,191,189,239,191,189,75,126,89,50,11,239,191,189,65,30,239,191,189,239,191,189,49,239,191,189,239,191,189,59,35,97,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,122,239,191,189,28,87,210,178,105,239,191,189,239,191,189,204,181,116,110,78,45,32,239,191,189,62,14,105,112,36,80,239,191,189,111,64,238,184,173,122,45,239,191,189,239,191,189,239,191,189,223,131,239,191,189,86,110,107,239,191,189,66,23,101,239,191,189,75,239,191,189,239,191,189,51,195,189,126,239,191,189,40,125,86,95,239,191,189,239,191,189,196,177,239,191,189,37,239,191,189,7,239,191,189,239,191,189,111,239,191,189,49,83,207,163,239,191,189,45,12,239,191,189,36,115,25,239,191,189,234,188,175,198,145,19,239,191,189,36,95,110,220,166,239,191,189,82,239,191,189,239,191,189,207,144,239,191,189,102,239,191,189,239,191,189,105,239,191,189,68,79,79,73,116,239,191,189,239,191,189,31,239,191,189,44,6,105})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a03fe25dbad",
                        container: "mycontainer",
                        blob: "UnsafeBlobName_copied-{12785197}.vhd",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test21559 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21559_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\21559_s.txt", Encoding.UTF8);

    public Test21559() : base(recordedRequest, recordedResponse, "accounts8d43a03f99352d9")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{239,191,189,239,191,189,11,78,18,239,191,189,102,239,191,189,2,89,239,191,189,239,191,189,106,104,29,88,101,18,239,191,189,239,191,189,103,239,191,189,43,239,191,189,29,107,239,191,189,75,239,191,189,78,239,191,189,68,90,117,111,239,191,189,239,191,189,239,191,189,239,191,189,97,46,114,239,191,189,111,239,191,189,206,147,15,239,191,189,239,191,189,239,191,189,0,239,191,189,35,37,34,97,15,48,239,191,189,239,191,189,26,239,191,189,239,191,189,197,128,239,191,189,239,191,189,239,191,189,239,191,189,112,239,191,189,25,84,239,191,189,239,191,189,9,239,191,189,17,79,215,170,239,191,189,85,239,191,189,239,191,189,120,55,79,77,41,216,165,81,98,19,239,191,189,3,239,191,189,104,78,239,191,189,22,8,39,33,239,191,189,120,239,191,189,48,24,239,191,189,239,191,189,239,191,189,239,191,189,83,106,106,21,49,8,73,239,191,189,239,191,189,104,239,191,189,239,191,189,239,191,189,239,191,189,126,66,5,18,239,191,189,1,57,239,191,189,239,191,189,45,124,239,191,189,239,191,189,239,191,189,31,52,239,191,189,239,191,189,196,130,14,239,191,189,72,239,191,189,120,96,5,239,191,189,106,239,191,189,239,191,189,55,31,239,191,189,17,239,191,189,19,239,191,189,85,223,150,239,191,189,239,191,189,60,239,191,189,239,191,189,8,239,191,189,239,191,189,119,239,191,189,37,69,239,191,189,239,191,189,239,191,189,24,239,191,189,72,239,191,189,64,40,7,239,191,189,68,239,191,189,120,239,191,189,49,33,239,191,189,239,191,189,239,191,189,78,239,191,189,11,84,239,191,189,87,98,114,239,191,189,239,191,189,18,218,164,60,239,191,189,239,191,189,239,191,189,12,239,191,189,86,239,191,189,239,191,189,239,191,189,85,239,191,189,239,191,189,14,84,85,239,191,189,56,64,88,239,191,189,239,191,189,239,191,189,196,167,239,191,189,239,191,189,53,75,239,191,189,50,239,191,189,239,191,189,88,62,38,239,191,189,120,1,239,191,189,239,191,189,41,107,239,191,189,239,191,189,239,191,189,84,29,239,191,189,203,153,209,129,16,75,3,54,79,28,73,239,191,189,98,112,239,191,189,34,68,239,191,189,239,191,189,22,47,239,191,189,239,191,189,63,239,191,189,239,191,189,198,132,197,172,41,69,239,191,189,239,191,189,239,191,189,49,96,50,239,191,189,12,59,239,191,189,92,239,191,189,13,85,239,191,189,239,191,189,220,182,10,239,191,189,7,110,239,191,189,217,146,239,191,189,51,239,191,189,126,113,239,191,189,239,191,189,3,239,191,189,239,191,189,239,191,189,239,191,189,18,239,191,189,239,191,189,239,191,189,63,71,100,239,191,189,239,191,189,239,191,189,13,239,191,189,239,191,189,239,191,189,30,239,191,189,239,191,189,40,239,191,189,87,239,191,189,115,239,191,189,239,191,189,239,191,189,125,10,105,239,191,189,53,239,191,189,239,191,189,239,191,189,26,239,191,189,18,239,191,189,44,47,239,191,189,117,11,9,239,191,189,120,239,191,189,239,191,189,239,191,189,239,191,189,91,47,239,191,189,70,76,239,191,189,104,34,30,239,191,189,60,239,191,189,239,191,189,127,239,191,189,67,239,191,189,239,191,189,80,12,239,191,189,124,239,191,189,25,239,191,189,239,191,189,105,239,191,189,14,43,239,191,189,93,239,191,189,89,5,231,130,166,39,6,239,191,189,239,191,189,14,109,83,122,56,239,191,189,239,191,189,52,239,191,189,239,191,189,92,198,168,239,191,189,239,191,189,45,106,47,52,239,191,189,19,239,191,189,239,191,189,239,191,189,100,121,121,22,239,191,189,83,239,191,189,74,99,239,191,189,109,239,191,189,239,191,189,103,239,191,189,239,191,189,52,218,147,59,0,207,176,82,60,84,60,239,191,189,239,191,189,35,239,191,189,27,239,191,189,115,22,239,191,189,16,239,191,189,115,67,18,18,98,239,191,189,69,31,103,2,239,191,189,85,81,57,95,239,191,189,223,148,239,191,189,39,239,191,189,108,22,239,191,189,120,64,34,82,239,191,189,82,80,239,191,189,206,155,102,79,40,239,191,189,108,239,191,189,12,29,239,191,189,58,83,124,210,132,239,191,189,16,239,191,189,239,191,189,239,191,189,239,191,189,6,45,99,239,191,189,34,239,191,189,239,191,189,53,21,239,191,189,217,134,239,191,189,239,191,189,15,104,239,191,189,39,239,191,189,26,239,191,189,239,191,189,239,191,189,92,239,191,189,109,239,191,189,239,191,189,217,189,239,191,189,239,191,189,239,191,189,239,191,189,96,34,239,191,189,85,73,68,25,239,191,189,215,136,121,239,191,189,28,239,191,189,239,191,189,239,191,189,239,191,189,90,23,239,191,189,3,239,191,189,81,6,239,191,189,239,191,189,6,92,91,87,239,191,189,5,239,191,189,239,191,189,114,236,162,155,221,154,1,211,168,83,239,191,189,6,80,239,191,189,239,191,189,49,25,116,239,191,189,22,239,191,189,239,191,189,209,191,239,191,189,239,191,189,62,239,191,189,239,191,189,127,239,191,189,115,83,66,63,239,191,189,6,8,124,124,239,191,189,48,239,191,189,239,191,189,35,239,191,189,100,26,114,42,62,110,72,239,191,189,2,239,191,189,27,239,191,189,239,191,189,73,92,67,71,41,239,191,189,110,239,191,189,13,239,191,189,42,43,16,239,191,189,64,72,239,191,189,239,191,189,212,155,34,47,35,75,98,65,54,42,239,191,189,64,239,191,189,239,191,189,35,38,50,32,239,191,189,239,191,189,78,239,191,189,239,191,189,87,109,71,239,191,189,45,118,8,67,91,239,191,189,70,71,239,191,189,25,56,239,191,189,239,191,189,239,191,189,120,67,239,191,189,239,191,189,6,239,191,189,8,239,191,189,239,191,189,31,239,191,189,239,191,189,71,239,191,189,239,191,189,63,216,182,3,98,20,239,191,189,34,239,191,189,239,191,189,9,93,239,191,189,102,24,239,191,189,4,239,191,189,239,191,189,113,239,191,189,239,191,189,103,239,191,189,239,191,189,66,239,191,189,232,133,156,85,239,191,189,97,239,191,189,65,239,191,189,239,191,189,212,183,33,103,239,191,189,239,191,189,40,44,239,191,189,239,191,189,56,43,239,191,189,123,239,191,189,116,72,78,78,66,107,239,191,189,15,57,239,191,189,72,239,191,189,239,191,189,121,239,191,189,239,191,189,100,239,191,189,239,191,189,239,191,189,30,79,239,191,189,239,191,189,106,239,191,189,202,190,4,239,191,189,90,239,191,189,239,191,189,16,239,191,189,55,239,191,189,51,239,191,189,22,2,239,191,189,239,191,189,104,239,191,189,73,239,191,189,239,191,189,239,191,189,239,191,189,211,140,56,239,191,189,239,191,189,37,239,191,189,239,191,189,228,168,161,18,10,239,191,189,239,191,189,101,218,140,239,191,189,239,191,189,239,191,189,49,239,191,189,107,239,191,189,118,102,38,3,33,14,23,33,47,239,191,189,205,170,85,127,239,191,189,126,71,78,9,117,239,191,189,96,239,191,189,57,110,239,191,189,38,239,191,189,239,191,189,204,142,27,239,191,189,239,191,189,239,191,189,195,154,239,191,189,239,191,189,219,171,214,186,239,191,189,12,239,191,189,48,239,191,189,239,191,189,239,191,189,239,191,189,4,239,191,189,6,98,201,178,15,239,191,189,50,62,58,45,239,191,189,239,191,189,100,9,236,158,138,110,239,191,189,239,191,189,194,180,239,191,189,126,239,191,189,239,191,189,96,239,191,189,84,239,191,189,239,191,189,214,138,66,239,191,189,47,239,191,189,17,239,191,189,239,191,189,239,191,189,239,191,189,113,239,191,189,220,190,239,191,189,239,191,189,68,239,191,189,87,116,9,4,21,82,116,75,239,191,189,29,239,191,189,116,239,191,189,123,112,7,59,33,81,239,191,189,239,191,189,121,239,191,189,83,64,37,66,68,239,191,189,42,74,239,191,189,121,85,103,71,204,133})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "accounts8d43a03f99352d9",
                        container: "containers0dc4dc2400db4e6992c4fde825e6dfea",
                        blob: "PageBlob3e333e2b372b46debe6f3bb350386bd9",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-1023",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}

//<dump disabled/>

public class Test23062 : TestBase
{
    private static readonly string recordedRequest = File.ReadAllText("E:\\BlobStorageTests\\ALL\\23062_c.txt", Encoding.UTF8);
    private static readonly string recordedResponse = File.ReadAllText("E:\\BlobStorageTests\\ALL\\23062_s.txt", Encoding.UTF8);

    public Test23062() : base(recordedRequest, recordedResponse, "testaccount1")
    { }

    [Fact]
    public void Execute()
    {
        // start server
        StartServer();

        try
        {
            // create and use client
            var serviceClient = new AzureStorageClient(this.Credentials);
            serviceClient.BaseUri = new UriBuilder("http", "localhost", Port).Uri.ToString();
            System.IO.Stream body; body = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(new byte[]{112,92,37,239,191,189,108,239,191,189,68,239,191,189,11,239,191,189,36,77,239,191,189,113,123,239,191,189,239,191,189,107,239,191,189,73,32,94,239,191,189,239,191,189,239,191,189,117,118,239,191,189,105,239,191,189,32,197,183,88,239,191,189,14,101,35,239,191,189,239,191,189,239,191,189,57,94,239,191,189,68,4,236,183,155,239,191,189,239,191,189,239,191,189,239,191,189,7,65,239,191,189,239,191,189,75,239,191,189,18,239,191,189,79,16,239,191,189,95,239,191,189,239,191,189,239,191,189,109,51,239,191,189,239,191,189,20,239,191,189,239,191,189,0,239,191,189,65,239,191,189,239,191,189,239,191,189,239,191,189,107,117,44,6,239,191,189,80,239,191,189,79,239,191,189,216,152,239,191,189,16,239,191,189,77,83,239,191,189,110,77,16,45,239,191,189,239,191,189,22,239,191,189,100,32,65,239,191,189,93,239,191,189,109,83,239,191,189,239,191,189,94,88,239,191,189,77,31,29,108,239,191,189,68,239,191,189,126,239,191,189,239,191,189,108,92,34,59,239,191,189,209,160,239,191,189,21,92,96,48,70,79,104,29,42,50,101,6,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,16,94,239,191,189,239,191,189,28,239,191,189,35,239,191,189,239,191,189,1,239,191,189,50,239,191,189,239,191,189,67,239,191,189,72,239,191,189,113,29,239,191,189,239,191,189,3,239,191,189,26,90,25,239,191,189,0,119,207,133,60,239,191,189,239,191,189,65,239,191,189,67,63,123,13,239,191,189,239,191,189,103,239,191,189,239,191,189,239,191,189,239,191,189,194,186,239,191,189,239,191,189,43,239,191,189,24,65,91,58,239,191,189,239,191,189,239,191,189,43,239,191,189,28,49,18,239,191,189,239,191,189,23,1,76,4,239,191,189,239,191,189,16,32,18,239,191,189,55,34,204,141,52,69,239,191,189,63,89,89,239,191,189,127,239,191,189,112,239,191,189,124,239,191,189,239,191,189,41,239,191,189,53,114,2,239,191,189,115,239,191,189,109,239,191,189,239,191,189,53,239,191,189,239,191,189,47,239,191,189,2,239,191,189,239,191,189,62,239,191,189,72,82,239,191,189,65,239,191,189,26,239,191,189,119,63,71,46,239,191,189,115,102,239,191,189,32,37,25,114,239,191,189,33,107,36,239,191,189,239,191,189,80,39,109,239,191,189,239,191,189,112,239,191,189,239,191,189,76,67,239,191,189,101,102,219,166,239,191,189,48,239,191,189,239,191,189,1,239,191,189,88,61,116,239,191,189,36,239,191,189,113,48,239,191,189,239,191,189,21,239,191,189,72,239,191,189,111,239,191,189,239,191,189,239,191,189,69,22,38,35,11,239,191,189,239,191,189,62,239,191,189,70,239,191,189,239,191,189,53,227,172,148,239,191,189,47,239,191,189,239,191,189,75,100,111,28,239,191,189,37,80,210,147,239,191,189,33,239,191,189,239,191,189,23,94,239,191,189,53,50,239,191,189,18,239,191,189,42,63,239,191,189,94,49,239,191,189,36,63,239,191,189,3,239,191,189,239,191,189,10,103,239,191,189,105,239,191,189,24,37,65,239,191,189,30,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,200,163,100,239,191,189,69,239,191,189,10,239,191,189,30,239,191,189,223,143,239,191,189,215,139,125,67,239,191,189,239,191,189,75,80,38,59,239,191,189,4,239,191,189,239,191,189,64,239,191,189,36,239,191,189,239,191,189,65,53,96,38,53,97,45,93,32,75,239,191,189,203,136,67,239,191,189,35,239,191,189,8,126,117,203,178,119,124,41,10,64,239,191,189,85,239,191,189,114,239,191,189,43,4,239,191,189,125,119,100,71,239,191,189,92,112,43,5,39,112,24,239,191,189,111,239,191,189,239,191,189,239,191,189,239,191,189,62,239,191,189,239,191,189,239,191,189,239,191,189,239,191,189,43,32,78,7,239,191,189})));
            try
            {
                serviceClient.HttpClient.DefaultRequestHeaders.ExpectContinue = false;
                var cancellationToken = Debugger.IsAttached
                    ? new CancellationToken()
                    : new CancellationTokenSource(3000).Token;
                var result = serviceClient.PageBlobs.PutPageWithHttpMessagesAsync(
                        accountName: "testaccount1",
                        container: "containers8d6e276ea87343a498545a2eaf5f3535",
                        blob: "PageBlob78a998b10923410b93f5d33607a657fd",
                        pageWrite: "Update".ParsePageWrite() ?? (PageWrite)Enum.Parse(typeof(PageWrite), "Update"),
                        body: body,
                        timeout: 30,
                        range: "bytes=0-511",
                        cancellationToken: cancellationToken).GetAwaiter().GetResult();
                Assert.True(false); // expected exception
                
            }
            catch (CloudException)
            {
                

                // validate e.Body or similar?
            }
            catch (ValidationException)
            {
                
            }
            catch (ArgumentException)
            {
                
            }
        }
        catch
        {
            // prioritize! The server exception might have caused the exception on this thread (but get's swallowed by VS and such)
            if (ServerException != null)
                /*expecting failure*/;
            else
                throw;
        }
        finally
        {
            // stop server
            StopServer();
        }
    }
}