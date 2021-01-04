import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import Logo from '../piggy.svg';

export class NavMenu extends Component {
  
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
      return (

          <div >
              <img class="logo" src={Logo} />
            <ul class="navbar">
                <li><a href="/log-in">log in</a></li>
                <li><a href="/sign-up">sign up</a></li>
                <li><a href="/BMInfo">budget manager</a></li>
                <li><a href="/SavingsManagerInformations">saving manager</a></li>
                <li><a href="/ExpensesManagerInformations">expenses manager</a></li>
                <li><a href="/ExpensesManagerInformations/add">add limit</a></li>
                <li><a href="/Challenges">challenges</a></li>
                <li><a href="/Leaderboard">leaderboard</a></li>
                <li><a href="/">Home</a></li>
            </ul>
        </div>
    );
  }
}
