

using System;

class MyClass
{
    static void Main()
    {
        Violin myViolin = new Violin();
        Violin myViolinElectric = new Violin(name: "Electric Violin", 
                                             history: "The electric violin appeared in the mid-20th century", 
                                             sound: "Produces electric, amplified sound");
        Trombone myTrombone = new Trombone();
        Ukulele myUkulele = new Ukulele();
        Cello myCello = new Cello();


        myViolin.Show();
        myViolin.History();
        myViolin.Desc();
        myViolin.Sound();

        Console.WriteLine();


        myViolinElectric.Show();
        myViolinElectric.History();
        myViolinElectric.Desc();
        myViolinElectric.Sound();


        Console.WriteLine();

        myTrombone.Show();
        myTrombone.History();
        myTrombone.Desc();
        myTrombone.Sound();

        Console.WriteLine();

        myUkulele.Show();
        myUkulele.History();
        myUkulele.Desc();
        myUkulele.Sound();

        Console.WriteLine();

        myCello.Show();
        myCello.History();
        myCello.Desc();
        myCello.Sound();
    }
}

class MusicalInstrument
{
    private string _NameOfMusInstrument { get; set; }
    private string? _HistoryOfMusInstrument { get; set; }
    private string? _DescribeOfMusInstrument { get; set; }
    private string? _SoundOfMusInstrument { get; set; }

    
    protected MusicalInstrument(string name, string? describe = null, string? history = null, string? sound = null)
    {
        _NameOfMusInstrument = name;
        _DescribeOfMusInstrument = describe;
        _HistoryOfMusInstrument = history;
        _SoundOfMusInstrument = sound;
    }


    public void Show()
    {
        Console.WriteLine($"Instrument: {_NameOfMusInstrument}");
    }

    public void History()
    {
        Console.WriteLine(_HistoryOfMusInstrument != null
            ? $"History: {_HistoryOfMusInstrument}"
            : "Field History is empty.");
    }

    public void Desc()
    {
        Console.WriteLine(_DescribeOfMusInstrument != null
            ? $"Description: {_DescribeOfMusInstrument}"
            : "Field Description is empty.");
    }

    public void Sound()
    {
        Console.WriteLine(_SoundOfMusInstrument != null
            ? $"Sound: {_SoundOfMusInstrument}"
            : "Field Sound is emty.");
    }
}

class Violin : MusicalInstrument
{
    public Violin(string name = "Violin", string? describe = "A string instrument stretched over a shaped hollow box.",
                  string? history = "The violin has a long history dating back to the 16th century.",
                  string? sound = "Make an elegant, graceful, high-pitched, melodious sounds")
        : base(name, describe, history, sound)
    { }
}

class Trombone : MusicalInstrument
{
    public Trombone(string name = "Trombone", string? describe = "A brass instrument with a sliding bar changes the pitch of the notes.",
                    string? history = "The trombone is invented in the 15th century.",
                    string? sound = "Make a powerful, bold, brassy sound.")
        : base(name, describe, history, sound)
    { }
}

class Ukulele : MusicalInstrument
{
    public Ukulele(string name = "Ukulele", string? describe = "A small guitar or banjo with four strings.",
                   string? history = "The ukulele originated in Hawaii in the 19th century.",
                   string? sound = "Make a bright, happy sound, with a pitch about an octave higher than the guitar.")
        : base(name, describe, history, sound)
    { }
}

class Cello : MusicalInstrument
{
    public Cello(string name = "Cello", string? describe = "A large string instrument, similar to the violin but with a deeper sound.",
                 string? history = "The cello  was developed in the early 16th century.",
                 string? sound = "Make rich, melodious, deep tones.")
        : base(name, describe, history, sound)
    { }
}