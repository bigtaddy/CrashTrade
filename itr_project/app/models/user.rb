# == Schema Information
#
# Table name: users
#
#  id                     :integer          not null, primary key
#  email                  :string(255)      default(""), not null
#  encrypted_password     :string(255)      default(""), not null
#  reset_password_token   :string(255)
#  reset_password_sent_at :datetime
#  remember_created_at    :datetime
#  sign_in_count          :integer          default(0)
#  current_sign_in_at     :datetime
#  last_sign_in_at        :datetime
#  current_sign_in_ip     :string(255)
#  last_sign_in_ip        :string(255)
#  created_at             :datetime         not null
#  updated_at             :datetime         not null
#  avatar                 :string(255)
#

class User < ActiveRecord::Base

   acts_as_voter
   before_create :create_role
  # before_create :create_profile
  # Include default devise modules. Others available are:
  #:token_authenticatable, :confirmable,
  # :lockable, :timeoutable and :omniauthable
     devise :database_authenticatable, :registerable,
         :recoverable, :rememberable, :trackable, :validatable
   
  attr_accessible :email, :password, :password_confirmation, :remember_me, :profile_attributes, :token_authenticatable, :confirmable
     
  has_many :users_roles, :dependent => :destroy
  has_many :roles, :through => :users_roles
  has_many :user_tasks, :dependent => :destroy
  has_many :resolved_tasks, :through => :user_tasks, :class_name => "Task", :source => :task

  # Setup accessible (or protected) attributes for your model
  has_one :profile, :dependent => :destroy
  has_many :created_tasks, :class_name => "Task", :foreign_key => :user_id, :dependent => :destroy


#  accepts_nested_attributes_for :profile#, :reject_if => proc { |attributes| @profile_attr = attributes; binding.pry }

  after_create :create_profile
  
  def role?(role)
    return !!self.roles.find_by_name(role)
  end 
  private
    def create_role
      self.roles << Role.find_by_name(:user)  
    end

    def create_profile
      self.profile = Profile.new
    end

end

