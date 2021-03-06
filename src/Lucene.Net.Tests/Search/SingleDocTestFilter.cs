namespace Lucene.Net.Search
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    using AtomicReaderContext = Lucene.Net.Index.AtomicReaderContext;
    using IBits = Lucene.Net.Util.IBits;
    using FixedBitSet = Lucene.Net.Util.FixedBitSet;

    public class SingleDocTestFilter : Filter
    {
        private int Doc;

        public SingleDocTestFilter(int doc)
        {
            this.Doc = doc;
        }

        public override DocIdSet GetDocIdSet(AtomicReaderContext context, IBits acceptDocs)
        {
            FixedBitSet bits = new FixedBitSet(context.Reader.MaxDoc);
            bits.Set(Doc);
            if (acceptDocs != null && !acceptDocs.Get(Doc))
            {
                bits.Clear(Doc);
            }
            return bits;
        }
    }
}