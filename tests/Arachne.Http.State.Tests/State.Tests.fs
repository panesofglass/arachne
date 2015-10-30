﻿module Arachne.Http.State.Tests

open System
open NUnit.Framework
open Arachne.Core.Tests
open Arachne.Http.State

[<Test>]
let ``Cookie Formatting/Parsing`` () =
    let cookieTyped =
        Cookies [
            Pair (Name "test", Value "value") ]

    let cookieString =
        "test=value"

    roundTrip (Cookie.Format, Cookie.Parse) [
        cookieTyped, cookieString ]

[<Test>]
let ``Multiple Cookie Formatting/Parsing`` () =
    let cookieTyped =
        Cookies [
            Pair (Name "cookie1", Value "foo")
            Pair (Name "cookie2", Value "bar") ]

    let cookieString =
        "cookie1=foo; cookie2=bar"

    roundTrip (Cookie.Format, Cookie.Parse) [
        cookieTyped, cookieString ]

[<Test>]
let ``Set-Cookie Formatting/Parsing`` () =
    let setCookieTyped =
        SetCookie (
            Pair (Name "test", Value "value"),
            Attributes [
                Expires (DateTime.Parse "1994/10/29 19:43:31")
                MaxAge (TimeSpan.FromSeconds 42.)
                Domain (SubDomain "www.example.com")
                Path ("/some/path")
                Secure
                HttpOnly ])

    let setCookieString =
        "test=value; Expires=Sat, 29 Oct 1994 19:43:31 GMT; Max-Age=42; Domain=www.example.com; Path=/some/path; Secure; HttpOnly"

    roundTrip (SetCookie.Format, SetCookie.Parse) [
        setCookieTyped, setCookieString ]