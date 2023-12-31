﻿// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LiteEval;
using System;
using System.Collections.Generic;
using System.Linq;

BenchmarkRunner.Run<ExpressionBenchmark>();


[MemoryDiagnoser]
public class ExpressionBenchmark {
    private Expression     _expression;
    private ExpressionCalc _expressionCalc;
    private Expression     _expressionComplex;

    [GlobalSetup]
    public void Setup() {
        _expression             = new Expression("2 * 3 + (4 - 1) ^ 2");
        _expressionComplex      = new Expression("3*x^2 + 2*y + z + sin(w) + cos(v) + tan(u) - log(t) + sqrt(s) + atan2(r, q) - max(p, o) + min(n, m) + abs(l) + round(k) + floor(j) + ceiling(i) - truncate(h) + sign(g)");
        _expressionComplex["x"] = 5;
        _expressionComplex["y"] = 3.14;
        _expressionComplex["z"] = 2.71;
        _expressionComplex["w"] = 1.57;
        _expressionComplex["v"] = 0;
        _expressionComplex["u"] = 45;
        _expressionComplex["t"] = 10;
        _expressionComplex["s"] = 16;
        _expressionComplex["r"] = 2;
        _expressionComplex["q"] = 3;
        _expressionComplex["p"] = 5;
        _expressionComplex["o"] = 6;
        _expressionComplex["n"] = 7;
        _expressionComplex["m"] = 8;
        _expressionComplex["l"] = -9;
        _expressionComplex["k"] = 10.5;
        _expressionComplex["j"] = 11.4;
        _expressionComplex["i"] = 12.7;
        _expressionComplex["h"] = 13.9;
        _expressionComplex["g"] = -14;
        _expressionCalc         = new ExpressionCalc("2 * 3 + (4 - 1) ^ 2");
    }

    [Benchmark]
    public void NewExpression() {
        var _expression = new Expression("2 * 3 + (4 - 1) ^ 2");
    }

    [Benchmark]
    public void NewComplexExpression() {
        var _expressionComplex = new Expression("3*x^2 + 2*y + z + sin(w) + cos(v) + tan(u) - log(t) + sqrt(s) + atan2(r, q) - max(p, o) + min(n, m) + abs(l) + round(k) + floor(j) + ceiling(i) - truncate(h) + sign(g)");
        _expressionComplex["x"] = 5;
        _expressionComplex["y"] = 3.14;
        _expressionComplex["z"] = 2.71;
        _expressionComplex["w"] = 1.57;
        _expressionComplex["v"] = 0;
        _expressionComplex["u"] = 45;
        _expressionComplex["t"] = 10;
        _expressionComplex["s"] = 16;
        _expressionComplex["r"] = 2;
        _expressionComplex["q"] = 3;
        _expressionComplex["p"] = 5;
        _expressionComplex["o"] = 6;
        _expressionComplex["n"] = 7;
        _expressionComplex["m"] = 8;
        _expressionComplex["l"] = -9;
        _expressionComplex["k"] = 10.5;
        _expressionComplex["j"] = 11.4;
        _expressionComplex["i"] = 12.7;
        _expressionComplex["h"] = 13.9;
        _expressionComplex["g"] = -14;
    }

    [Benchmark]
    public void NewExpressionCalc() {
        var _expressionCalc = new ExpressionCalc("2 * 3 + (4 - 1) ^ 2");
    }

    [Benchmark]
    public void BenchmarkResult() {
        var result = _expression.Result;
    }

    [Benchmark]
    public void BenchmarkComplex() {
        var result = _expressionComplex.Result;
    }

    [Benchmark]
    public void BenchmarkEval() {
        var result = _expressionCalc.Eval();
    }
}