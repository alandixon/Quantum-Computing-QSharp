namespace QubitExample
// namespace Quantum.StrathWeb
{
 
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    
 
    operation HelloQ() : Unit {
        Message("Hello quantum world!");
    }


    @EntryPoint()
    operation MeasureQubits(count : Int) : Int { 
        mutable resultsTotal = 0; 
        use qubit = Qubit() { 
            for idx in 0..count {
                let result = Measure([PauliZ], [qubit]);
                set resultsTotal += result == One ? 1 | 0;
                Reset(qubit);
            }
 
            return resultsTotal;
        }
    }

}
