﻿/*
 * Copyright (C) 2020 Usetech Professional
 * Copyright (C) 2021 BloGa Tech AG,
 * Copyright (C) 2024 SubstrateGaming
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Substrate.NET.Schnorrkel.Scalars;

namespace Substrate.NET.Schnorrkel.Ristretto
{
    public class CompletedPoint
    {
        public FieldElement51 X { get; set; }
        public FieldElement51 Y { get; set; }
        public FieldElement51 Z { get; set; }
        public FieldElement51 T { get; set; }

        public ProjectivePoint ToProjective()
        {
            return new ProjectivePoint
            {
                X = X.Mul(T),
                Y = Y.Mul(Z),
                Z = Z.Mul(T)
            };
        }

        public EdwardsPoint ToExtended()
        {
            return new EdwardsPoint
            {
                X = X.Mul(T),
                Y = Y.Mul(Z),
                Z = Z.Mul(T),
                T = X.Mul(Y)
            };
        }
    }
}