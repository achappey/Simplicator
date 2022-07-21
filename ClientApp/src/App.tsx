import { Component } from 'react';
import { Home } from './components/Home';
import { createLightTheme, FluentProvider } from '@fluentui/react-components';

const appTheme = {
  "10": "#2f1ad4",
  "20": "#3821e4",
  "30": "#4a36e7",
  "40": "#5c4ae9",
  "50": "#6f5fec",
  "60": "#8173ee",
  "70": "#9488f1",
  "80": "#a69cf3",
  "90": "#b8b0f5",
  "100": "#cbc5f8",
  "110": "#ddd9fa",
  "120": "#f0eefd",
  "130": "#ffffff",
  "140": "#ffffff",
  "150": "#ffffff",
  "160": "#ffffff"
};

const customLightTheme = createLightTheme(appTheme);

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <FluentProvider theme={customLightTheme}>
        <div style={{ paddingLeft: 8, paddingRight: 8 }}>
          <div>
            <h3>Simplicator</h3>
          </div>
          <div>
            <Home />
          </div>
        </div>
      </FluentProvider>
    );
  }
}
