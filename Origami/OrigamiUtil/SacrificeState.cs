namespace OrigamiUtil;

internal struct SacrificeState {
    // ABCX XNNN
    // A: iris state prev. 0 = open, 1 = closed.
    // B: iris state curr.
    // C: consumingMors
    // NNN: number of stored mors, up to 7.
    private byte state;

    public SacrificeState()
    {
        state = 0b00000000;
    }

    public SacrificeState(byte state_in) {
        state = state_in;
    }

    public bool PrevState
    {
        readonly get
        {
            return (state & 0b10000000) == 0b10000000;
        }
        set
        {
            if (value)
            {
                state |= 0b10000000;
            }
            else
            {
                state &= 0b01111111;
            }
        }
    }

    public bool CurrState
    {
        readonly get
        {
            return (state & 0b01000000) == 0b01000000;
        }
        set
        {
            if (value)
            {
                state |= 0b01000000;
            }
            else
            {
                state &= 0b10111111;
            }
        }
    }
    public bool ConsumingMors
    {
        readonly get
        {
            return (state & 0b00100000) == 0b00100000;
        }
        set
        {
            if (value)
            {
                state |= 0b00100000;
            }
            else
            {
                state &= 0b11011111;
            }
        }
    }

    public byte MorsCount
    {
        readonly get
        {
            return (byte)(state & 0b00000111);
        }
        set
        {
            state &= 0b11100000; //mask to clear old value
            state |= (byte)(value & 0b00000111);
        }
    }

    public void Update()
    {
        PrevState = CurrState;
    }

    public readonly byte GetState() {
        return state;
    }
}
