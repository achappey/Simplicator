import { Component } from 'react';
import { Home } from './components/Home';
import { createLightTheme, FluentProvider } from '@fluentui/react-components';

const appTheme = {
  "10": "#503ce7",
  "20": "#5c4ae9",
  "30": "#6958eb",
  "40": "#7565ec",
  "50": "#8173ee",
  "60": "#8d81f0",
  "70": "#9a8ef1",
  "80": "#a69cf3",
  "90": "#b2aaf5",
  "100": "#bfb7f6",
  "110": "#cbc5f8",
  "120": "#d7d3fa",
  "130": "#e3e0fb",
  "140": "#f0eefd",
  "150": "#fcfbff",
  "160": "#ffffff"
}

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
