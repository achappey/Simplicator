import { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Home } from './components/Home';
import { initializeIcons } from '@fluentui/font-icons-mdl2';
import { Access } from './components/Access';
import { ThemeProvider, PartialTheme } from '@fluentui/react';

initializeIcons();

const appTheme: PartialTheme = {
  palette: {
    themePrimary: '#A69CF3'
  }
};

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <ThemeProvider theme={appTheme}>
        <div style={{ paddingLeft: 20 }}>
          <div>
            <h3>Simplicator</h3>
          </div>
          <div>
            <Routes>
              <Route path='/' element={<Home />} />
              <Route path='/access' element={<Access />} />
            </Routes>
          </div>
        </div>
      </ThemeProvider>
    );
  }
}
