#include "stdinclude.hpp"
#include <EEPROM.h>
#include <FastLED.h>


namespace component
{
    namespace ongeki_hardware
    {
        
        const int LEVER = PIN_A0;
        const int LED_PIN = A1;
        const uint8_t PIN_MAP[10] = {
            // L: A B C SIDE MENU
            9,
            8,
            7,
            16,
            15,
            // R: A B C SIDE MENU
            6,
            5,
            4,
            14,
            10,
        };

        CRGB lightColors[6];

        void start()
        {
            // setup pin modes for button
            for (unsigned char i : PIN_MAP)
            {
                pinMode(i, INPUT_PULLUP);
                pinMode(A1, OUTPUT);
            }

            // setup led_t
            FastLED.addLeds<WS2812B, LED_PIN, GRB>(lightColors, 6);
        }

        void read_io(raw_hid::output_data_t *data) {
            for(auto i = 0; i < 10; i++) 
              {
                if (i % 5 == 3)
                {
                    data->buttons[i] = digitalRead(PIN_MAP[i]) == HIGH;
                }
                else
                {
                    data->buttons[i] = digitalRead(PIN_MAP[i]) == LOW;
                }
            }
            // TODO: Change AnalogRead to Self Function
            data->lever = analogRead(LEVER);

            if(data->buttons[4] && data->buttons[9]) {
                EEPROM.get(0, data->aimi_id);
                data->scan = true;
            } else {
                memset(&data->aimi_id, 0, 10);
                data->scan = false;
            }
        }


        void set_led(raw_hid::led_t &data)
        {
            FastLED.setBrightness(data.ledBrightness);

            for (int i = 0; i < 3; i++)
            {
                memcpy(&lightColors[i], &data.ledColors[i], 3);
                memcpy(&lightColors[i + 3], &data.ledColors[i + 5], 3);
            }

            FastLED.show();
        }
    }
}
