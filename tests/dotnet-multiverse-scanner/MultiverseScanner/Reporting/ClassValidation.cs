// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text;

namespace MultiverseScanner.Reporting
{
    public class ClassValidation
    {
        public string Name { get; }

        public List<MethodValidation> MethodValidations { get; }

        public ClassValidation(string name)
        {
            Name = name;
            MethodValidations = new List<MethodValidation>();
        }
    }
}
