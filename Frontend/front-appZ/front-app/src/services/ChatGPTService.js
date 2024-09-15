import OpenAI from "openai";

const openai = new OpenAI({
    apiKey: process.env.VUE_APP_OPENAI_API_KEY, // Postavi svoj API ključ
    dangerouslyAllowBrowser: true // Omogućava upotrebu u browser-u, uz rizik
});

export async function posaljiPitanje(pitanje) {
    const completion = await openai.chat.completions.create({
        model: "gpt-3.5-turbo",
        messages: [
            {"role": "user", "content": pitanje}
        ]
    });
    //alert(process.env.VUE_APP_OPENAI_API_KEY);
    const odgovor = completion.choices[0].message.content;
    
    return odgovor;}
