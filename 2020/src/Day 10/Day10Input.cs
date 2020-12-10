﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day_10
{
    public class Day10Input
    {
        private const string Input = @"47
99
115
65
10
55
19
73
80
100
71
110
64
135
49
3
1
98
132
2
38
118
66
116
104
87
79
114
40
37
44
97
4
140
60
86
56
133
7
146
85
111
134
53
121
77
117
21
12
81
145
129
107
93
22
48
11
54
92
78
67
20
138
125
57
96
26
147
124
34
74
143
13
28
126
50
29
70
39
63
41
91
32
84
144
27
139
33
88
72
23
103
16";

        public static ImmutableList<JoltageAdapter> ParseInput()
        {
            return Input.Split("\r\n").Select(JoltageAdapterFactory.CreateJoltageAdapterFromString).ToImmutableList();
        }
    }
}
